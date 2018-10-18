using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace MVCPeaton.MercadoModels.Builder
{
    public interface IDirectorPack
    {
        void Build();
        MercadoPack GetPack();
        void Build(string name = "", string email = "", string surname = "", string street_name = "", int street_number = 0,
       string zip_code = "", string type = "", string number = "", string area_code = "", string numberphone = "");
    }
}