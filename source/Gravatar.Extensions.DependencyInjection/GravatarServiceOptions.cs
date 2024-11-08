using System;

using Microsoft;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Gravatar
{
	/// <summary>
	/// Represents the options when registering an instance of the <see cref="GravatarService"/>
	/// class with an <see cref="IServiceCollection"/>.
	/// </summary>
	public sealed class GravatarServiceOptions
	{
		/// <summary>
		/// Gets or sets the base URL to use.
		/// </summary>
		public Uri BaseUrl { get; set; } =
			GravatarService.DefaultBaseUrl;

		/// <summary>
		/// Gets or sets the API key to use.
		/// </summary>
		/// <remarks>
		/// Using an API key is optional.
		/// </remarks>
		public string ApiKey { get; set; }
	}
}
