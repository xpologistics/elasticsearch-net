Feature: First Usage

#PingFailsFallsOverToHealthyNodeWithoutPing
Given I have a cluster with nodes: A, B
and node A responds to ping requests
and node B does not respond to ping requests
When I use the client
Then node A should be marked as alive
and node B should be marked as dead

#PingFailsFallsOverMultipleTimesToHealthyNode
Given I have a cluster with nodes: A to D
and node A responds to ping requests
and node B does not respond to ping requests
and node C does not respond to ping requests
and node D responds to ping requests
When I use the client
Then node A should be marked as alive
and node B should be marked as dead
and node C should be marked as dead
and node D should be marked as alive

#AllNodesArePingedOnlyOnFirstUseProvidedTheyAreHealthy
Given I have a cluster with nodes: A to D
and all nodes respond to ping requests
When I use the client
Then all nodes should be marked as alive