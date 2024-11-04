using System;
using System.Runtime;
using System.Runtime.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public enum GravatarAvatarRating
	{
		/// <summary>
		/// Suitable for display on all websites with any audience type.
		/// </summary>
		[EnumMember(
			Value = "g")]
		G,

		/// <summary>
		/// May contain rude gestures, provocatively dressed individuals,
		/// the lesser swear words, or mild violence.
		/// </summary>
		[EnumMember(
			Value = "pg")]
		PG,

		/// <summary>
		/// May contain such things as harsh profanity, intense violence,
		/// nudity, or hard drug use.
		/// </summary>
		[EnumMember(
			Value = "r")]
		R,

		/// <summary>
		/// May contain sexual imagery or extremely disturbing violence.
		/// </summary>
		[EnumMember(
			Value = "x")]
		X
	}
}
