using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public interface ICustomDirectorPack
    {
        CustomMercadoPack GetPack();
        void Build(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "");
    }
}
