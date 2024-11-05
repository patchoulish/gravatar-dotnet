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
            "[gravatar-avatar]")]
    public class GravatarAvatarImageTagHelper :
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
            "gravatar-default")]
        public GravatarAvatarDefault? DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [HtmlAttributeName(
            "gravatar-force-default")]
        public bool? ForceDefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [HtmlAttributeName(
            "gravatar-rating")]
        public GravatarAvatarRating? Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [HtmlAttributeName(
            "gravatar-with-file-extension")]
        public bool? WithFileExtension { get; set; }

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
                var avatarUrl =
                    GravatarHelper
                        .GetAvatarUrl(
                            EmailAddress,
                            Math.Max(
                                Width ?? 64,
                                Height ?? 64),
                            DefaultValue,
                            ForceDefaultValue,
                            Rating,
                            WithFileExtension);

                output.Attributes
                    .SetAttribute(
                        "src",
                        avatarUrl);
            }

            output.Attributes
                .RemoveAll(
                    "gravatar-*");
        }
    }
}
