using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	[Experimental(
		"GRAVATAR_UNDOCUMENTED")]
	public class GravatarInterest
	{
		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"id")]
		public int? Id { get; init; }

		/// <summary>
		/// 
		/// </summary>
		[Experimental(
			"GRAVATAR_UNDOCUMENTED")]
		[JsonPropertyName(
			"name")]
		public string Name { get; init; }
	}
}
