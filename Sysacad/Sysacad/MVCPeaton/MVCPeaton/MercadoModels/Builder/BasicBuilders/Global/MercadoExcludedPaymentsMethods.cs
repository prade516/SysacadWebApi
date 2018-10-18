using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels
{
    public class MercadoExcludedPaymentsMethods
    {
        public string id { get; set; }
       
        //        [
        //  {
        //    "id": "visa",
        //    "name": "Visa",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/visa.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/visa.gif"
        //  },
        //  {
        //    "id": "master",
        //    "name": "Mastercard",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/master.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/master.gif"
        //  },
        //  {
        //    "id": "amex",
        //    "name": "American Express",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/amex.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/amex.gif"
        //  },
        //  {
        //    "id": "naranja",
        //    "name": "Naranja",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/naranja.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/naranja.gif"
        //  },
        //  {
        //    "id": "nativa",
        //    "name": "Nativa Mastercard",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/nativa.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/nativa.gif"
        //  },
        //  {
        //    "id": "tarshop",
        //    "name": "Tarjeta Shopping",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/tarshop.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/tarshop.gif"
        //  },
        //  {
        //    "id": "cencosud",
        //    "name": "Cencosud",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/cencosud.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/cencosud.gif"
        //  },
        //  {
        //    "id": "cabal",
        //    "name": "Cabal",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/cabal.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/cabal.gif"
        //  },
        //  {
        //    "id": "diners",
        //    "name": "Diners",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/diners.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/diners.gif"
        //  },
        //  {
        //    "id": "pagofacil",
        //    "name": "Pago Fácil",
        //    "payment_type_id": "ticket",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/11.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/11.gif"
        //  },
        //  {
        //    "id": "argencard",
        //    "name": "Argencard",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/argencard.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/argencard.gif"
        //  },
        //  {
        //    "id": "maestro",
        //    "name": "Maestro",
        //    "payment_type_id": "debit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/maestro.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/maestro.gif"
        //  },
        //  {
        //    "id": "debcabal",
        //    "name": "Cabal Débito",
        //    "payment_type_id": "debit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/debabal.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/debcabal.gif"
        //  },
        //  {
        //    "id": "rapipago",
        //    "name": "Rapipago",
        //    "payment_type_id": "ticket",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/2002.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/2002.gif"
        //  },
        //  {
        //    "id": "redlink",
        //    "name": "Red Link",
        //    "payment_type_id": "atm",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/2003.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/2003.gif"
        //  },
        //  {
        //    "id": "bapropagos",
        //    "name": "Provincia NET",
        //    "payment_type_id": "ticket",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/2004.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/2004.gif"
        //  },
        //  {
        //    "id": "account_money",
        //    "name": "Dinero en mi cuenta de MercadoPago",
        //    "payment_type_id": "account_money",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/2005.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/2005.gif"
        //  },
        //  {
        //    "id": "cordial",
        //    "name": "Cordial",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/cordial.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/cordial.gif"
        //  },
        //  {
        //    "id": "cordobesa",
        //    "name": "Cordobesa",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/cordobesa.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/cordobesa.gif"
        //  },
        //  {
        //    "id": "cmr",
        //    "name": "CMR",
        //    "payment_type_id": "credit_card",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/cmr.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/cmr.gif"
        //  },
        //  {
        //    "id": "consumer_credits",
        //    "name": "Mercado Crédito",
        //    "payment_type_id": "digital_currency",
        //    "thumbnail": "http://img.mlstatic.com/org-img/MP3/API/logos/consumer_credits.gif",
        //    "secure_thumbnail": "https://www.mercadopago.com/org-img/MP3/API/logos/consumer_credits.gif"
        //  }
        //]
    }
}
