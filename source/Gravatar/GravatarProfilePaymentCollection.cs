using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;

namespace Gravatar
{
	/// <summary>
	/// Represents the payment methods and links for a
	/// <see cref="GravatarProfile"/>.
	/// </summary>
	public class GravatarProfilePaymentCollection
	{
		/// <summary>
		/// An array of payment URLs the user has added to their profile.
		/// </summary>
		[JsonPropertyName(
			"links")]
		public ImmutableArray<GravatarLink> Links { get; init; }

		/// <summary>
		/// An array of cryptocurrency addresses the user accepts.
		/// </summary>
		[JsonPropertyName(
			"crypto_wallets")]
		public ImmutableArray<GravatarWalletAddress> WalletAddresses { get; init; }
	}
}
