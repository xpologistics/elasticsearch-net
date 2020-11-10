﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary> Deletes a configured collection of auto-follow patterns. </summary>
	[MapsApi("ccr.delete_auto_follow_pattern.json")]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<DeleteAutoFollowPatternRequest>))]
	public partial interface IDeleteAutoFollowPatternRequest { }

	/// <inheritdoc cref="IDeleteAutoFollowPatternRequest"/>
	public partial class DeleteAutoFollowPatternRequest { }

	/// <inheritdoc cref="IDeleteAutoFollowPatternRequest"/>
	public partial class DeleteAutoFollowPatternDescriptor { }
}
