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
			var clientApiKey =
				"1453:gk-AYv3DZ64ZINh4Vk9v9zKvcbJGjf1_c4Qr9RWLkEtnkjZMlqTN5GRoejqxYLYr";

			this.gravatar =
				new GravatarService(
					clientApiKey);
		}
	}
}
