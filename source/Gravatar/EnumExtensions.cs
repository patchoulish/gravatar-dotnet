using System;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;
using System.Reflection;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	internal static class EnumExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToMemberValue<TEnum>(
			this TEnum value)
				where TEnum :
					struct,
					Enum
		{
			return typeof(TEnum)
				.GetMember(value.ToString())
				.FirstOrDefault()?
				.GetCustomAttribute<EnumMemberAttribute>()?
				.Value;
		}
	}
}
