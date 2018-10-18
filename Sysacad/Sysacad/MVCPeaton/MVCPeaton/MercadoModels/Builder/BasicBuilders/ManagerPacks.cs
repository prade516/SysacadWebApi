using MVCPeaton.MercadoModels.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace MVCPeaton.MercadoModels
{
    public class ManagerPacks
    {
        #region Singleton
        private ManagerPacks(){}

        private static ManagerPacks manPack;
        public static ManagerPacks GetInstance()
        {
            if (manPack == null)
                manPack = new ManagerPacks();
            return manPack;
        }
        #endregion
        private IDirectorPack _directorPack;

        public string GetBroncePack()
        {
            _directorPack = new DirectorPack(new PackBronceBuilder());
            _directorPack.Build();
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetPlatePack()
        {
            _directorPack = new DirectorPack(new PackSlverBuilder());
            _directorPack.Build();
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetGoldPack()
        {
            _directorPack = new DirectorPack(new PackGoldBuilder());
            _directorPack.Build();
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }

        public string GetBroncePack(string name, string email, string surname, string street_name, int street_number,
        string zip_code, string type, string number, string area_code,string numberphone)
        {
        _directorPack = new DirectorPack(new PackBronceBuilder());
            _directorPack.Build(name, email, surname, street_name, street_number,
        zip_code, type, number, area_code, numberphone);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetSilverPack(string name, string email, string surname, string street_name, int street_number,
        string zip_code, string type, string number, string area_code, string numberphone)
        {
            _directorPack = new DirectorPack(new PackSlverBuilder());
            _directorPack.Build(name, email, surname, street_name, street_number,
        zip_code, type, number, area_code, numberphone);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }
        public string GetGoldPack(string name, string email, string surname, string street_name, int street_number,
        string zip_code, string type, string number, string area_code, string numberphone)
        {
            _directorPack = new DirectorPack(new PackGoldBuilder());
            _directorPack.Build(name, email, surname, street_name, street_number,
        zip_code, type, number, area_code, numberphone);
            return JsonConvert.SerializeObject(_directorPack.GetPack());
        }

        
    }
}