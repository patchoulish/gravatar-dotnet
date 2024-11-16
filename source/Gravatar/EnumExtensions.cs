using System;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Gravatar
{
	/// <summary>
	/// Contains extension methods for working with enumerations.
	/// </summary>
	internal static class EnumExtensions
	{

		/// <summary>
		/// Retrieves the <see cref="JsonStringEnumMemberNameAttribute.Name"/> associated with a specific enum member.
		/// </summary>
		/// <typeparam name="TEnum">
		/// The type of the enumeration.
		/// </typeparam>
		/// <param name="value">
		/// The enum member whose associated <see cref="JsonStringEnumMemberNameAttribute.Name"/> is retrieved.
		/// </param>
		/// <returns>
		/// The string value associated with the specified enum member via the <see cref="JsonStringEnumMemberNameAttribute.Name"/>.
		/// Returns <c>null</c> if no attribute is found.
		/// </returns>
		public static string ToMemberName<TEnum>(
			this TEnum value)
				where TEnum :
					struct,
					Enum
		{
			return typeof(TEnum)
				.GetMember(value.ToString())
				.FirstOrDefault()?
				.GetCustomAttribute<JsonStringEnumMemberNameAttribute>()?
				.Name;
		}
	}
}
