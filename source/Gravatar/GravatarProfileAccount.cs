using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarProfileAccount
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"service_label")]
		public string ServiceLabel { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"service_icon")]
		public Uri ServiceIconUrl { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"service_type")]
		public string ServiceType { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"is_hidden")]
		public bool IsHidden { get; init; }
	}
}
