Feature: Disable sniffing and pinging per request

	A sniffing connection pool is setup to sniff on start/failure and with pinging enabled. It is possible to opt out of this behaviour on a per request basis.

	Scenario: Setup up a cluster that pings and sniffs on startup but
	          disable the sniffing on first request. Sniffing is deffered
			  to the second request.
	
		Given I have a cluster with 10 nodes
		And a sniffing connection pool
		And client sniffs on startup
		When I make a request with the client with sniffing disabled
		Then the client should ping node 1 successfully
		And the client should receive a Healthy response from node 1
		When I make a request with the client 
		Then the client should sniff successfully
		And the client should ping node 1 successfully
		And the client should receive a response from node 1
		When I make a request with the client 
		And the client should ping node 2 successfully
		And the client should receive a response from node 2
