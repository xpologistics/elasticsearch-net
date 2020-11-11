namespace Elasticsearch6.Net
{
	public enum PipelineFailure
	{
		BadAuthentication,
		BadResponse,
		PingFailure,
		SniffFailure,
		CouldNotStartSniffOnStartup,
		MaxTimeoutReached,
		MaxRetriesReached,
		Unexpected,
		BadRequest,
		NoNodesAttempted
	}
}
