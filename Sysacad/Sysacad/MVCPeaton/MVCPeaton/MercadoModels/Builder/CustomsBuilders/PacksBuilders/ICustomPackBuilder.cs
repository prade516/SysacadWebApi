using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public interface ICustomPackBuilder
    {
        CustomMercadoPack GetPack();
        void DefinePack(decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id);
        void BuildPayers(string email = "");
        void BuildMetaData(IDictionary<string, string> metadatas =null);
        void BuildAdditionalInfo(string first_name = "", string last_name = "", string registration_date = "", string area_code = "", string number = "", string street_name = "", int street_number = 0, string zip_code = "");
        List<MercadoCustomItem> BuildItems();
        
    }
}
