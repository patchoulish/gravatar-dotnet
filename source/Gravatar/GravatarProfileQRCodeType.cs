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
		typeof(JsonStringEnumConverter<GravatarProfileQRCodeType>))]
	public enum GravatarProfileQRCodeType
	{
		/// <summary>
		/// No user avatar or Gravatar logo.
		/// </summary>
		[JsonStringEnumMemberName(
			"default")]
		None,

		/// <summary>
		/// The user's avatar.
		/// </summary>
		[JsonStringEnumMemberName(
			"user")]
		Avatar,

		/// <summary>
		/// The Gravatar logo.
		/// </summary>
		[JsonStringEnumMemberName(
			"gravatar")]
		Logo,
	}
}
