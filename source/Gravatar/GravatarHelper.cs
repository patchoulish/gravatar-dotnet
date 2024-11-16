using System;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

namespace Gravatar
{
	/// <summary>
	/// Contains helper methods for hashing email addresses and assembling various Gravatar URLs.
	/// </summary>
	public static class GravatarHelper
	{
		/// <summary>
		/// The base URL for Gravatar profiles.
		/// </summary>
		private const string BaseProfileUrlValue =
			"https://gravatar.com/";

		/// <summary>
		/// The base URL for Gravatar avatars.
		/// </summary>
		private const string BaseAvatarUrlValue =
			"https://gravatar.com/avatar/";

		/// <summary>
		/// Gets the base URL for Gravatar profiles.
		/// </summary>
		public static Uri BaseProfileUrl { get; private set; } =
			new Uri(BaseProfileUrlValue);

		/// <summary>
		/// Gets the base URL for Gravatar avatars.
		/// </summary>
		public static Uri BaseAvatarUrl { get; private set; } =
			new Uri(BaseAvatarUrlValue);

		/// <summary>
		/// Computes the MD5 hash of the specified email address and returns it as a byte array.
		/// </summary>
		/// <param name="address">The email address to hash, represented as a <see cref="MailAddress"/>.</param>
		/// <returns>A byte array containing the MD5 hash of the email address.</returns>
		public static byte[] GetEmailAddressHashBytes(
			MailAddress address) =>
				GetEmailAddressHashBytes(
					address?.Address);

		/// <summary>
		/// Computes the MD5 hash of the specified email address and returns it as a byte array.
		/// </summary>
		/// <param name="address">The email address to hash.</param>
		/// <returns>A byte array containing the MD5 hash of the email address.</returns>
		public static byte[] GetEmailAddressHashBytes(
			string address)
		{
			Guard.NotNullOrEmpty(
				address,
				nameof(address));

			using var md5 = MD5.Create();

			return md5.ComputeHash(
				Encoding.UTF8.GetBytes(
					address
						.Trim()
						.ToLower()));
		}

		/// <summary>
		/// Computes the MD5 hash of the specified email address and returns it as a hexadecimal string.
		/// </summary>
		/// <param name="address">The email address to hash, represented as a <see cref="MailAddress"/>.</param>
		/// <returns>A hexadecimal string representing the MD5 hash of the email address.</returns>
		public static string GetEmailAddressHash(
			MailAddress address) =>
				GetEmailAddressHash(
					address?.Address);

		/// <summary>
		/// Computes the MD5 hash of the specified email address and returns it as a hexadecimal string.
		/// </summary>
		/// <param name="address">The email address to hash.</param>
		/// <returns>A hexadecimal string representing the MD5 hash of the email address.</returns>
		public static string GetEmailAddressHash(
			string address)
		{
			Guard.NotNullOrEmpty(
				address,
				nameof(address));

			var addressHashBytes =
				GetEmailAddressHashBytes(
					address);

			var stringBuilder = new StringBuilder(32);
			foreach (var addressHashByte in addressHashBytes)
			{
				stringBuilder.Append(
					addressHashByte.ToString(
						"x2"));
			}

			return stringBuilder.ToString();
		}

		/// <summary>
		/// Constructs a Gravatar profile URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address represented as a <see cref="MailAddress"/>.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar profile URL.</returns>
		public static Uri GetProfileUrl(
			MailAddress address) =>
				GetProfileUrl(
					address?.Address);

		/// <summary>
		/// Constructs a Gravatar profile URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address to create a profile URL for.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar profile URL.</returns>
		public static Uri GetProfileUrl(
			string address)
		{
			Guard.NotNullOrEmpty(
				address,
				nameof(address));

			var addressHash =
				GetEmailAddressHash(
					address);

			var url =
				new UriBuilder(
					BaseProfileUrlValue +
					addressHash +
					".json");

			return url.Uri;
		}

		/// <summary>
		/// Constructs a Gravatar QR code URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address as a <see cref="MailAddress"/>.</param>
		/// <param name="size">Optional QR code size.</param>
		/// <param name="type">Optional QR code type.</param>
		/// <param name="version">Optional QR code version.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar QR code URL.</returns>
		public static Uri GetProfileQRCodeUrl(
			MailAddress address,
			int? size = default,
			GravatarProfileQRCodeType? type = default,
			GravatarProfileQRCodeVersion? version = default) =>
				GetProfileQRCodeUrl(
					address?.Address,
					size,
					type,
					version);

