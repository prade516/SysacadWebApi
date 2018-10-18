using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels.Erros
{
    public class ErrorApiResponse
    {
        public string Error { get; set; }
        public string Status { get; set; }
        public string ApiMessage { get; set; }
        public int InternalCode { get; set; }
        public string Message { get; set; }
    }
}
