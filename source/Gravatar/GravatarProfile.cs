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
	/// 
	/// </summary>
	public class GravatarProfile
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"hash")]
		public string EmailAddressHash { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"display_name")]
		public string DisplayName { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"profile_url")]
		public Uri ProfileUrl { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"avatar_url")]
		public Uri AvatarUrl { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"avatar_alt_text")]
		public string AvatarAltText { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"location")]
		public string Location { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"description")]
		public string Description { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"job_title")]
		public string JobTitle { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"company")]
		public string Company { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"pronunciation")]
		public string Pronunciation { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"pronouns")]
		public string Pronouns { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"last_profile_edit")]
		public DateTime? LastModifiedDate { get; init; }

		/// <summary>
		/// 
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
		/// 
		/// </summary>
		[JsonPropertyName(
			"verified_accounts")]
		public ImmutableArray<GravatarProfileAccount> VerifiedAccounts { get; init; }

		/// <summary>
		/// 
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
