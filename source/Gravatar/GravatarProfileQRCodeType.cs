using System;
using System.Runtime;
using System.Runtime.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public enum GravatarProfileQRCodeType
	{
		/// <summary>
		/// No user avatar or Gravatar logo.
		/// </summary>
		[EnumMember(
			Value = "default")]
		None,

		/// <summary>
		/// The user's avatar.
		/// </summary>
		[EnumMember(
			Value = "user")]
		Avatar,

		/// <summary>
		/// The Gravatar logo.
		/// </summary>
		[EnumMember(
			Value = "gravatar")]
		Logo,
	}
}
