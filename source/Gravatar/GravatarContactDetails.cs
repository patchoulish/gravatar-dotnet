using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Represents the public contact information for a
	/// <see cref="GravatarProfile"/>.
	/// </summary>
	/// <remarks>
	/// Only provided in authenticated API requests.
	/// </remarks>
	public class GravatarContactDetails
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"home_phone")]
		public string HomePhone { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"work_phone")]
		public string WorkPhone { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"cell_phone")]
		public string CellPhone { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"email")]
		public string EmailAddress { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"contact_form")]
		public Uri ContactFormUrl { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[JsonPropertyName(
			"calendar")]
		public Uri CalendarUrl { get; init; }
	}
}
