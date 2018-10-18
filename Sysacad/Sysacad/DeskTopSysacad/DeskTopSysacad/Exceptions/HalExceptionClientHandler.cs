using HalClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeskTopSysacad.Exceptions
{
	public class HalExceptionClientHandler : BaseExceptionClientHandler
	{
		static HalExceptionClientHandler _instance;
		private HalExceptionClientHandler() { }
		public static HalExceptionClientHandler GetInstance()
		{
			if (_instance == null)
				_instance = new HalExceptionClientHandler();
			return _instance;
		}

		//ModelStateDictionary _modelstate { get; set; }
		//public HalExceptionClientHandler(ModelStateDictionary modelstate)
		//{
		//	_modelstate = modelstate;
		//}

		public override CompositeFillErrors HandleExceptions(Exception ex)
		{
			if (ex is AggregateException && ex.InnerException is HalHttpRequestException)
				return Run(ex);
			return Mychainhandler.HandleExceptions(ex);
		}

		public override CompositeFillErrors Run(Exception ex)
		{
			int code;
			string message = "";
			HalHttpRequestException myex = (HalHttpRequestException)ex.InnerException;
			code = Int32.Parse(myex.Resource.State.Values.First(t => t.Name.Equals("ErrorCode")).Value.ToString());
			message = myex.Resource.State.Values.First(t => t.Name.Equals("ErrorDescription")).Value;
			KeyValuePair<int, string> rowerror = ClientCodeHandler.GetInstance().CodeExceptions.FirstOrDefault(t => t.Key.Equals(code));
			CompositeFillErrors cfe = new CompositeFillErrors() { Field = rowerror.Value, Message = message };
			return cfe;
		}
	}
}