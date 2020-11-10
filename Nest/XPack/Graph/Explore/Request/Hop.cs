using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest6
{
	public interface IHop
	{
		[JsonProperty("connections")]
		IHop Connections { get; set; }

		[JsonProperty("query")]
		QueryContainer Query { get; set; }

		[JsonProperty("vertices")]
		IEnumerable<IGraphVertexDefinition> Vertices { get; set; }
	}

	public class Hop : IHop
	{
		public IHop Connections { get; set; }
		public QueryContainer Query { get; set; }
		public IEnumerable<IGraphVertexDefinition> Vertices { get; set; }
	}

	public class HopDescriptor<T> : DescriptorBase<HopDescriptor<T>, IHop>, IHop
		where T : class
	{
		IHop IHop.Connections { get; set; }
		QueryContainer IHop.Query { get; set; }
		IEnumerable<IGraphVertexDefinition> IHop.Vertices { get; set; }

		public HopDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<T>()));

		public HopDescriptor<T> Vertices(Func<GraphVerticesDescriptor<T>, IPromise<IList<IGraphVertexDefinition>>> selector) =>
			Assign(selector, (a, v) => a.Vertices = v?.Invoke(new GraphVerticesDescriptor<T>())?.Value);

		public HopDescriptor<T> Connections(Func<HopDescriptor<T>, IHop> selector) =>
			Assign(selector, (a, v) => a.Connections = v?.Invoke(new HopDescriptor<T>()));
	}
}
