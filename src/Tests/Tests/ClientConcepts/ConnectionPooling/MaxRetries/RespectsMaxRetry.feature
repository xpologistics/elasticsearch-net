Feature: First Usage

#DefaultMaxIsNumberOfNodes
	
	Given I have a cluster with nodes: A to K
	and nodes A to J do not respond to client calls
	and node K does respond to client calls
	and pings are disabled
	When I use the client
	Then nodes A to J should be marked as dead
	and node K should be marked as alive
	
#FixedMaximumNumberOfRetries
	
 	Given I have a cluster with nodes: A to K
 	and nodes A to J do not respond to client calls
 	and node K does respond to client calls
 	and pings are disabled
	and retries are attempted a maximum of 3 times
 	When I use the client
 	Then nodes A to D should be marked as dead
 	and client should fail with maximum retries reached
	
#RespectsOverallRequestTimeout

	Given I have a cluster with nodes: A to K
	and nodes A to J do not respond to client calls after 10 seconds
	and node K does respond to client calls
	and pings are disabled
	and request timeouts are set to 20 seconds
	When I use the client
	Then nodes A to B should be marked as dead
	and client should fail with maximum timeout reached

#RespectsMaxRetryTimeoutOverRequestTimeout

	Given I have a cluster with nodes: A to K
	and all nodes do not respond to client calls after 3 seconds
	and pings are disabled
	and request timeouts are set to 2 seconds
	and maximum retry timeout is set to 10 seconds
	When I use the client
	Then nodes A to E should be marked as dead
	and client should fail with maximum timeout reached
	
 #RetriesAreLimitedByNodesInPool

	Given I have a cluster with nodes: A, B
	and all nodes do not respond to client calls after 3 seconds
	and pings are disabled
	and request timeouts are set to 2 seconds
	and maximum retry timeout is set to 10 seconds
	When I use the client
	Then nodes A, B should be marked as dead
	and client should fail with maximum retries reached and all nodes failed
		