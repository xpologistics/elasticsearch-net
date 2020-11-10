using Newtonsoft.Json;

namespace Nest6
{
	/// <summary>
	/// An ICU analyzer that performs basic normalization, tokenization and character folding,
	/// using the <see cref="IIcuNormalizationCharFilter" /> char filter,
	/// <see cref="IIcuTokenizer" /> and <see cref="IcuNormalizationTokenFilter" /> token filter
	/// </summary>
	/// <remarks>
	/// Requires analysis-icu plugin to be installed and Elasticsearch 6.6.0+
	/// </remarks>
	public interface IIcuAnalyzer : IAnalyzer
	{
		/// <summary>
		/// Normalization method. Default is <see cref="IcuNormalizationType.CompatibilityCaseFold" />
		/// </summary>
		[JsonProperty("method")]
		IcuNormalizationType? Method { get; set; }

		/// <summary>
		/// Normalization mode. Default is <see cref="IcuNormalizationMode.Compose" />
		/// </summary>
		[JsonProperty("mode")]
		IcuNormalizationMode? Mode { get; set; }
	}

	/// <inheritdoc cref="IIcuAnalyzer" />
	public class IcuAnalyzer : AnalyzerBase, IIcuAnalyzer
	{
		public IcuAnalyzer() : base("icu_analyzer") { }

		/// <inheritdoc />
		public IcuNormalizationType? Method { get; set; }

		/// <inheritdoc />
		public IcuNormalizationMode? Mode { get; set; }
	}

	/// <inheritdoc cref="IIcuAnalyzer" />
	public class IcuAnalyzerDescriptor : AnalyzerDescriptorBase<IcuAnalyzerDescriptor, IIcuAnalyzer>, IIcuAnalyzer
	{
		protected override string Type => "icu_analyzer";

		IcuNormalizationType? IIcuAnalyzer.Method { get; set; }
		IcuNormalizationMode? IIcuAnalyzer.Mode { get; set; }

		/// <inheritdoc cref="IIcuAnalyzer.Method"/>
		public IcuAnalyzerDescriptor Method(IcuNormalizationType? method) => Assign(method, (a, v) => a.Method = v);

		/// <inheritdoc cref="IIcuAnalyzer.Mode"/>
		public IcuAnalyzerDescriptor Mode(IcuNormalizationMode? mode) => Assign(mode, (a, v) => a.Mode = v);
	}
}
