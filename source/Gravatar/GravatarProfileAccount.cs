using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Represents a verified account associated with a
	/// <see cref="GravatarProfile"/>.
	/// </summary>
	/// <remarks>
	/// The number of verified accounts returned is limited
	/// to a maximum of 4 in unauthenticated requests.
	/// </remarks>
	public class GravatarProfileAccount
	{
		/// <summary>
		/// The name of the service.
		/// </summary>
		[JsonPropertyName(
			"service_label")]
		public string ServiceLabel { get; init; }

		/// <summary>
		/// The URL to the service’s icon.
		/// </summary>
		[JsonPropertyName(
			"service_icon")]
		public Uri ServiceIconUrl { get; init; }

		/// <summary>
		/// The URL to the user’s profile on the service.
		/// </summary>
		[JsonPropertyName(
			"url")]
		public Uri Url { get; init; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>This field is not documented.</remarks>
		[JsonPropertyName(
			"service_type")]
		public string ServiceType { get; init; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>This field is not documented.</remarks>
		[JsonPropertyName(
			"is_hidden")]
		public bool IsHidden { get; init; }
	}
}
