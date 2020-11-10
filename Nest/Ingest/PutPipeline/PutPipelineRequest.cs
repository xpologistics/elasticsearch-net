using System;
using System.Collections.Generic;

namespace Nest6
{
	public partial interface IPutPipelineRequest : IPipeline { }

	public partial class PutPipelineRequest
	{
		public string Description { get; set; }
		public IEnumerable<IProcessor> OnFailure { get; set; }
		public IEnumerable<IProcessor> Processors { get; set; }
	}

	[DescriptorFor("IngestPutPipeline")]
	public partial class PutPipelineDescriptor
	{
		string IPipeline.Description { get; set; }
		IEnumerable<IProcessor> IPipeline.OnFailure { get; set; }
		IEnumerable<IProcessor> IPipeline.Processors { get; set; }

		/// <inheritdoc />
		public PutPipelineDescriptor Description(string description) => Assign(description, (a, v) => a.Description = v);

		/// <inheritdoc />
		public PutPipelineDescriptor Processors(IEnumerable<IProcessor> processors) => Assign(processors.ToListOrNullIfEmpty(), (a, v) => a.Processors = v);

		/// <inheritdoc />
		public PutPipelineDescriptor Processors(Func<ProcessorsDescriptor, IPromise<IList<IProcessor>>> selector) =>
			Assign(selector, (a, v) => a.Processors = v?.Invoke(new ProcessorsDescriptor())?.Value);

		/// <inheritdoc />
		public PutPipelineDescriptor OnFailure(IEnumerable<IProcessor> processors) => Assign(processors.ToListOrNullIfEmpty(), (a, v) => a.OnFailure = v);

		/// <inheritdoc />
		public PutPipelineDescriptor OnFailure(Func<ProcessorsDescriptor, IPromise<IList<IProcessor>>> selector) =>
			Assign(selector, (a, v) => a.OnFailure = v?.Invoke(new ProcessorsDescriptor())?.Value);
	}
}
