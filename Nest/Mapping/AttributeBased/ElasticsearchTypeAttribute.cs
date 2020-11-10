﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Nest6
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ElasticsearchTypeAttribute : Attribute
	{
		private static readonly ConcurrentDictionary<Type, ElasticsearchTypeAttribute> CachedTypeLookups =
			new ConcurrentDictionary<Type, ElasticsearchTypeAttribute>();

		public string IdProperty { get; set; }

		public string Name { get; set; }

		public static ElasticsearchTypeAttribute From(Type type)
		{
			if (CachedTypeLookups.TryGetValue(type, out var attr))
				return attr;

			var attributes = type.GetTypeInfo().GetCustomAttributes(typeof(ElasticsearchTypeAttribute), true);
			if (attributes.HasAny())
				attr = (ElasticsearchTypeAttribute)attributes.First();
			CachedTypeLookups.TryAdd(type, attr);
			return attr;
		}
	}
}
