﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	[ContractJsonConverter(typeof(MultiSearchResponseJsonConverter))]
	public class MultiSearchResponse : ResponseBase, IMultiSearchResponse
	{
		public MultiSearchResponse() => Responses = new Dictionary<string, object>();

		public IEnumerable<IResponse> AllResponses => _allResponses<IResponse>();

		public override bool IsValid => base.IsValid && AllResponses.All(b => b.IsValid);

		public int TotalResponses => Responses.HasAny() ? Responses.Count() : 0;

		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, object>))]
		internal IDictionary<string, object> Responses { get; set; }

		public IEnumerable<IResponse> GetInvalidResponses() => _allResponses<IResponse>().Where(r => !r.IsValid);

		public ISearchResponse<T> GetResponse<T>(string name) where T : class
		{
			object response;
			Responses.TryGetValue(name, out response);
			var r = response as IElasticsearchResponse;
			if (r != null)
				r.ApiCall = ApiCall;
			return response as SearchResponse<T>;
		}

		public IEnumerable<ISearchResponse<T>> GetResponses<T>() where T : class => _allResponses<SearchResponse<T>>();

		protected override void DebugIsValid(StringBuilder sb)
		{
			sb.AppendLine($"# Invalid searches (inspect individual response.DebugInformation for more detail):");
			foreach (var i in AllResponses.Select((item, i) => new { item, i }).Where(i => !i.item.IsValid))
				sb.AppendLine($"  search[{i.i}]: {i.item}");
		}

		private IEnumerable<T> _allResponses<T>() where T : class, IResponse, IElasticsearchResponse
		{
			foreach (var r in Responses.Values.OfType<T>())
			{
				((IElasticsearchResponse)r).ApiCall = ApiCall;
				yield return r;
			}
		}
	}
}
