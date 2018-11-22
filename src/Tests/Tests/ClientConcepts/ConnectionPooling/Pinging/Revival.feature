Feature: Ping On Revival

#PingAfterRevival
Given I have a cluster with nodes: A to C
and all nodes respond to ping requests
and node C does not respond to client calls
When I use the client
Then node A should be marked as alive
and node B should be marked as alive
and node C should be marked as dead
Given 20 minutes have lapsed
When I use the client
Then all nodes should be marked as alive