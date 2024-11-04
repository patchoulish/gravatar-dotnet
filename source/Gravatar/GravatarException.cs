using System;
using System.Net;

namespace Gravatar
{
	/// <summary>
	/// 
	/// </summary>
	public class GravatarException :
		Exception
	{
		/// <summary>
		/// 
		/// </summary>
		public HttpStatusCode? StatusCode { get; private init; }

		/// <summary>
		/// 
		/// </summary>
		public GravatarException() :
				this(
					default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="statusCode"></param>
		public GravatarException(
			HttpStatusCode statusCode) :
				this(
					statusCode,
					default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="message"></param>
		public GravatarException(
			HttpStatusCode statusCode,
			string message) :
				this(
					statusCode,
					message,
					default)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public GravatarException(
			HttpStatusCode statusCode,
			string message,
			Exception innerException) :
				base(
					message,
					innerException)
		{
			StatusCode = statusCode;
		}
	}
}
