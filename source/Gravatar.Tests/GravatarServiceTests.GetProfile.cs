using System;
using System.Threading;
using System.Threading.Tasks;

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
	}
}
