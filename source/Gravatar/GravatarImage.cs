using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Represents a gallery image a user has uploaded.
	/// </summary>
	public class GravatarImage
	{
		/// <summary>
		/// The URL to the image.
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
