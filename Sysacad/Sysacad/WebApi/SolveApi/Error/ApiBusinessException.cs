using System;
using System.Net;
using System.Runtime.Serialization;

namespace SolveApi.Error
{
	public class ApiBusinessException : Exception, IApiExceptions
	{
		#region Public Serializable properties.
		[DataMember]
		public int ErrorCode { get; set; }
		[DataMember]
		public string ErrorDescription { get; set; }
        //[DataMember]
        //public string Message { get; set; }
        [DataMember]
		public HttpStatusCode HttpStatus { get; set; }

		string reasonPhrase;

		[DataMember]
		public string ReasonPhrase
		{

			get
			{

				return this.HttpStatus.ToString();
			}

			set { this.reasonPhrase = value; }
		}
		#endregion
		[DataMember]
		public string ReferenceLink { get; set; }


		#region Public Constructor.
		/// <summary>
		/// Public constructor for Api Business Exception
		/// </summary>
		/// <param name="errorCode"></param>
		/// <param name="errorDescription"></param>
		/// <param name="httpStatus"></param>
		public ApiBusinessException(int errorCode, string errorDescription, HttpStatusCode httpStatus, string referenceLink)
		{
			ErrorCode = errorCode;
			ErrorDescription = errorDescription;
            //Message = errorDescription;
            HttpStatus = httpStatus;
			ReferenceLink = referenceLink;
		}
		#endregion
	}
}