using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed class GravatarHelperTests
	{
		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetEmailAddressHashBytesTestData =>
			[
				[
					"self@patchouli.sh",
					new byte[] { 252, 114, 73, 27, 133, 30, 239, 4, 152, 24, 47, 48, 154, 167, 28, 183 }
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetEmailAddressHashTestData =>
			[
				[
					"self@patchouli.sh",
					"fc72491b851eef0498182f309aa71cb7"
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetProfileUrlTestData =>
			[
				[
					"self@patchouli.sh",
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.json")
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetProfileQRCodeUrlTestData =>
			[
				[
					"self@patchouli.sh",
					default(int?),
					default(GravatarProfileQRCodeType?),
					default(GravatarProfileQRCodeVersion?),
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarProfileQRCodeType.None,
					default(GravatarProfileQRCodeVersion?),
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr?type=default")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarProfileQRCodeType.Avatar,
					default(GravatarProfileQRCodeVersion?),
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr?type=user")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarProfileQRCodeType.Logo,
					default(GravatarProfileQRCodeVersion?),
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr?type=gravatar")
				],
				[
					"self@patchouli.sh",
					default(int?),
					default(GravatarProfileQRCodeType?),
					GravatarProfileQRCodeVersion.Modern,
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr?version=3")
				],
				[
					"self@patchouli.sh",
					default(int?),
					default(GravatarProfileQRCodeType?),
					GravatarProfileQRCodeVersion.Standard,
					new Uri("https://gravatar.com/fc72491b851eef0498182f309aa71cb7.qr?version=1")
				],
			];

		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetAvatarUrlTestData =>
			[
				[
					"self@patchouli.sh",
					default(int?),
					default(string),
					default(bool?),
					default(GravatarAvatarRating?),
					default(bool?),
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarAvatarDefault.Identicon
						.ToString(),
					default(bool?),
					default(GravatarAvatarRating?),
					default(bool?),
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7?d=identicon")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarAvatarDefault.Identicon
						.ToString(),
					false,
					default(GravatarAvatarRating?),
					default(bool?),
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7?d=identicon&f=n")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarAvatarDefault.Identicon
						.ToString(),
					true,
					default(GravatarAvatarRating?),
					default(bool?),
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7?d=identicon&f=y")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarAvatarDefault.Identicon
						.ToString(),
					true,
					GravatarAvatarRating.G,
					default(bool?),
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7?d=identicon&f=y&r=g")
				],
				[
					"self@patchouli.sh",
					default(int?),
					GravatarAvatarDefault.Identicon
						.ToString(),
					true,
					default(GravatarAvatarRating?),
					true,
					new Uri("https://gravatar.com/avatar/fc72491b851eef0498182f309aa71cb7.jpg?d=identicon&f=y")
				],
			];

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHashBytes")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetEmailAddressHashBytesThrowWhenNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => GravatarHelper
					.GetEmailAddressHashBytes(
						default(string)));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHashBytes")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetEmailAddressHashBytesThrowWhenEmpty()
		{
			Assert.ThrowsException<ArgumentException>(
				() => GravatarHelper
					.GetEmailAddressHashBytes(
						String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHash")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetEmailAddressHashThrowWhenNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => GravatarHelper
					.GetEmailAddressHash(
						default(string)));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHash")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetEmailAddressHashThrowWhenEmpty()
		{
			Assert.ThrowsException<ArgumentException>(
				() => GravatarHelper
					.GetEmailAddressHash(
						String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetProfileUrlThrowWhenNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => GravatarHelper
					.GetProfileUrl(
						default(string)));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetProfileUrlThrowWhenEmpty()
		{
			Assert.ThrowsException<ArgumentException>(
				() => GravatarHelper
					.GetProfileUrl(
						String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileQRCodeUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetProfileQRCodeUrlThrowWhenNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => GravatarHelper
					.GetProfileQRCodeUrl(
						default(string)));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileQRCodeUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetProfileQRCodeUrlThrowWhenEmpty()
		{
			Assert.ThrowsException<ArgumentException>(
				() => GravatarHelper
					.GetProfileQRCodeUrl(
						String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetAvatarUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetAvatarUrlThrowWhenNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => GravatarHelper
					.GetAvatarUrl(
						default(string)));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetAvatarUrl")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void GetAvatarUrlThrowWhenEmpty()
		{
			Assert.ThrowsException<ArgumentException>(
				() => GravatarHelper
					.GetAvatarUrl(
						String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="expectedAddressHashBytes"></param>
		[TestMethod]
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHashBytes")]
		[TestCategory(
			"Result")]
		[DynamicData(
			nameof(GetEmailAddressHashBytesTestData))]
		public void GetEmailAddressHashBytesTest(
			string address,
			byte[] expectedAddressHashBytes)
		{
			var actualAddressHashBytes =
				GravatarHelper
					.GetEmailAddressHashBytes(
						address);

			for (var i = 0; i < actualAddressHashBytes.Length; i++)
			{
				Assert.AreEqual(
					expectedAddressHashBytes[i],
					actualAddressHashBytes[i]);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="expectedAddressHash"></param>
		[TestMethod]
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetEmailAddressHash")]
		[TestCategory(
			"Result")]
		[DynamicData(
			nameof(GetEmailAddressHashTestData))]
		public void GetEmailAddressHashTest(
			string address,
			string expectedAddressHash)
		{
			var actualAddressHash =
				GravatarHelper
					.GetEmailAddressHash(
						address);

			Assert.AreEqual(
				expectedAddressHash,
				actualAddressHash,
				// Gravatar is case-sensitive.
				ignoreCase: false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="expectedUrl"></param>
		[TestMethod]
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileUrl")]
		[TestCategory(
			"Result")]
		[DynamicData(
			nameof(GetProfileUrlTestData))]
		public void GetProfileUrlTest(
			string address,
			Uri expectedUrl)
		{
			var actualUrl =
				GravatarHelper
					.GetProfileUrl(
						address);

			Assert.AreEqual(
				expectedUrl,
				actualUrl);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="address"></param>
		/// <param name="size"></param>
		/// <param name="type"></param>
		/// <param name="version"></param>
		/// <param name="expectedUrl"></param>
		[TestMethod]
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetProfileQRCode")]
		[TestCategory(
			"Result")]
		[DynamicData(
			nameof(GetProfileQRCodeUrlTestData))]
		public void GetProfileQRCodeUrlTest(
			string address,
			int? size,
			GravatarProfileQRCodeType? type,
			GravatarProfileQRCodeVersion? version,
			Uri expectedUrl)
		{
			var actualUrl =
				GravatarHelper
					.GetProfileQRCodeUrl(
						address,
						size,
						type,
						version);

			Assert.AreEqual(
				expectedUrl,
				actualUrl);
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
		/// <param name="expectedUrl"></param>
		[TestMethod]
		[TestCategory(
			"GravatarHelper")]
		[TestCategory(
			"GetAvatarUrl")]
		[TestCategory(
			"Result")]
		[DynamicData(
			nameof(GetAvatarUrlTestData))]
		public void GetAvatarUrlTest(
			string address,
			int? size,
			string defaultValue,
			bool? forceDefaultValue,
			GravatarAvatarRating? rating,
			bool? withFileExtension,
			Uri expectedUrl)
		{
			var actualUrl =
				GravatarHelper
					.GetAvatarUrl(
						address,
						size,
						(defaultValue != default) ?
							new GravatarAvatarDefault(
								defaultValue) :
							null,
						forceDefaultValue,
						rating,
						withFileExtension);

			Assert.AreEqual(
				expectedUrl,
				actualUrl);
		}
	}
}