		/// <summary>
		/// Constructs a Gravatar QR code URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address to create a QR code URL for.</param>
		/// <param name="size">Optional QR code size.</param>
		/// <param name="type">Optional QR code type.</param>
		/// <param name="version">Optional QR code version.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar QR code URL.</returns>
		public static Uri GetProfileQRCodeUrl(
			string address,
			int? size = default,
			GravatarProfileQRCodeType? type = default,
			GravatarProfileQRCodeVersion? version = default)
		{
			Guard.NotNullOrEmpty(
				address,
				nameof(address));

			var addressHash =
				GetEmailAddressHash(
					address);

			var url =
				new UriBuilder(
					BaseProfileUrlValue +
					addressHash +
					".qr");

			var urlQueryParams =
				new Dictionary<string, object>();

			if (size.HasValue)
			{
				Guard.NotNegativeOrZero(
					size.Value,
					nameof(size));

				urlQueryParams["s"] =
					size.GetValueOrDefault();
			}

			if (type.HasValue)
			{
				urlQueryParams["type"] =
					type.GetValueOrDefault()
						.ToMemberName();
			}

			if (version.HasValue)
			{
				urlQueryParams["version"] =
					version.GetValueOrDefault()
						.ToMemberName();
			}

			url.Query =
				String.Join(
					"&",
					urlQueryParams
						.Select(kvp => kvp.Key + "=" + kvp.Value.ToString()));

			return url.Uri;
		}

		/// <summary>
		/// Constructs a Gravatar avatar URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address as a <see cref="MailAddress"/>.</param>
		/// <param name="size">Optional avatar size.</param>
		/// <param name="defaultValue">Optional default avatar type.</param>
		/// <param name="forceDefaultValue">Optional parameter to force the default avatar.</param>
		/// <param name="rating">Optional avatar rating.</param>
		/// <param name="withFileExtension">Whether to append the file extension to the URL.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar avatar URL.</returns>
		public static Uri GetAvatarUrl(
			MailAddress address,
			int? size = default,
			GravatarAvatarDefault? defaultValue = default,
			bool? forceDefaultValue = default,
			GravatarAvatarRating? rating = default,
			bool? withFileExtension = default) =>
				GetAvatarUrl(
					address?.Address,
					size,
					defaultValue,
					forceDefaultValue,
					rating,
					withFileExtension);

		/// <summary>
		/// Constructs a Gravatar avatar URL for the specified email address.
		/// </summary>
		/// <param name="address">The email address to create an avatar URL for.</param>
		/// <param name="size">Optional avatar size.</param>
		/// <param name="defaultValue">Optional default avatar type.</param>
		/// <param name="forceDefaultValue">Optional parameter to force the default avatar.</param>
		/// <param name="rating">Optional avatar rating.</param>
		/// <param name="withFileExtension">Whether to append the file extension to the URL.</param>
		/// <returns>A <see cref="Uri"/> representing the Gravatar avatar URL.</returns>
		public static Uri GetAvatarUrl(
			string address,
			int? size = default,
			GravatarAvatarDefault? defaultValue = default,
			bool? forceDefaultValue = default,
			GravatarAvatarRating? rating = default,
			bool? withFileExtension = default)
		{
			Guard.NotNullOrEmpty(
				address,
				nameof(address));

			var addressHash =
				GetEmailAddressHash(
					address);

			var url =
				new UriBuilder(
					BaseAvatarUrlValue +
					addressHash +
						((withFileExtension ?? false) ?
							".jpg" :
							String.Empty));

			var urlQueryParams =
				new Dictionary<string, object>();

			if (size.HasValue)
			{
				Guard.NotNegativeOrZero(
					size.Value,
					nameof(size));

				urlQueryParams["s"] =
					size.GetValueOrDefault();
			}

			if (defaultValue.HasValue)
			{
				urlQueryParams["d"] =
					defaultValue.GetValueOrDefault()
						.ToString();
			}

			if (forceDefaultValue.HasValue)
			{
				urlQueryParams["f"] =
					forceDefaultValue.GetValueOrDefault() ?
						"y" : "n";
			}

			if (rating.HasValue)
			{
				urlQueryParams["r"] =
					rating.GetValueOrDefault()
						.ToMemberName();
			}

			url.Query =
				String.Join(
					"&",
					urlQueryParams
						.Select(kvp => kvp.Key + "=" + kvp.Value.ToString()));

			return url.Uri;
		}
	}
}
