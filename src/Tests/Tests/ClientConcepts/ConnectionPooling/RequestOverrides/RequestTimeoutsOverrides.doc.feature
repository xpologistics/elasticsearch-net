Feature: Request timeout overrides

	It is possible to specify a ping or request time out globally, or override per request.
	
	Scenario: Overriding the request timeout on a per request basis.
	
		Given I have a cluster with 10 nodes
		And nodes 1 to 9 respond with a Bad response after 10 seconds
		And node 10 responds with a Healthy response
		And pings are disabled
		And request timeouts are set to 20 seconds
		When I make a request with the client
		Then nodes 1 and 2 should be marked as dead
		And the client should raise a maximum timeout reached
		When I make a request with the client with request timeout set to 80 seconds
		Then nodes 3 to 9 should be marked as dead
		And node 10 should be marked as alive
		
	Scenario: Overriding ping timeouts on a per request basis.
		
		Given I have a cluster with 10 nodes
		And all nodes respond to pings after 20 seconds
		And ping timeouts are set to 10 seconds
		And request timeouts are set to 10 seconds
		When I make a request with the client
		Then the client should raise a ping failure for node 1
		And the client should raise a maximum timeout reached
		When I make a request with the client with ping timeout set to 2 seconds
		Then the client should raise a ping failure for nodes 3 to 7
		And the client should raise a maximum timeout reached