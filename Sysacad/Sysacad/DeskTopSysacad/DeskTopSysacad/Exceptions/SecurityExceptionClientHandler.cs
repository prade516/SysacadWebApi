using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeskTopSysacad.Exceptions
{
	public class SecurityExceptionClientHandler : BaseExceptionClientHandler
	{
		static SecurityExceptionClientHandler _instance;
		private SecurityExceptionClientHandler() { }
		public static SecurityExceptionClientHandler GetInstance()
		{
			if (_instance == null)
				_instance = new SecurityExceptionClientHandler();
			return _instance;
		}
		public override CompositeFillErrors HandleExceptions(Exception ex)
		{
			if (ex is SecurityExceptionClientHandler)
				return Run(ex);
			return Mychainhandler.HandleExceptions(ex);
		}

		public override CompositeFillErrors Run(Exception ex)
		{
			SecurityExceptionClientHandler myex = (SecurityExceptionClientHandler)ex;
			return new CompositeFillErrors()
			{ Field = "general_errors", Message = ex.Message };
		}
	}
}