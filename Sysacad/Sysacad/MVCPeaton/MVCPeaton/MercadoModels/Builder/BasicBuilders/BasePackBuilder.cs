using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace MVCPeaton.MercadoModels.Builder
{
    public abstract class BasePackBuilder : IPackBuilder
    {
        protected MercadoPack _pack;
        public BasePackBuilder()
        {
            _pack = new MercadoPack();
        }
        public virtual void BuildBackUrls()
        {
            _pack.back_urls = new MercadoBackUrls()
            {
                failure = "!!$$##",
                pending = "Está pendiente",
                success = "Http://localhost.com"
            };
        }
        public virtual void BuildItems()
        {
            _pack.items = new List<MercadoItem>();
            _pack.items.Add(new MercadoItem()
                {
                    category_id = "categoria1",
                    currency_id = "AR",
                    description = "Mi descripción",
                    id = "1",
                    picture_url = "http://img.soundtrackcollector.com/cd/large/Star_Wars_DWQ6090.jpg",
                    quantity = 22,
                    title = "Supertítulo",
                    unit_price = 40
                });
        }

        public virtual void BuildPayers(string name = "", string email = "", string surname = "", string street_name = "", int street_number = 0,
       string zip_code = "", string type = "", string number = "", string area_code = "", string numberphone = "")
        {
            _pack.payer = new MercadoPayer()
            {
                identification = new ClientIdentification() { number=number, type=type },
                phone = new ClientPhone() { area_code=area_code, number=numberphone },
                address = new ClientAddress() { street_name=street_name, street_number=street_number, zip_code=zip_code },
                date_created = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T12:00:00.000-04:00",
                email = email,
                name = name,
                surname = surname
            };
        }

        public virtual void BuildPaymentsMethods()
        {
            _pack.payment_methods = new MercadoPaymentsMethods()
            {
                default_installments = null,
                default_payment_method_id = null,
                installments = 12,
                //excluded_payment_methods = new List<MercadoExcludedPaymentsMethods>()
                //  {
                //       new MercadoExcludedPaymentsMethods() { id="amex" }
                //  },
                //excluded_payment_types = new List<MercadoExcludedPaymentTypes>()
                // {
                //      new MercadoExcludedPaymentTypes() { payment_type_id="atm" }
                // }
            };
        }

        public virtual void DefinePack()
        {
            string timefrom = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T12:00:00.000-04:00";
            string timeto = DateTime.Now.AddDays(3).Year + "-" + DateTime.Now.AddDays(3).Month + "-" + DateTime.Now.AddDays(3).Day + "T12:00:00.000-04:00";
            _pack.auto_return = "approved";
            _pack.expiration_date_from = timefrom;
            _pack.expiration_date_to = timeto;
            _pack.expires = true;
            _pack.notification_url = "Página de notificación";
            _pack.external_reference = "Referencia externa";
        }

        public MercadoPack GetPack()
        {
            return _pack;
        }
    }
}