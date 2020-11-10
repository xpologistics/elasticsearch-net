﻿using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IPhraseSuggestHighlight
	{
		[JsonProperty("post_tag")]
		string PostTag { get; set; }

		[JsonProperty("pre_tag")]
		string PreTag { get; set; }
	}

	public class PhraseSuggestHighlight : IPhraseSuggestHighlight
	{
		public string PostTag { get; set; }
		public string PreTag { get; set; }
	}

	public class PhraseSuggestHighlightDescriptor : DescriptorBase<PhraseSuggestHighlightDescriptor, IPhraseSuggestHighlight>, IPhraseSuggestHighlight
	{
		string IPhraseSuggestHighlight.PostTag { get; set; }
		string IPhraseSuggestHighlight.PreTag { get; set; }

		public PhraseSuggestHighlightDescriptor PreTag(string preTag) => Assign(preTag, (a, v) => a.PreTag = v);

		public PhraseSuggestHighlightDescriptor PostTag(string postTag) => Assign(postTag, (a, v) => a.PostTag = v);
	}
}
