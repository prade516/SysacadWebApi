using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels.Erros
{
    public abstract class BaseMercadoError
    {

        public abstract String Message();
        public abstract string Canhandle(Hashtable htable);
    }
}
