﻿using System;

namespace Nest6
{
	public abstract class ActionsDescriptorBase<TDescriptor, TInterface>
		: DescriptorBase<TDescriptor, TInterface>, IAction
		where TDescriptor : DescriptorBase<TDescriptor, TInterface>, TInterface
		where TInterface : class, IAction
	{
		private string _name;

		protected ActionsDescriptorBase(string name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (name.Length == 0) throw new ArgumentException("cannot be empty");

			_name = name;
		}

		protected abstract ActionType ActionType { get; }

		ActionType IAction.ActionType => ActionType;

		string IAction.Name
		{
			get => _name;
			set => _name = value;
		}

		Time IAction.ThrottlePeriod { get; set; }
		TransformContainer IAction.Transform { get; set; }

		public TDescriptor Transform(Func<TransformDescriptor, TransformContainer> selector) =>
			Assign(selector.InvokeOrDefault(new TransformDescriptor()), (a, v) => a.Transform = v);

		public TDescriptor ThrottlePeriod(Time throttlePeriod) => Assign(throttlePeriod, (a, v) => a.ThrottlePeriod = v);
	}
}
