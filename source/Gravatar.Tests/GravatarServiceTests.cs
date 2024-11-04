using System;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public sealed partial class GravatarServiceTests
	{
		private GravatarService gravatar;

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			this.gravatar =
				new GravatarService(
					Environment.GetEnvironmentVariable(
						"GRAVATAR_API_KEY"));
		}
	}
}
