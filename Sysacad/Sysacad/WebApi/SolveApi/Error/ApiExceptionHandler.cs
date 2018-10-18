using System;

namespace SolveApi.Error
{
	public class ApiExceptionHandler : BaseExceptionErrorHandler
	{
		static ApiExceptionHandler _instance;
		private ApiExceptionHandler() { }
		public static ApiExceptionHandler GetInstance()
		{
			if (_instance == null)
				_instance = new ApiExceptionHandler();
			return _instance;
		}

		public override IApiExceptions HandleExceptions(Exception ex)
		{
			if (ex is ApiException)
				return (ApiException)ex;
			return Mychainhandler.HandleExceptions(ex);
		}
	}
}