﻿namespace Nest6
{
	public class SignificantTermsAggregate : MultiBucketAggregate<SignificantTermsBucket>
	{
		public long? BgCount { get; set; }
		public long DocCount { get; set; }
	}
}
