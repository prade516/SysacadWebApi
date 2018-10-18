using MVCPeaton.MercadoModels.Builder.CustomsBuilders.Director;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.MercadoModels.Builder.CustomsBuilders.Manager
{
    public class ManagerCustomPacks
    {
        #region Singleton
        private ManagerCustomPacks() { }

        private static ManagerCustomPacks manPack;
        public static ManagerCustomPacks GetInstance()
        {
            if (manPack == null)
                manPack = new ManagerCustomPacks();
            return manPack;
        }
        #endregion
        private ICustomDirectorPack _directorPack;

        public string GetBasicPack(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "")
        {
            _directorPack = new CustomDirectorPack(new PackBasicBuilder());
            _directorPack.Build(email, transactionamount, cardtoken, description, instalmments, 
                payment_method_id, first_name, last_name, registration_date, area_code, number, street_name, 
                street_number, zip_code);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetSilverPack(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "")
        {
            _directorPack = new CustomDirectorPack(new PackSilverBuilder());
            _directorPack.Build(email, transactionamount, cardtoken, description, instalmments,
                payment_method_id, first_name, last_name, registration_date, area_code, number, street_name,
                street_number, zip_code);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetGoldPack(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "")
        {
            _directorPack = new CustomDirectorPack(new PackGoldBuilder());
            _directorPack.Build(email, transactionamount, cardtoken, description, instalmments,
                payment_method_id, first_name, last_name, registration_date, area_code, number, street_name,
                street_number, zip_code);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }

        public string GetPremiunPack(string email, decimal transactionamount, string cardtoken, string description,
            int instalmments, string payment_method_id, string first_name = "", string last_name = "", string registration_date = "", string area_code = "",
            string number = "", string street_name = "", int street_number = 0, string zip_code = "")
        {
            _directorPack = new CustomDirectorPack(new PackPremiumBuilder());
            _directorPack.Build(email, transactionamount, cardtoken, description, instalmments,
                payment_method_id, first_name, last_name, registration_date, area_code, number, street_name,
                street_number, zip_code);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
    }
}