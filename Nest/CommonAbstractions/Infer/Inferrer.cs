﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nest6
{
	public class Inferrer
	{
		private readonly IConnectionSettingsValues _connectionSettings;

		public Inferrer(IConnectionSettingsValues connectionSettings)
		{
			connectionSettings.ThrowIfNull(nameof(connectionSettings));
			_connectionSettings = connectionSettings;
			IdResolver = new IdResolver(connectionSettings);
			IndexNameResolver = new IndexNameResolver(connectionSettings);
			TypeNameResolver = new TypeNameResolver(connectionSettings);
			RelationNameResolver = new RelationNameResolver(connectionSettings);
			FieldResolver = new FieldResolver(connectionSettings);
			RoutingResolver = new RoutingResolver(connectionSettings, IdResolver);

			Contracts = new ConcurrentDictionary<Type, JsonContract>();
			CreateMultiHitDelegates =
				new ConcurrentDictionary<Type, Action<MultiGetHitJsonConverter.MultiHitTuple, JsonSerializer, ICollection<IMultiGetHit<object>>>>();
			CreateSearchResponseDelegates =
				new ConcurrentDictionary<Type, Action<MultiSearchResponseJsonConverter.SearchHitTuple, JsonSerializer, IDictionary<string, object>>
				>();
		}

		internal ConcurrentDictionary<Type, JsonContract> Contracts { get; }

		internal ConcurrentDictionary<Type, Action<MultiGetHitJsonConverter.MultiHitTuple, JsonSerializer, ICollection<IMultiGetHit<object>>>>
			CreateMultiHitDelegates { get; }

		internal ConcurrentDictionary<Type, Action<MultiSearchResponseJsonConverter.SearchHitTuple, JsonSerializer, IDictionary<string, object>>>
			CreateSearchResponseDelegates { get; }

		private FieldResolver FieldResolver { get; }
		private IdResolver IdResolver { get; }
		private IndexNameResolver IndexNameResolver { get; }
		private RelationNameResolver RelationNameResolver { get; }
		private RoutingResolver RoutingResolver { get; }
		private TypeNameResolver TypeNameResolver { get; }

		public string Resolve(IUrlParameter urlParameter) => urlParameter.GetString(_connectionSettings);

		public string Field(Field field) => FieldResolver.Resolve(field);

		public string PropertyName(PropertyName property) => FieldResolver.Resolve(property);

		public string IndexName<T>() where T : class => IndexNameResolver.Resolve<T>();

		public string IndexName(IndexName index) => IndexNameResolver.Resolve(index);

		public string Id<T>(T instance) where T : class => IdResolver.Resolve(instance);

		public string Id(Type type, object instance) => IdResolver.Resolve(type, instance);

		public string TypeName<T>() where T : class => TypeNameResolver.Resolve<T>();

		public string TypeName(TypeName type) => TypeNameResolver.Resolve(type);

		public string RelationName<T>() where T : class => RelationNameResolver.Resolve<T>();

		public string RelationName(RelationName type) => RelationNameResolver.Resolve(type);

		public string Routing<T>(T document) => RoutingResolver.Resolve(document);

		public string Routing(Type type, object instance) => RoutingResolver.Resolve(type, instance);
	}
}
