﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public partial interface IGraphExploreRequest : IHop
	{
		[JsonProperty("controls")]
		IGraphExploreControls Controls { get; set; }
	}

	public interface IGraphExploreRequest<T> : IGraphExploreRequest where T : class { }

	public partial class GraphExploreRequest
	{
		public IHop Connections { get; set; }
		public IGraphExploreControls Controls { get; set; }
		public QueryContainer Query { get; set; }
		public IEnumerable<IGraphVertexDefinition> Vertices { get; set; }
	}

	public partial class GraphExploreRequest<T> : IGraphExploreRequest<T>
		where T : class
	{
		public GraphExploreRequest() : this(typeof(T), typeof(T)) { }

		public IHop Connections { get; set; }
		public IGraphExploreControls Controls { get; set; }

		public QueryContainer Query { get; set; }
		public IEnumerable<IGraphVertexDefinition> Vertices { get; set; }
	}

	[DescriptorFor("XpackGraphExplore")]
	public partial class GraphExploreDescriptor<T> : IGraphExploreRequest<T>
		where T : class
	{
		public GraphExploreDescriptor() : base(r => r.Optional("index", (Indices)typeof(T)).Optional("type", (Types)typeof(T))) { }

		IHop IHop.Connections { get; set; }
		IGraphExploreControls IGraphExploreRequest.Controls { get; set; }
		QueryContainer IHop.Query { get; set; }
		IEnumerable<IGraphVertexDefinition> IHop.Vertices { get; set; }

		public GraphExploreDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));

		public GraphExploreDescriptor<T> Vertices(Func<GraphVerticesDescriptor<T>, IPromise<IList<IGraphVertexDefinition>>> selector) =>
			Assign(selector, (a, v) => a.Vertices = v?.Invoke(new GraphVerticesDescriptor<T>())?.Value);

		public GraphExploreDescriptor<T> Connections(Func<HopDescriptor<T>, IHop> selector) =>
			Assign(selector, (a, v) => a.Connections = v?.Invoke(new HopDescriptor<T>()));

		public GraphExploreDescriptor<T> Controls(Func<GraphExploreControlsDescriptor<T>, IGraphExploreControls> selector) =>
			Assign(selector, (a, v) => a.Controls = v?.Invoke(new GraphExploreControlsDescriptor<T>()));
	}
}
