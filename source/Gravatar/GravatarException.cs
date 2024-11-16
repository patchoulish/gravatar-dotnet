using System;
using System.Net;
using System.Net.Http;

namespace Gravatar
{
	/// <summary>
	/// Represents the exception thrown by instances of the
	/// <see cref="GravatarService"/> and <see cref="GravatarDelegatingHandler"/>
	/// classes.
	/// </summary>
	public class GravatarException :
		HttpRequestException
	{
#if NETSTANDARD

		/// <summary>
		/// Gets the HTTP status code for this exception, if any.
		/// </summary>
		public HttpStatusCode? StatusCode { get; private init; }

#endif

		/// <summary>
		/// Initializes a new instance of the <see cref="GravatarException"/>
		/// class.
		/// </summary>
		public GravatarException() :
			this(
				default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="GravatarException"/>
		/// class with a specific message that describes the current exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		public GravatarException(
			string message) :
				this(
					message,
					default)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="GravatarException"/>
		/// class with a specific message that describes the current exception
		/// and an inner exception.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		public GravatarException(
			string message,
			Exception innerException) :
				this(
					message,
					innerException,
					default)
		{ }

#if NETSTANDARD

		/// <summary>
		/// Initializes a new instance of the <see cref="GravatarException"/>
		/// class with a specific message that describes the current exception,
		/// an inner exception, and an HTTP status code.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		public GravatarException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode) :
			base(
				message,
				innerException)
		{
			StatusCode = statusCode;
		}

#endif

#if NET

		/// <summary>
		/// Initializes a new instance of the <see cref="GravatarException"/>
		/// class with a specific message that describes the current exception,
		/// an inner exception, and an HTTP status code.
		/// </summary>
		/// <param name="message">
		/// A message that describes the current exception.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		/// <param name="statusCode">
		/// The HTTP status code.
		/// </param>
		public GravatarException(
			string message,
			Exception innerException,
			HttpStatusCode? statusCode) :
			base(
				message,
				innerException,
				statusCode)
		{ }

#endif
	}
}
