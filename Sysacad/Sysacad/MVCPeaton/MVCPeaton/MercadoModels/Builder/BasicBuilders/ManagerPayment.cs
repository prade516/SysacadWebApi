using mercadopago;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels.Erros;

namespace MVCPeaton.MercadoModels
{
    public class ManagerPayment
    {
        //private readonly string CLIENT_ID = "8511651942961923";
        //private readonly string CLIENT_SECRET = "8oCnDoWcv32nED11OzKGZ7TifWUKJ506";

        private readonly string CLIENT_ID = "8511651942961923";
        private readonly string CLIENT_SECRET = "8oCnDoWcv32nED11OzKGZ7TifWUKJ506";
        private readonly string PUBLIC_KEY = "TEST-8511651942961923-040513-e7af1f891e8bc13bf83d41ec4f29ce0a__LB_LD__-25061445";

        //        Utiliza las credenciales de tu aplicación: 25061445 - MercadoPago application
        //SHORT_NAME: mp-app-25061445
        //CLIENT_ID: 8511651942961923
        //CLIENT_SECRET: 8oCnDoWcv32nED11OzKGZ7TifWUKJ506
        public void Pay(string preferences)
        {
            try
            {
                MP mp = new MP("8511651942961923", "8oCnDoWcv32nED11OzKGZ7TifWUKJ506");
                //MP mp = new MP(ACCESS_TOKEN);
                //String accessToken = mp.getAccessToken();

                mp.sandboxMode(true);
                //Hashtable preference = mp.createPreference(("{\"items\":[{\"title\":\"sdk-dotnet\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":10.5}]}"));
                Hashtable preference = mp.createPreference(preferences);


                string status = preference["status"].ToString();
                if (status != "200" && status != "201")
                {
                    string mess = HandleMercadoErrors.GetInstance().Handle(preference);
                }
                Hashtable response = (Hashtable)preference["response"];


                Console.WriteLine(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Pay()
        {
            try
            {
                MP mp = new MP("8511651942961923", "8oCnDoWcv32nED11OzKGZ7TifWUKJ506");
                //MP mp = new MP(ACCESS_TOKEN);


                mp.sandboxMode(true);
                Hashtable preference = mp.createPreference(("{\"items\":[{\"title\":\"sdk-dotnet\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":10.5}]}"));
                //Hashtable preference = mp.createPreference(preferences);


                string status = preference["status"].ToString();
                Hashtable response = (Hashtable)preference["response"];


                Console.WriteLine(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Hashtable GetPayment(string id)
        {
            MP mp = new MP("8511651942961923", "8oCnDoWcv32nED11OzKGZ7TifWUKJ506");
            mp.sandboxMode(true);

            Hashtable preference2 = mp.getPreference(id);

            //Hashtable payment_info = mp.getPaymentInfo("");
            string status = preference2["status"].ToString();
            Hashtable response = (Hashtable)preference2["response"];
            return response;

        }
    }
}