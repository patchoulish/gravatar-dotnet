using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	[JsonConverter(
		typeof(JsonStringEnumConverter<GravatarAvatarRating>))]
	public enum GravatarAvatarRating
	{
		/// <summary>
		/// Suitable for display on all websites with any audience type.
		/// </summary>
		[JsonStringEnumMemberName(
			"g")]
		G,

		/// <summary>
		/// May contain rude gestures, provocatively dressed individuals,
		/// the lesser swear words, or mild violence.
		/// </summary>
		[JsonStringEnumMemberName(
			"pg")]
		PG,

		/// <summary>
		/// May contain such things as harsh profanity, intense violence,
		/// nudity, or hard drug use.
		/// </summary>
		[JsonStringEnumMemberName(
			"r")]
		R,

		/// <summary>
		/// May contain sexual imagery or extremely disturbing violence.
		/// </summary>
		[JsonStringEnumMemberName(
			"x")]
		X
	}
}
