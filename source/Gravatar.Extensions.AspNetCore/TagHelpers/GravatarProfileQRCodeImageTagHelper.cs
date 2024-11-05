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
            "[gravatar-profile-qrcode]")]
    public class GravatarProfileQRCodeImageTagHelper :
        TagHelper
    {
        /// <summary>
        /// 
        /// </summary>
        [HtmlAttributeName(
            "width")]
        public int? Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [HtmlAttributeName(
            "height")]
        public int? Height { get; set; }

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
                            Math.Max(
                                Width ?? 64,
                                Height ?? 64),
                            Type,
                            Version);

                output.Attributes
                    .SetAttribute(
                        "src",
                        profileQRCodeUrl);
            }

            output.Attributes
                .RemoveAll(
                    "gravatar-*");
        }
    }
}
