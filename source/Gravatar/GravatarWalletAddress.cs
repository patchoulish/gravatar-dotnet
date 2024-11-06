using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Represents a cryptocurrency wallet address.
	/// </summary>
	public class GravatarWalletAddress
	{
		/// <summary>
		/// The label for the cryptocurrency.
		/// </summary>
		[JsonPropertyName(
			"label")]
		public string Label { get; init; }

		/// <summary>
		/// The cryptocurrency wallet address.
		/// </summary>
		[JsonPropertyName(
			"address")]
		public string Address { get; init; }
	}
}
