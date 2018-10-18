using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveApi.Error
{
	public abstract class  BaseExceptionErrorHandler
	{
		private BaseExceptionErrorHandler mychainhandler;

		public BaseExceptionErrorHandler Mychainhandler
		{
			get
			{
				return mychainhandler;
			}

			set
			{
				mychainhandler = value;
			}
		}

		public abstract IApiExceptions HandleExceptions(Exception ex);
	}
}
