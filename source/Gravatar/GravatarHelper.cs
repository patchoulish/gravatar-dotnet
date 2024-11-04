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
		/// 
		/// </summary>
		private const string BaseProfileUrlValue =
			"https://gravatar.com/";

		/// <summary>
		/// 
		/// </summary>
		private const string BaseAvatarUrlValue =
			"https://gravatar.com/avatar/";

		/// <summary>
		/// 
		/// </summary>
		public static Uri BaseProfileUrl { get; private set; } =
			new Uri(BaseProfileUrlValue);

		/// <summary>
		/// 
		/// </summary>
		public static Uri BaseAvatarUrl { get; private set; } =
			new Uri(BaseAvatarUrlValue);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static byte[] GetEmailAddressHashBytes(
			MailAddress address) =>
				GetEmailAddressHashBytes(
					address?.Address);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static byte[] GetEmailAddressHashBytes(
			string address)
		{
			ArgumentException
				.ThrowIfNullOrEmpty(
					address,
					nameof(address));

			return MD5.HashData(
				Encoding.UTF8.GetBytes(
					address
						.Trim()
						.ToLower()));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static string GetEmailAddressHash(
			MailAddress address) =>
				GetEmailAddressHash(
					address?.Address);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static string GetEmailAddressHash(
			string address)
		{
			ArgumentException
				.ThrowIfNullOrEmpty(
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
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static Uri GetProfileUrl(
			MailAddress address) =>
				GetProfileUrl(
					address?.Address);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public static Uri GetProfileUrl(
			string address)
		{
			ArgumentException
				.ThrowIfNullOrEmpty(
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
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="type"></param>
		/// <param name="version"></param>
		/// <returns></returns>
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
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="type"></param>
		/// <param name="version"></param>
		/// <returns></returns>
		public static Uri GetProfileQRCodeUrl(
			string address,
			int? size = default,
			GravatarProfileQRCodeType? type = default,
			GravatarProfileQRCodeVersion? version = default)
		{
			ArgumentException
				.ThrowIfNullOrEmpty(
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
				ArgumentOutOfRangeException
					.ThrowIfNegativeOrZero(
						size.Value,
						nameof(size));

				urlQueryParams["s"] =
					size.GetValueOrDefault();
			}

			if (type.HasValue)
			{
				urlQueryParams["type"] =
					type.GetValueOrDefault()
						.ToMemberValue();
			}

			if (version.HasValue)
			{
				urlQueryParams["version"] =
					version.GetValueOrDefault()
						.ToMemberValue();
			}

			url.Query =
				String.Join(
					"&",
					urlQueryParams
						.Select(kvp => kvp.Key + "=" + kvp.Value.ToString()));

			return url.Uri;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="defaultValue"></param>
		/// <param name="forceDefaultValue"></param>
		/// <param name="rating"></param>
		/// <param name="withFileExtension"></param>
		/// <returns></returns>
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
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="defaultValue"></param>
		/// <param name="forceDefaultValue"></param>
		/// <param name="rating"></param>
		/// <param name="withFileExtension"></param>
		/// <returns></returns>
		public static Uri GetAvatarUrl(
			string address,
			int? size = default,
			GravatarAvatarDefault? defaultValue = default,
			bool? forceDefaultValue = default,
			GravatarAvatarRating? rating = default,
			bool? withFileExtension = default)
		{
			ArgumentException
				.ThrowIfNullOrEmpty(
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
				ArgumentOutOfRangeException
					.ThrowIfNegativeOrZero(
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
						.ToMemberValue();
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
