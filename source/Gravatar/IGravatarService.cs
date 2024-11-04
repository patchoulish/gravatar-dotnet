using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGravatarService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashOrIdentifier"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<GravatarProfile> GetProfileAsync(
			string hashOrIdentifier,
			CancellationToken cancellationToken = default);
	}
}
