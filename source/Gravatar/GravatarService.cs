using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class GravatarService :
		IGravatarService
	{
		/// <summary>
		/// The default base URL for the Gravatar API.
		/// </summary>
		private const string DefaultBaseUrlValue =
			"https://api.gravatar.com/v3/";

		/// <summary>
		/// Gets the default base URL for the Gravatar API.
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(
				DefaultBaseUrlValue);

		/// <summary>
		/// 
		/// </summary>
		private static JsonSerializerOptions JsonSerializerOptions { get; } =
			new JsonSerializerOptions()
			{

			};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		/// <returns></returns>
		private static HttpClient CreateClient(
			Uri baseUrl,
			string apiKey)
		{
			ArgumentNullException
				.ThrowIfNull(
					baseUrl,
					nameof(baseUrl));

			ArgumentException
				.ThrowIfNullOrEmpty(
					apiKey,
					nameof(apiKey));

			var client =
				new HttpClient();

			client.BaseAddress =
				baseUrl;

			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue(
					"Bearer",
					apiKey);

			return client;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="response"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="GravatarException"></exception>
		private static async Task<TResult> ProcessResponseAsync<TResult>(
			HttpResponseMessage response,
			CancellationToken cancellationToken = default)
		{
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result =
					await response.Content
						.ReadFromJsonAsync<TResult>(
							JsonSerializerOptions,
							cancellationToken);

				return result;
			}
			else
			{
				throw new GravatarException(
					response.StatusCode);
			}
		}

		private readonly HttpClient httpClient;

		/// <summary>
		/// 
		/// </summary>
		public Uri BaseUrl =>
			this.httpClient
				.BaseAddress;

		/// <summary>
		/// 
		/// </summary>
		public AuthenticationHeaderValue AuthorizationHeaderValue =>
			this.httpClient
				.DefaultRequestHeaders
				.Authorization;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiKey"></param>
		public GravatarService(
			string apiKey) :
				this(
					DefaultBaseUrl,
					apiKey)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		public GravatarService(
			Uri baseUrl,
			string apiKey) :
				this(
					CreateClient(
						baseUrl,
						apiKey))
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="httpClient"></param>
		public GravatarService(
			HttpClient httpClient)
		{
			ArgumentNullException
				.ThrowIfNull(
					httpClient,
					nameof(httpClient));

			this.httpClient = httpClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashOrIdentifier"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<GravatarProfile> GetProfileAsync(
			string hashOrIdentifier,
			CancellationToken cancellationToken = default)
		{
			ArgumentException
				.ThrowIfNullOrWhiteSpace(
					hashOrIdentifier,
					nameof(hashOrIdentifier));

			if (!TryCreateProfileUrl(
				hashOrIdentifier,
				out var requestUri))
			{
				throw new InvalidOperationException(
					$"Failed to create a valid URL for the request.");
			}

			var response =
				await this.httpClient
					.GetAsync(
						requestUri,
						cancellationToken);

			return await ProcessResponseAsync<GravatarProfile>(
				response,
				cancellationToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashOrIdentifier"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		private bool TryCreateProfileUrl(
			string hashOrIdentifier,
			out Uri result) =>
				Uri.TryCreate(
					BaseUrl,
					String.Format(
						CultureInfo.InvariantCulture,
						"profiles/{0}",
						hashOrIdentifier),
					out result);
	}
}
