using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar
{
	partial class GravatarServiceTests
	{
		/// <summary>
		/// 
		/// </summary>
		public static IEnumerable<object[]> GetProfileTestData =>
			[
				[
					"05ccee223d9e152175f16538714a9cf8540f4283c009c83c6c9e39c4340ce89d"
				],
				[
					"patchoulish"
				],
			];

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GravatarService")]
		[TestCategory(
			"GetProfile")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetProfileThrowOnArgumentNullTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentNullException>(
				() => this.gravatar.GetProfileAsync(
					default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"GravatarService")]
		[TestCategory(
			"GetProfile")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public async Task GetProfileThrowOnArgumentEmptyTestAsync()
		{
			await Assert.ThrowsExceptionAsync<ArgumentException>(
				() => this.gravatar.GetProfileAsync(
					String.Empty));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashOrIdentifier"></param>
		/// <returns></returns>
		[TestCategory(
			"GravatarService")]
		[TestCategory(
			"GetProfile")]
		[TestCategory(
			"Result")]
		[DataTestMethod]
		[DynamicData(
			nameof(GetProfileTestData))]
		public async Task GetProfileTestAsync(
			string hashOrIdentifier)
		{
			// Sleep for a bit to not stress Gravatar out.
			Task.Delay(1000)
				.Wait();

			var profile =
				await this.gravatar
					.GetProfileAsync(
						hashOrIdentifier);

			Assert.IsNotNull(
				profile);

			Assert.IsNotNull(
				profile.AvatarUrl);
		}
	}
}
