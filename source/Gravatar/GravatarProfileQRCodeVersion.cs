using System;
using System.Runtime;
using System.Runtime.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public enum GravatarProfileQRCodeVersion
	{
		/// <summary>
		/// A standard QR code.
		/// </summary>
		[EnumMember(
			Value = "1")]
		Standard,

		/// <summary>
		/// A modern "small dots" QR code.
		/// </summary>
		[EnumMember(
			Value = "3")]
		Modern,
	}
}
