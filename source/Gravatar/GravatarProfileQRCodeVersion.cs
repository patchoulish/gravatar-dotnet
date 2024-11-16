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
		typeof(JsonStringEnumConverter<GravatarProfileQRCodeVersion>))]
	public enum GravatarProfileQRCodeVersion
	{
		/// <summary>
		/// A standard QR code.
		/// </summary>
		[JsonStringEnumMemberName(
			"1")]
		Standard,

		/// <summary>
		/// A modern "small dots" QR code.
		/// </summary>
		[JsonStringEnumMemberName(
			"3")]
		Modern,
	}
}
