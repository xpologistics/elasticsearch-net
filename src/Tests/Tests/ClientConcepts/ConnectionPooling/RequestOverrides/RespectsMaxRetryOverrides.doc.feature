Feature: Maximum retries per request

	Retries occur as many times as we have available nodes. However retries still respect the request timeout.
		
	Scenario: Default maximum retries is the number of nodes
	
		Given I have a cluster with 10 nodes
		And nodes 1 to 9 respond with a Bad response
		And node 10 responds with a Healthy response
		And pings are disabled
		When I make a request with the client with 2 maximum retries		
		Then the client should raise a Bad response for nodes 1 to 3		
		And the client should raise a maximum retries reached
		
	Scenario: Maximum retries can be set globally
	
		Given I have a cluster with 10 nodes
		And nodes 1 to 9 respond with a Bad response
		And node 10 responds with a Healthy response
		And pings are disabled
		And maxmimum retries is set to 5
		When I make a request with the client	
		Then the client should raise a Bad response for nodes 1 to 6		
		And the client should raise a maximum retries reached
		
	Scenario: Single node connection pools do not utilise retry settings
	
		Given I have a cluster with 10 nodes
		And a single node connection pool
		And all nodes respond with a Bad response
		And pings are disabled
		And maxmimum retries is set to 10
		When I make a request with the client	
		Then the client should raise a Bad response for nodes 1