using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		private const string GravatarHttpClientName =
			"gravatar";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		/// <param name="optionsCallback"></param>
		/// <returns></returns>
		public static IHttpClientBuilder AddGravatarHttpClient(
			this IServiceCollection services,
			Action<GravatarServiceOptions> optionsCallback = default)
		{
			ArgumentNullException
				.ThrowIfNull(
					services,
					nameof(services));

			var options =
				new GravatarServiceOptions();

			return services
				.AddHttpClient<IGravatarService, GravatarService>(
					GravatarHttpClientName,
					(httpClient) =>
					{
						// Configure the base URL for the client.
						httpClient.BaseAddress =
							options.BaseUrl;

						// NOTE: Authentication is optional.
						if (options.ApiKey != default)
						{
							// Configure the default request headers for the client.
							httpClient.DefaultRequestHeaders.Authorization =
								new AuthenticationHeaderValue(
									"Bearer",
									options.ApiKey);
						}
					});
		}
	}
}
