using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace MVCPeaton.MercadoModels.Builder
{
    public class DirectorPack:IDirectorPack
    {
        private BasePackBuilder _builder;

        public DirectorPack(BasePackBuilder builder)
        {
            _builder = builder;
        }

        public void Build()
        {
            _builder.DefinePack();
            _builder.BuildItems();
            _builder.BuildPayers();
            _builder.BuildBackUrls();
            _builder.BuildPaymentsMethods();
            ///// Validaciones del builder ej no puede haber un pagador de 1999 con método de pago efectivo.
            ///// Por ahora no hay        
        }

        public void Build(string name = "", string email = "", string surname = "", string street_name = "", int street_number = 0,
       string zip_code = "", string type = "", string number = "", string area_code = "", string numberphone = "")
        {
            _builder.DefinePack();
            _builder.BuildItems();
            _builder.BuildPayers(name, email, surname, street_name, street_number,
        zip_code, type, number, area_code, numberphone);
            _builder.BuildBackUrls();
            _builder.BuildPaymentsMethods();
            ///// Validaciones del builder ej no puede haber un pagador de 1999 con método de pago efectivo.
            ///// Por ahora no hay        
        }

        public MercadoPack GetPack()
        {
            return _builder.GetPack();
        }
    }
}