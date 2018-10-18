using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSysacad.Herramientas.Exceptions
{
	public class HandlerClientExceptions
	{
		private static HandlerClientExceptions _handler;
		private HandlerClientExceptions() { }

		private BaseExceptionClientHandler ExceptionHandler;

		static List<BaseExceptionClientHandler> Handlers;
		public static HandlerClientExceptions GetInstance()
		{
			if (_handler == null)
				_handler = new HandlerClientExceptions();
			return _handler;
		}

		public CompositeFillErrors RunCustomExceptions(Exception ex)
		{
			if (Handlers == null)
				FillExceptions();
			return RunExceptions(ex);
		}

		private CompositeFillErrors RunExceptions(Exception ex)
		{

			return Handlers.First().HandleExceptions(ex);
		}

		private void FillExceptions()
		{
			Handlers = new List<BaseExceptionClientHandler>();
			Handlers.Add(SecurityExceptionClientHandler.GetInstance());
			Handlers.Add(HalExceptionClientHandler.GetInstance());
			Handlers.Add(JsonHalExceptionClientHandler.GetInstance());

			BaseExceptionClientHandler _handler;
			for (int i = 0; i <= Handlers.Count(); i++)
			{
				_handler = Handlers.ElementAt(i);
				if (i + 1 == Handlers.Count())
					break;
				_handler.Mychainhandler = Handlers.ElementAt(i + 1);

			}
		}
	}
}