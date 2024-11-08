using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>This field is not documented.</remarks>
	public class GravatarInterest
	{
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>This field is not documented.</remarks>
		[JsonPropertyName(
			"id")]
		public int? Id { get; init; }

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>This field is not documented.</remarks>
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }
	}
}
