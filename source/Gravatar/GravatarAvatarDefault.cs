using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	[StructLayout(
		LayoutKind.Sequential)]
	public readonly struct GravatarAvatarDefault :
		IEquatable<GravatarAvatarDefault>
	{
		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault MysteryPerson =>
			new GravatarAvatarDefault(
				"mp");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault Identicon =>
			new GravatarAvatarDefault(
				"identicon");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault MonsterID =>
			new GravatarAvatarDefault(
				"monsterid");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault Wavatar =>
			new GravatarAvatarDefault(
				"wavatar");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault Retro =>
			new GravatarAvatarDefault(
				"retro");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault RoboHash =>
			new GravatarAvatarDefault(
				"robohash");

		/// <summary>
		/// 
		/// </summary>
		public static GravatarAvatarDefault Blank =>
			new GravatarAvatarDefault(
				"blank");

		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static GravatarAvatarDefault FromUrl(
			Uri url) =>
				FromUrl(
					url?.ToString());

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueA"></param>
		/// <param name="valueB"></param>
		/// <returns></returns>
		public static bool Equals(
			GravatarAvatarDefault valueA,
			GravatarAvatarDefault valueB)
		{
			return valueA.value == valueB.value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static GravatarAvatarDefault FromUrl(
			string url)
		{
			ArgumentNullException
				.ThrowIfNullOrEmpty(
					url,
					nameof(url));

			return new GravatarAvatarDefault(
				Uri.EscapeDataString(url));
		}

		private readonly string value;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		public GravatarAvatarDefault(
			string value)
		{
			this.value = value;
		}

		/// <inheritdoc />
		public bool Equals(
			GravatarAvatarDefault other) =>
				Equals(
					this,
					other);

		/// <inheritdoc />
		public override bool Equals(
			object obj)
		{
			if (obj is GravatarAvatarDefault other)
			{
				return Equals(
					this,
					other);
			}

			return false;
		}

		/// <inheritdoc />
		public override int GetHashCode() =>
			this.value
				.GetHashCode();

		/// <inheritdoc />
		public override string ToString() =>
			this.value;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueLeft"></param>
		/// <param name="valueRight"></param>
		/// <returns></returns>
		[MethodImpl(
			MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(
			GravatarAvatarDefault valueLeft,
			GravatarAvatarDefault valueRight) =>
				Equals(
					valueLeft,
					valueRight);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueLeft"></param>
		/// <param name="valueRight"></param>
		/// <returns></returns>
		[MethodImpl(
			MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(
			GravatarAvatarDefault valueLeft,
			GravatarAvatarDefault valueRight) =>
				!Equals(
					valueLeft,
					valueRight);
	}
}
