﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Nest6
{
	internal class HasVariableExpressionVisitor : ExpressionVisitor
	{
		private bool _found;

		public HasVariableExpressionVisitor(Expression e) => Visit(e);

		public bool Found
		{
			get => _found;
			// This is only set to true once to prevent clobbering from subsequent node visits
			private set
			{
				if (!_found) _found = value;
			}
		}

		public override Expression Visit(Expression node)
		{
			if (!Found)
				return base.Visit(node);

			return node;
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (node.Method.Name == nameof(SuffixExtensions.Suffix) && node.Arguments.Any())
			{
				var lastArg = node.Arguments.Last();
				Found = !(lastArg is ConstantExpression);
			}
			else if (node.Method.Name == "get_Item" && node.Arguments.Any())
			{
				var t = node.Object.Type;
				var isDict =
					typeof(IDictionary).IsAssignableFrom(t)
					|| typeof(IDictionary<,>).IsAssignableFrom(t)
					|| t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>);

				if (!isDict)
					return base.VisitMethodCall(node);

				var lastArg = node.Arguments.Last();
				Found = !(lastArg is ConstantExpression);
			}
			return base.VisitMethodCall(node);
		}
	}

	internal class FieldExpressionVisitor : ExpressionVisitor
	{
		private readonly IConnectionSettingsValues _settings;
		private readonly Stack<string> _stack = new Stack<string>();

		public FieldExpressionVisitor(IConnectionSettingsValues settings) => _settings = settings;

		public string Resolve(Expression expression, bool toLastToken = false)
		{
			Visit(expression);
			if (toLastToken) return _stack.Last();

			return _stack
				.Aggregate(
					new StringBuilder(),
					(sb, name) =>
						(sb.Length > 0 ? sb.Append(".") : sb).Append(name))
				.ToString();
		}

		public string Resolve(MemberInfo info)
		{
			if (info == null)
				return null;

			var name = info.Name;

			if (_settings.PropertyMappings.TryGetValue(info, out var propertyMapping))
				return propertyMapping.Name;

			var att = ElasticsearchPropertyAttributeBase.From(info);
			if (att != null && !att.Name.IsNullOrEmpty())
				return att.Name;

			return _settings.PropertyMappingProvider?.CreatePropertyMapping(info)?.Name ?? _settings.DefaultFieldNameInferrer(name);
		}

		protected override Expression VisitMember(MemberExpression expression)
		{
			if (_stack == null) return base.VisitMember(expression);

			var name = Resolve(expression.Member);
			_stack.Push(name);
			return base.VisitMember(expression);
		}

		protected override Expression VisitMethodCall(MethodCallExpression methodCall)
		{
			if (methodCall.Method.Name == nameof(SuffixExtensions.Suffix) && methodCall.Arguments.Any())
			{
				VisitConstantOrVariable(methodCall, _stack);
				var callingMember = new ReadOnlyCollection<Expression>(
					new List<Expression> { { methodCall.Arguments.First() } }
				);
				Visit(callingMember);
				return methodCall;
			}
			else if (methodCall.Method.Name == "get_Item" && methodCall.Arguments.Any())
			{
				var t = methodCall.Object.Type;
				var isDict =
					typeof(IDictionary).IsAssignableFrom(t)
					|| typeof(IDictionary<,>).IsAssignableFrom(t)
					|| t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>);

				if (!isDict) return base.VisitMethodCall(methodCall);

				VisitConstantOrVariable(methodCall, _stack);
				Visit(methodCall.Object);
				return methodCall;
			}
			else if (IsLinqOperator(methodCall.Method))
			{
				for (var i = 1; i < methodCall.Arguments.Count; i++) Visit(methodCall.Arguments[i]);
				Visit(methodCall.Arguments[0]);
				return methodCall;
			}
			return base.VisitMethodCall(methodCall);
		}

		private static void VisitConstantOrVariable(MethodCallExpression methodCall, Stack<string> stack)
		{
			var lastArg = methodCall.Arguments.Last();
			var value = lastArg is ConstantExpression constantExpression
				? constantExpression.Value.ToString()
				: Expression.Lambda(lastArg).Compile().DynamicInvoke().ToString();
			stack.Push(value);
		}

		private static bool IsLinqOperator(MethodInfo methodInfo)
		{
			if (methodInfo.DeclaringType != typeof(Queryable) && methodInfo.DeclaringType != typeof(Enumerable))
				return false;

			return methodInfo.GetCustomAttribute<ExtensionAttribute>() != null;
		}
	}
}
