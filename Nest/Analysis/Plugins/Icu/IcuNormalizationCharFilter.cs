﻿using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// Normalizes as defined here: http://userguide.icu-project.org/transforms/normalization
	/// </summary>
	/// <remarks>
	/// Requires analysis-icu plugin to be installed
	/// </remarks>
	public interface IIcuNormalizationCharFilter : ICharFilter
	{
		/// <summary>
		/// Set the mode parameter to decompose to convert nfc to nfd or nfkc to nfkd respectively
		/// </summary>
		[JsonProperty("mode")]
		IcuNormalizationMode? Mode { get; set; }

		/// <summary>
		/// The type of normalization
		/// </summary>
		[JsonProperty("name")]
		IcuNormalizationType? Name { get; set; }
	}

	/// <inheritdoc />
	public class IcuNormalizationCharFilter : CharFilterBase, IIcuNormalizationCharFilter
	{
		public IcuNormalizationCharFilter() : base("icu_normalizer") { }

		/// <inheritdoc />
		public IcuNormalizationMode? Mode { get; set; }

		/// <inheritdoc />
		public IcuNormalizationType? Name { get; set; }
	}

	/// <inheritdoc />
	public class IcuNormalizationCharFilterDescriptor
		: CharFilterDescriptorBase<IcuNormalizationCharFilterDescriptor, IIcuNormalizationCharFilter>, IIcuNormalizationCharFilter
	{
		protected override string Type => "icu_normalizer";
		IcuNormalizationMode? IIcuNormalizationCharFilter.Mode { get; set; }
		IcuNormalizationType? IIcuNormalizationCharFilter.Name { get; set; }

		/// <inheritdoc />
		public IcuNormalizationCharFilterDescriptor Name(IcuNormalizationType? name = null) =>
			Assign(name, (a, v) => a.Name = v);

		/// <inheritdoc />
		public IcuNormalizationCharFilterDescriptor Mode(IcuNormalizationMode? mode = null) =>
			Assign(mode, (a, v) => a.Mode = v);
	}
}
