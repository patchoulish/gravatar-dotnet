using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarProfilePaymentCollection
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"links")]
		public ImmutableArray<GravatarLink> Links { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"crypto_wallets")]
		public ImmutableArray<GravatarWalletAddress> WalletAddresses { get; init; }
	}
}
