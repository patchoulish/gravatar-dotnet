using System;

using Microsoft;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Gravatar.TagHelpers
{
	/// <summary>
	/// 
	/// </summary>
	[HtmlTargetElement(
		"img",
		Attributes =
			"gravatar-profile-qrcode")]
	public class GravatarProfileQRCodeTagHelper :
		TagHelper
	{
		/// <summary>
		/// 
		/// </summary>
		private const int DefaultSize =
			256;

		/// <summary>
		/// 
		/// </summary>
		[HtmlAttributeName(
			"gravatar-email-address")]
		public string EmailAddress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[HtmlAttributeName(
			"gravatar-size")]
		public int Size { get; set; } =
			DefaultSize;

		/// <summary>
		/// 
		/// </summary>
		[HtmlAttributeName(
			"gravatar-type")]
		public GravatarProfileQRCodeType? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[HtmlAttributeName(
			"gravatar-version")]
		public GravatarProfileQRCodeVersion? Version { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="output"></param>
		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			if (EmailAddress != default)
			{
				var profileQRCodeUrl =
					GravatarHelper
						.GetProfileQRCodeUrl(
							EmailAddress,
							Size,
							Type,
							Version);

				output.Attributes
					.SetAttribute(
						"src",
						profileQRCodeUrl);

				output.Attributes
					.SetAttribute(
						"width",
						Size);

				output.Attributes
					.SetAttribute(
						"height",
						Size);
			}

			output.Attributes
				.RemoveAll(
					"gravatar-*");
		}
	}
}
