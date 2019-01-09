Feature: First usage

	By default, a client will retry a request as many times as there
	are known nodes in the cluster.
	
	Retries still respect the request timeout; if you have a 100 node cluster
	and a request timeout of 20 seconds, the client will retry as many
	times as it can before giving up at the request timeout of 20 seconds.

	Scenario: Retry for every known node in the cluster, the client will
	          automatically fail over to each node for a single request.
		
		Given I have a cluster with 10 nodes
		And nodes 1 to 9 respond with a Bad response
		And node 10 responds with a Healthy response
		And pings are disabled
		When I make a request with the client
		Then nodes 1 to 9 should be marked as dead
		And node 10 should be marked as alive
	
	Scenario: A maxiumum number of retries can be specified to limit the
			  number of nodes that can be failed over.
			  The number of requests is Initial attempt + Number of retries

		Given I have a cluster with 10 nodes
		And nodes 1 to 9 respond with a Bad response
		And node 10 responds with a Healthy response
		And pings are disabled
		And maximum retries is 3 times
		When I make a request with the client
		Then nodes 1 to 4 should be marked as dead
		And the client should raise a maximum retries reached
		
	Scenario: Overall request timeout is respected when attempting retries
	          across nodes that are slow to respond.

	Given I have a cluster with 10 nodes
	And nodes 1 to 9 respond with a Bad response after 10 seconds
	And node 10 responds with a Healthy response
	And pings are disabled
	And request timeouts are set to 20 seconds
	When I make a request with the client
	Then nodes 1 and 2 should be marked as dead
	And the client should raise a maximum timeout reached

	Scenario: A maximum retry timeout can be specified to help contain individual
			  request timeouts.

	Given I have a cluster with 10 nodes
	And all nodes respond with a Bad response after 3 seconds
	And pings are disabled
	And request timeouts are set to 2 seconds
	And maximum retry timeout is set to 10 seconds
	When I make a request with the client
	Then nodes 1 to 5 should be marked as dead
	And the client should raise a maximum timeout reached
	
	Scenario: The client will not retry the same node twice.

	Given I have a cluster with 2 nodes
	And all nodes respond with a Bad response after 3 seconds
	And pings are disabled
	And request timeouts are set to 2 seconds
	And maximum retry timeout is set to 10 seconds
	When I make a request with the client
	Then nodes 1 and 2 should be marked as dead
	And the client should raise a maximum retries reached
	And the client should raise an all nodes failed event
