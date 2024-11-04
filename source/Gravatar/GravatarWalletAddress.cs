using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarWalletAddress
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
			"address")]
		public string Address { get; init; }
	}
}
