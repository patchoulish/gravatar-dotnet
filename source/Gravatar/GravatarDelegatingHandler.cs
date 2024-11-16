using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gravatar
{
	/// <summary>
	/// Represents a <see cref="DelegatingHandler"/> that treats responses as
	/// having been sent by Gravatar.
	/// </summary>
	public sealed class GravatarDelegatingHandler :
		DelegatingHandler
	{
		/// <summary>
		/// Creates a new instance of the
		/// <see cref="GravatarDelegatingHandler"/> class.
		/// </summary>
		public GravatarDelegatingHandler() :
			base()
		{ }

		/// <inheritdoc/>
		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			var httpClientResponse =
				default(HttpResponseMessage);

			try
			{
				httpClientResponse =
					await base.SendAsync(
						request,
						cancellationToken);
			}
			catch (Exception ex)
			{
				throw new GravatarException(
					"The operation was not successful.",
					ex);
			}

			if (!httpClientResponse.IsSuccessStatusCode)
			{
				throw new GravatarException(
					"The operation was not successful.",
					default,
					httpClientResponse.StatusCode);
			}

			return httpClientResponse;
		}
	}
}
