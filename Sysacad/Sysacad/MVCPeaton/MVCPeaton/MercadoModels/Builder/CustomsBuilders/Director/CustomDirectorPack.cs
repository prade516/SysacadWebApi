using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders.Director
{
    public class CustomDirectorPack : ICustomDirectorPack
    {
        private BaseCustomPackBuilder _builder;
        public CustomDirectorPack(BaseCustomPackBuilder builder)
        {
            _builder = builder;
        }
        public void Build(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "")
        {
            _builder.DefinePack(transactionamount, cardtoken, description, instalmments, payment_method_id);
            _builder.BuildAdditionalInfo(first_name, last_name, registration_date,
                area_code, number, street_name, street_number, zip_code);
            //_builder.BuildItems();
            _builder.BuildMetaData(new Dictionary<string, string>());
            _builder.BuildPayers(email);
           
            
        }

        public CustomMercadoPack GetPack()
        {
            return _builder.GetPack();
        }
    }
}