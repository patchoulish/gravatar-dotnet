using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarLink
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"label")]
		public string Label { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
