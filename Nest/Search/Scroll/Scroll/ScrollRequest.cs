﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IScrollRequest : ICovariantSearchRequest
	{
		[JsonProperty("scroll")]
		Time Scroll { get; set; }

		[JsonProperty("scroll_id")]
		string ScrollId { get; set; }
	}

	public partial class ScrollRequest
	{
		public ScrollRequest(string scrollId, Time scroll)
		{
			Scroll = scroll;
			ScrollId = scrollId;
		}

		public Time Scroll { get; set; }

		public string ScrollId { get; set; }

		public Func<dynamic, Hit<dynamic>, Type> TypeSelector { get; set; }
		private Type _clrType { get; set; }
		Type ICovariantSearchRequest.ClrType => _clrType;
	}

	public partial class ScrollDescriptor<T> where T : class
	{
		Type ICovariantSearchRequest.ClrType => typeof(T);

		Time IScrollRequest.Scroll { get; set; }

		string IScrollRequest.ScrollId { get; set; }

		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public ScrollDescriptor<T> Scroll(Time scroll) => Assign(scroll, (a, v) => a.Scroll = v);

		public ScrollDescriptor<T> ScrollId(string scrollId) => Assign(scrollId, (a, v) => a.ScrollId = v);
	}
}
