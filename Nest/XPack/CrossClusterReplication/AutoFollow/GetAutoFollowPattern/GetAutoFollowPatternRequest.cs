﻿using System;
using Newtonsoft.Json;

namespace Nest6
{
	/// <summary> Gets configured auto-follow patterns. This API will return the specified auto-follow pattern collection. </summary>
	[MapsApi("ccr.get_auto_follow_pattern.json")]
	[ContractJsonConverter(typeof(ReadAsTypeJsonConverter<GetAutoFollowPatternRequest>))]
	public partial interface IGetAutoFollowPatternRequest { }

	/// <inheritdoc cref="IGetAutoFollowPatternRequest"/>
	public partial class GetAutoFollowPatternRequest { }

	/// <inheritdoc cref="IGetAutoFollowPatternRequest"/>
	public partial class GetAutoFollowPatternDescriptor { }
}
