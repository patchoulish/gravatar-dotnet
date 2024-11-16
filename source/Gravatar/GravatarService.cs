using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class GravatarService :
		IGravatarService
	{
		/// <summary>
		/// Gets the default base URL for the Gravatar API.
		/// </summary>
		public static Uri DefaultBaseUrl { get; } =
			new Uri(
				"https://api.gravatar.com/v3/");

		/// <summary>
		/// The JSON serializer options for serializing and deserializing JSON data.
		/// </summary>
		internal static JsonSerializerOptions JsonSerializerOptions { get; } =
			new JsonSerializerOptions()
			{
				DefaultIgnoreCondition = 
					JsonIgnoreCondition.WhenWritingNull
			};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="apiKey"></param>
		/// <returns></returns>
		private static HttpClient CreateHttpClient(
			Uri baseUrl,
			string apiKey)
		{
			Guard.NotNull(
				baseUrl,
				nameof(baseUrl));

			Guard.NotNullOrEmpty(
				apiKey,
				nameof(apiKey));

			var httpClient =
				new HttpClient(
					new GravatarDelegatingHandler()
					{
						InnerHandler =
							new HttpClientHandler()
					},
					disposeHandler: true);

			httpClient.BaseAddress =
				baseUrl;

			httpClient.DefaultRequestHeaders.Add(
				$"Authorization",
				$"Bearer {apiKey}");

			return httpClient;
		}

		private readonly HttpClient httpClient;

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
					CreateHttpClient(
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
			Guard.NotNull(
				httpClient,
				nameof(httpClient));

			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<GravatarProfile> GetProfileAsync(
			string hashOrIdentifier,
			CancellationToken cancellationToken = default)
		{
			Guard.NotNullOrWhiteSpace(
				hashOrIdentifier,
				nameof(hashOrIdentifier));

			// GET the request then deserialize the response and return the result.
			return await this.httpClient
				.GetFromJsonAsync<GravatarProfile>(
					$"profiles/{hashOrIdentifier}",
					JsonSerializerOptions,
					cancellationToken);
		}
	}
}
