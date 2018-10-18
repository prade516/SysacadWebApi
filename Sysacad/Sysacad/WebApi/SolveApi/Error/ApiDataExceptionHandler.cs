using System;

namespace SolveApi.Error
{
	public class ApiDataExceptionHandler : BaseExceptionErrorHandler
	{
		static ApiDataExceptionHandler _instance;
		private ApiDataExceptionHandler() { }
		public static ApiDataExceptionHandler GetInstance()
		{
			if (_instance == null)
				_instance = new ApiDataExceptionHandler();
			return _instance;
		}

		public override IApiExceptions HandleExceptions(Exception ex)
		{
			if (ex is ApiDataException)
				return (ApiDataException)ex;
			return Mychainhandler.HandleExceptions(ex);
		}
	}
}