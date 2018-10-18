using MVCPeaton.MercadoModels.Builder.CustomsBuilders.Payer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders
{
    public abstract class BaseCustomPackBuilder:ICustomPackBuilder
    {
        protected CustomMercadoPack _pack;
        public BaseCustomPackBuilder()
        {
            _pack = new CustomMercadoPack();
        }

        public virtual void BuildAdditionalInfo(string first_name="", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number=0, string zip_code = "")
        {
            _pack.additional_info = new MercadoCustomAdditionalInfo();
            _pack.additional_info.items = this.BuildItems();
            _pack.additional_info.payer = this.BuildAdditionalPayer(first_name,  last_name,  registration_date,  area_code,  number,  street_name,  street_number,  zip_code);
        }

        public abstract List<MercadoCustomItem> BuildItems();
        

        public virtual void BuildMetaData(IDictionary<string,string> metadatas = null)
        {
            _pack.metadata = new MercadoCustomMetaData();
            _pack.metadata.mydic = metadatas;
        }

        
         private MercadoCustomPayerInfo BuildAdditionalPayer(string first_name="", string last_name = "", string registration_date = ""
             , string area_code = "", string number = "", string street_name = "", int street_number=0, string zip_code = "")
        {
            CustomClientPhone ccp = new CustomClientPhone()
            {
                area_code = area_code,
                number = number
            };
            CustomClientAddress cca = new CustomClientAddress()
            { street_name = street_name, street_number = street_number, zip_code = zip_code };
            MercadoCustomPayerInfo mcp = new MercadoCustomPayerInfo(ccp, cca)
            {
                first_name = first_name,
                last_name = last_name,
                registration_date = registration_date

            };
            return mcp;

        }
    

        public virtual void BuildPayers(string email = "")
        {
            _pack.payer.email = email;
        }

        public virtual void DefinePack(decimal transactionamount,string cardtoken, string description,
            int instalmments,string payment_method_id)
        {
            _pack.external_reference = "External Reference";
            _pack.statement_descriptor = "MY E-STORE";
            _pack.notification_url = "https://www.your-site.com/webhooks";
            _pack.transaction_amount = transactionamount;
            _pack.token = cardtoken;
            _pack.description = description;
            _pack.installments = instalmments;
            _pack.payment_method_id = payment_method_id;
        }

        public CustomMercadoPack GetPack()
        {
            return _pack;
        }
    }
}