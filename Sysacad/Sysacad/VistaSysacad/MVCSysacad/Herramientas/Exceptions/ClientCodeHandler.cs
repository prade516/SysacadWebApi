using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSysacad.Herramientas.Exceptions
{
	public class ClientCodeHandler
	{
		private static ClientCodeHandler _handler;
		private ClientCodeHandler() { }

		private ClientCodeHandler ExceptionHandler;

		private Dictionary<int, string> codeExceptions;

		public Dictionary<int, string> CodeExceptions
		{
			get
			{
				if (codeExceptions == null)
					FillCodeExceptions();
				return codeExceptions;
			}

			set
			{
				codeExceptions = value;
			}
		}

		public static ClientCodeHandler GetInstance()
		{
			if (_handler == null)
				_handler = new ClientCodeHandler();
			return _handler;
		}

		private void FillCodeExceptions()
		{
			codeExceptions = new Dictionary<int, string>();
			#region Codigo Excepcion
			codeExceptions.Add(2525, "No esta completa la entidad");
			
			#endregion
		}

	}
}