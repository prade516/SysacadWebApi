using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels.Erros
{
    public class HandleMercadoErrors
    {
        #region Singleton
        private static HandleMercadoErrors _handle;
        private HandleMercadoErrors() { }

        public static HandleMercadoErrors GetInstance()
        {
            if (_handle == null)
                _handle = new HandleMercadoErrors();
            return _handle;
        }
        #endregion

        private static List<BaseMercadoError> handleErrors;

        public static List<BaseMercadoError> HandleErrors
        {
            get
            {
                if (handleErrors == null)
                    handleErrors = chargeHandlers();
                return handleErrors;
            }

            set
            {
                handleErrors = value;
            }
        }

        private static List<BaseMercadoError> chargeHandlers()
        {
            List<BaseMercadoError> he = new List<BaseMercadoError>();
            he.Add(new BadRequest());
            return he;
        }

        public string Handle(Hashtable htable)
        {
            return HandleErrors.First().Canhandle(htable);
        }
    }
}
