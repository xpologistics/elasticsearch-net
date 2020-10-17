namespace Nest6
{
	/// <summary>
	/// Retrieve usage information for machine learning jobs.
	/// </summary>
	public partial interface IGetJobsRequest { }

	/// <inheritdoc />
	public partial class GetJobsRequest { }

	/// <inheritdoc />
	[DescriptorFor("XpackMlGetJobs")]
	public partial class GetJobsDescriptor { }
}
