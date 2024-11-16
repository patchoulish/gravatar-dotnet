using System;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar.Extensions.DependencyInjection
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed class ServiceCollectionExtensionsTests
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"ServiceCollectionExtensions")]
		[TestCategory(
			"AddGravatarHttpClient")]
		[TestCategory(
			"Argument")]
		[TestMethod]
		public void AddGravatarHttpClientThrowOnArgumentNullTest()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => ServiceCollectionExtensions
					.AddGravatarHttpClient(
						default));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[TestCategory(
			"ServiceCollectionExtensions")]
		[TestCategory(
			"AddGravatarHttpClient")]
		[TestCategory(
			"Result")]
		[TestMethod]
		public void AddGravatarHttpClientTest()
		{
			var services =
				new ServiceCollection();

			services.AddGravatarHttpClient(
				(options) =>
				{
					options.ApiKey =
						Environment.GetEnvironmentVariable(
							"GRAVATAR_API_KEY");
				});

			var serviceProvider =
				services.BuildServiceProvider();

			var gravatar =
				serviceProvider.GetService<IGravatarService>();

			Assert.IsNotNull(
				gravatar);
		}
	}
}
