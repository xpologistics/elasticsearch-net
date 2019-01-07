Feature: Ping on first usage

	Pinging is enabled by default for the Static, Sniffing And Sticky connection pools. The first time a node is used or resurrected, a ping is issued a with a small (configurable) timeout. This allows the client to fail and fallover to another node much faster than attempting a request.

	Scenario: A node that fails to respond to a ping should be marked as dead.
	
		Given I have a cluster with 2 nodes
		And node 1 responds to ping requests
		And node 2 does not respond to ping requests
		When I make a request with the client
		Then node 1 should be marked as alive
		When I make a request with the client
		Then node 2 should be marked as dead
		And node 1 should be marked as alive

	Scenario: The client should fail over nodes that do not respond to ping requests until it reaches a node that does.
	
		Given I have a cluster with 4 nodes
		And nodes 1 and 4 respond to ping requests
		And nodes 2 and 3 do not respond to ping requests
		When I make a request with the client
		Then node 1 should be marked as alive
		When I make a request with the client
		Then nodes 2 and 3 should be marked as dead
		And node 4 should be marked as alive

	Scenario: All nodes are pinged on first use.
	
		Given I have a cluster with 4 nodes
		And all nodes respond to ping requests
		When I make 4 requests with the client
		Then all nodes should be marked as alive