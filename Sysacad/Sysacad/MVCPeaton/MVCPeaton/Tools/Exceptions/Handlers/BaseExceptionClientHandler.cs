using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Tools.Exceptions.Handlers
{
    public abstract class BaseExceptionClientHandler:Exception
    {
        private BaseExceptionClientHandler mychainhandler;

        public BaseExceptionClientHandler Mychainhandler
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

        public abstract CompositeFillErrors HandleExceptions(Exception ex);

        public abstract CompositeFillErrors Run(Exception ex);
    }
}