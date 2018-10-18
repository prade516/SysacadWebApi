using System;

namespace SolveApi.Error
{
	public class ApiBusinessExceptionHandler : BaseExceptionErrorHandler
	{
		static ApiBusinessExceptionHandler _instance;
		private ApiBusinessExceptionHandler() { }
		public static ApiBusinessExceptionHandler GetInstance()
		{
			if (_instance == null)
				_instance = new ApiBusinessExceptionHandler();
			return _instance;
		}
		public override IApiExceptions HandleExceptions(Exception ex)
		{
			if (ex is ApiBusinessException)
				return (ApiBusinessException)ex;
			return Mychainhandler.HandleExceptions(ex);
		}
	}
}