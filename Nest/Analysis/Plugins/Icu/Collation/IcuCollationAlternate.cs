using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest6
{
	/// <summary>
	/// Sets the alternate handling for strength quaternary to be either shifted or non-ignorable.
	/// Which boils down to ignoring punctuation and whitespace.
	/// </summary>
	/// <remarks>
	/// Requires analysis-icu plugin to be installed
	/// </remarks>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum IcuCollationAlternate
	{
		[EnumMember(Value = "shifted")] Shifted,
		[EnumMember(Value = "non-ignorable")] NonIgnorable
	}
}
