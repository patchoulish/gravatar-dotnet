using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Gravatar
{
	/// <summary>
	/// Describes a user’s profile information.
	/// </summary>
	public class GravatarProfile
	{
		/// <summary>
		/// The SHA256 hash of the user’s primary email address.
		/// </summary>
		[JsonPropertyName(
			"hash")]
		public string EmailAddressHash { get; init; }

		/// <summary>
		/// The user’s display name that appears on their profile.
		/// </summary>
		[JsonPropertyName(
			"display_name")]
		public string DisplayName { get; init; }

		/// <summary>
		/// The full URL to the user’s Gravatar profile.
		/// </summary>
		[JsonPropertyName(
			"profile_url")]
		public Uri ProfileUrl { get; init; }

		/// <summary>
		/// The URL to the user’s avatar image, if set.
		/// </summary>
		[JsonPropertyName(
			"avatar_url")]
		public Uri AvatarUrl { get; init; }

		/// <summary>
		/// Alternative text describing the user’s avatar.
		/// </summary>
		[JsonPropertyName(
			"avatar_alt_text")]
		public string AvatarAltText { get; init; }

		/// <summary>
		/// The user’s geographical location.
		/// </summary>
		[JsonPropertyName(
			"location")]
		public string Location { get; init; }

		/// <summary>
		/// A short biography or description about the user found on their profile.
		/// </summary>
		[JsonPropertyName(
			"description")]
		public string Description { get; init; }

		/// <summary>
		/// The user’s current job title.
		/// </summary>
		[JsonPropertyName(
			"job_title")]
		public string JobTitle { get; init; }

		/// <summary>
		/// The name of the company where the user is employed.
		/// </summary>
		[JsonPropertyName(
			"company")]
		public string Company { get; init; }

		/// <summary>
		/// A phonetic guide to pronouncing the user’s name.
		/// </summary>
		[JsonPropertyName(
			"pronunciation")]
		public string Pronunciation { get; init; }

		/// <summary>
		/// The pronouns the user prefers to use.
		/// </summary>
		[JsonPropertyName(
			"pronouns")]
		public string Pronouns { get; init; }

		/// <summary>
		/// The date and time (UTC) when the user last edited their profile.
		/// </summary>
		[JsonPropertyName(
			"last_profile_edit")]
		public DateTime? LastModifiedDate { get; init; }

		/// <summary>
		/// The date the user registered their account.
		/// </summary>
		[JsonPropertyName(
			"registration_date")]
		public DateTime? RegistrationDate {  get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"links")]
		public ImmutableArray<GravatarLink> Links { get; init; }

		/// <summary>
		/// An array of verified accounts the user has added to their profile.
		/// </summary>
		[JsonPropertyName(
			"verified_accounts")]
		public ImmutableArray<GravatarProfileAccount> VerifiedAccounts { get; init; }

		/// <summary>
		/// The total number of verified accounts the user has added to their profile,
		/// including those not displayed on their profile.
		/// </summary>
		[JsonPropertyName(
			"number_verified_accounts")]
		public int VerifiedAccountsCount { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"payments")]
		public GravatarProfilePaymentCollection Payment { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"gallery")]
		public ImmutableArray<GravatarImage> GalleryImages {  get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"timezone")]
		public string TimeZone { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"first_name")]
		public string FirstName { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"last_name")]
		public string LastName { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"is_organization")]
		public bool? IsOrganization { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"background_color")]
		public string BackgroundColor { get; init; }
	}
}
