using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
    public class MercadoPaymentsMethods
    {
        public List<MercadoExcludedPaymentsMethods> excluded_payment_methods { get; set; }
        public List<MercadoExcludedPaymentTypes> excluded_payment_types { get; set; }
        public string default_payment_method_id  { get; set; }
        public Nullable<int> installments { get; set; }
        public Nullable<int> default_installments { get; set; }
    }
}
