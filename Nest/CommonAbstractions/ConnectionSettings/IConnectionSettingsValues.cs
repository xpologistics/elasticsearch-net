﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Elasticsearch.Net;

namespace Nest6
{
	/// <summary>
	/// Provides the connection settings for NEST's high level <see cref="ElasticClient" />
	/// </summary>
	public interface IConnectionSettingsValues : IConnectionConfigurationValues
	{
		/// <summary>
		/// Specifies how field names are inferred from CLR property names.
		/// <para></para>
		/// By default, NEST camel cases property names
		/// </summary>
		/// <example>
		/// CLR property EmailAddress will be inferred as "emailAddress" Elasticsearch document field name
		/// </example>
		Func<string, string> DefaultFieldNameInferrer { get; }

		/// <summary>
		/// The default index to use for a request when no index has been explicitly specified
		/// and no default indices are specified for the given CLR type specified for the request.
		/// </summary>
		string DefaultIndex { get; }

		/// <summary>
		/// The default index/indices to use for a request for a given CLR type specified in the request.
		/// </summary>
		FluentDictionary<Type, string> DefaultIndices { get; }

		/// <summary>
		/// The default relation name to use for a request for a given CLR type specified in the request.
		/// </summary>
		FluentDictionary<Type, string> DefaultRelationNames { get; }

		/// <summary>
		/// A default type name to use within Elasticsearch for all CLR types. If <see cref="DefaultTypeNameInferrer" /> is also set, a configured
		/// default type name will only be used when <see cref="DefaultTypeNameInferrer" />returns null or empty. If unset, the default type
		/// name for types will be the lowercased CLR type name.
		/// </summary>
		string DefaultTypeName { get; }

		/// <summary>
		/// Specify how a type name is inferred from a CLR type.
		/// By default, a type names is inferred by calling <see cref="string.ToLowerInvariant" /> on the CLR type's name.
		/// </summary>
		Func<Type, string> DefaultTypeNameInferrer { get; }

		FluentDictionary<Type, string> DefaultTypeNames { get; }

		/// <summary>
		/// Specify a property for a CLR type to use to infer the _id of the document when indexed in Elasticsearch.
		/// </summary>
		FluentDictionary<Type, string> IdProperties { get; }

		/// <summary>
		/// Infers index, type, id, relation, routing and field names
		/// </summary>
		Inferrer Inferrer { get; }

		/// <summary>
		/// Provides mappings for CLR types
		/// </summary>
		IPropertyMappingProvider PropertyMappingProvider { get; }

		/// <summary>
		/// Provides mappings for CLR type members
		/// </summary>
		FluentDictionary<MemberInfo, IPropertyMapping> PropertyMappings { get; }

		/// <summary>
		/// Specify a property for a CLR type to use to infer the routing for of a document when indexed in Elasticsearch.
		/// </summary>
		FluentDictionary<Type, string> RouteProperties { get; }

		/// <summary>
		/// Disables automatic Id inference for given CLR types.
		/// <para></para>
		/// NEST by default will use the value of a property named Id on a CLR type as the _id to send to Elasticsearch. Adding a type
		/// will disable this behaviour for that CLR type. If Id inference should be disabled for all CLR types, use
		/// <see cref="DefaultDisableIdInference"/>
		/// </summary>
		HashSet<Type> DisableIdInference { get; }

		/// <summary>
		/// Disables automatic Id inference for all CLR types.
		/// <para></para>
		/// NEST by default will use the value of a property named Id on a CLR type as the _id to send to Elasticsearch. Setting this to <c>true</c>
		/// will disable this behaviour for all CLR types and cannot be overridden. If Id inference should be disabled only for specific types, use
		/// <see cref="DisableIdInference"/>
		/// </summary>
		bool DefaultDisableIdInference { get; }

		/// <summary>
		/// The serializer use to serialize CLR types representing documents and other types related to documents.
		/// </summary>
		IElasticsearchSerializer SourceSerializer { get; }
	}
}
