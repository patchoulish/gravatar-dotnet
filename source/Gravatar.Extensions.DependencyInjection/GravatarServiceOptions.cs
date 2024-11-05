using System;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class GravatarServiceOptions
	{
		/// <summary>
		/// 
		/// </summary>
		public Uri BaseUrl { get; set; } =
			GravatarService.DefaultBaseUrl;

		/// <summary>
		/// 
		/// </summary>
		public string ApiKey { get; set; }
	}
}
