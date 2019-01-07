Feature: Ping on revival

	Nodes marked as dead at any point are subject to being taken out
	of the node pool for a period of time.
	
	Scenario: When a node is marked as dead it will be taken out
	          of the node pool for a period of time. When this time
			  lapses a ping will be scheduled before the next request and,
			  if successful, will put the node back into the pool, if not,
			  it will remain out of the pool.

		Given I have a cluster with 3 nodes
		And nodes 1 and 2 respond with a Healthy response
		And node 3 responds with a Bad response
		When I make a request with the client
		Then nodes 1 and 2 should be marked as alive
		And node 3 should be marked as dead
		Given 20 minutes have lapsed
		And node 3 responds with a Healthy response
		When I make a request with the client
		Then all nodes should be marked as alive