using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarImage
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }
	}
}
