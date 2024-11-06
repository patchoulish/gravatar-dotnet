using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Represents a link the user has added to their profile.
	/// </summary>
	public class GravatarLink
	{
		/// <summary>
		/// The label for the link.
		/// </summary>
		[JsonPropertyName(
			"label")]
		public string Label { get; init; }

		/// <summary>
		/// The URL to the link.
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
