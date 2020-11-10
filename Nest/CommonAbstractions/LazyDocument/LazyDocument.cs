﻿using System;
using Elasticsearch.Net;
using Newtonsoft.Json.Linq;

namespace Nest6
{
	/// <summary>
	/// A lazily deserialized document
	/// </summary>
	[ContractJsonConverter(typeof(LazyDocumentJsonConverter))]
	public interface ILazyDocument
	{
		/// <summary>
		/// Creates an instance of <typeparamref name="T" /> from this
		/// <see cref="ILazyDocument" /> instance
		/// </summary>
		/// <typeparam name="T">The type</typeparam>
		T As<T>();

		/// <summary>
		/// Creates an instance of <paramref name="objectType" /> from this
		/// <see cref="ILazyDocument" /> instance
		/// </summary>
		/// <param name="objectType">The type</param>
		object As(Type objectType);
	}

	/// <inheritdoc />
	public class LazyDocument : ILazyDocument
	{
		private readonly IElasticsearchSerializer _serializer;

		internal LazyDocument(JToken token, IElasticsearchSerializer serializer)
		{
			Token = token;
			_serializer = serializer;
		}

		internal JToken Token { get; }

		/// <inheritdoc />
		public T As<T>()
		{
			if (Token == null) return default(T);
			using (var ms = Token.ToStream())
				return _serializer.Deserialize<T>(ms);
		}

		/// <inheritdoc />
		public object As(Type objectType)
		{
			if (Token == null) return null;
			using (var ms = Token.ToStream())
				return _serializer.Deserialize(objectType, ms);
		}
	}
}
