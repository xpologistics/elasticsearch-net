﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest6
{
	public interface ICcrStatsResponse : IResponse
	{
		[JsonProperty("auto_follow_stats")]
		CcrAutoFollowStats AutoFollowStats { get; }

		[JsonProperty("follow_stats")]
		CcrFollowStats FollowStats { get; }
	}

	public class CcrStatsResponse : ResponseBase, ICcrStatsResponse
	{
		/// <inheritdoc cref="ICcrStatsResponse.AutoFollowStats"/>
		public CcrAutoFollowStats AutoFollowStats { get; internal set; }

		/// <inheritdoc cref="ICcrStatsResponse.FollowStats"/>
		public CcrFollowStats FollowStats { get; internal set; }
	}

	public class CcrFollowStats
	{
		/// <inheritdoc cref="IFollowIndexStatsResponse.Indices" />
		[JsonProperty("indices")]
		public IReadOnlyCollection<FollowIndexStats> Indices { get; internal set; } = EmptyReadOnly<FollowIndexStats>.Collection;
	}

	public class CcrAutoFollowStats
	{
		/// <summary>
		/// The number of indices that the auto-follow coordinator failed to automatically follow; the causes of recent failures are
		/// captured in the logs of the elected master node, and in the <see cref="RecentAutoFollowErrors"/> field.
		/// </summary>
		[JsonProperty("number_of_failed_follow_indices")]
		public long NumberOfFailedFollowIndices { get; internal set; }

		/// <summary>
		/// The number of times that the auto-follow coordinator failed to retrieve the cluster state from a
		/// remote cluster registered in a collection of auto-follow patterns.
		/// </summary>
		[JsonProperty("number_of_failed_remote_cluster_state_requests")]
		public long NumberOfFailedRemoteClusterStateRequests { get; internal set; }

		/// <summary>The number of indices that the auto-follow coordinator successfully followed.</summary>
		[JsonProperty("number_of_successful_follow_indices")]
		public long NumberOfSuccessfulFollowIndices { get; internal set; }

		/// <summary>An array of objects representing failures by the auto-follow coordinator.</summary>
		[JsonProperty("recent_auto_follow_errors")]
		public IReadOnlyCollection<ErrorCause> RecentAutoFollowErrors { get; internal set; } = EmptyReadOnly<ErrorCause>.Collection;

		/// <summary>
		///  An array of auto followed clusters.
		/// </summary>
		[JsonProperty("auto_followed_clusters")]
		public IReadOnlyCollection< AutoFollowedCluster> AutoFollowedClusters { get; internal set; } = EmptyReadOnly<AutoFollowedCluster>.Collection;
	}

	public class AutoFollowedCluster
	{
		/// <summary>
		/// The cluster name.
		/// </summary>
		[JsonProperty("cluster_name")]
		public string ClusterName { get; internal set; }

		/// <summary>
		/// Time since last check.
		/// </summary>
		[JsonProperty("time_since_last_check_millis")]
		[JsonConverter(typeof(EpochMillisecondsDateTimeJsonConverter))]
		public DateTimeOffset TimeSinceLastCheck { get; internal set; }

		/// <summary>
		/// Last seen metadata version.
		/// </summary>
		[JsonProperty("last_seen_metadata_version")]
		public long LastSeenMetadataVersion { get; internal set; }
	}
}
