using MVCPeaton.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Tools.ListResolvers
{
    public class ListResolver
    {
        #region Singleton
        private static ListResolver _listresolver;
        private ListResolver() { }
        public static ListResolver GetInstance()
        {
            if (_listresolver == null)
                _listresolver = new ListResolver();
            return _listresolver;
        }
        #endregion

        #region Typesdocuments
        private List<TypeDocumentVM> _typesdocuments;
        public List<TypeDocumentVM> Typesdocuments
        {
            get
            {
                if (_typesdocuments == null)
                    _typesdocuments = ChargeTypesDocuments();
                return _typesdocuments;
            }

            set
            {
                _typesdocuments = value;
            }
        }

        private List<TypeDocumentVM> ChargeTypesDocuments()
        {
            _typesdocuments = new List<TypeDocumentVM>();
            TypeDocumentVM td = new TypeDocumentVM()
            {
                IdTypeDocument = 80,
                Name = "CUIT"
            };
            _typesdocuments.Add(td);
            td = new TypeDocumentVM()
            {
                IdTypeDocument = 86,
                Name = "CUIL"
            };
            _typesdocuments.Add(td);
            td = new TypeDocumentVM()
            {
                IdTypeDocument = 87,
                Name = "CDI"
            };
            _typesdocuments.Add(td);

            return _typesdocuments;
        }



        public List<TypeDocumentVM> TypesDocuments()
        {
            return Typesdocuments;
        }
        #endregion

        #region TypeActor
        private List<TypeActorVM> _typesactors;
        public List<TypeActorVM> Typesactors
        {
            get
            {
                if (_typesactors == null)
                    _typesactors = ChargeTypesActors();
                return _typesactors;
            }

            set
            {
                _typesactors = value;
            }
        }

        private List<TypeActorVM> ChargeTypesActors()
        {
            _typesactors = new List<TypeActorVM>();
            TypeActorVM td = new TypeActorVM()
            {
                 IdTypeActor=1,
                Name = "Empresa"
            };
            _typesactors.Add(td);
            td = new TypeActorVM()
            {
                IdTypeActor = 2,
                Name = "Profesional"
            };
            _typesactors.Add(td);
            return _typesactors;
        }
        #endregion

    }
}