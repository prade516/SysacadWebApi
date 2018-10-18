using System.Net;

namespace SolveApi.Error
{
	public interface IApiExceptions
	{
		int ErrorCode { get; set; }
		/// <summary>
		/// ErrorDescription
		/// </summary>
		string ErrorDescription { get; set; }
		/// <summary>
		/// HttpStatus
		/// </summary>
		HttpStatusCode HttpStatus { get; set; }
		/// <summary>
		/// ReasonPhrase
		/// </summary>
		string ReasonPhrase { get; set; }

		string ReferenceLink { get; set; }
	}
}