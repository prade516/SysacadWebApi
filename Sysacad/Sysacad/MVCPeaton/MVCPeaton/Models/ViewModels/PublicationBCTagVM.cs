using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class PublicationBCTagVM:BaseVM
    {
        #region Members
        private Int64 _idpublication;
        private Int64 _idbusinessconfigurationtag;
        private Boolean _checked;
        private Int32 _state;
        private Int64 _idtag;
        private String _name;

        #endregion
        #region Properties
        public Int64 idpublication
        {
            get
            {
                return _idpublication;
            }

            set
            {
                _idpublication = value;
            }
        }
        public Int64 idbusinessconfigurationtag
        {
            get
            {
                return _idbusinessconfigurationtag;
            }

            set
            {
                _idbusinessconfigurationtag = value;
            }
        }
        public Int32 state
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
        public Int64 idtag
        {
            get
            {
                return _idtag;
            }

            set
            {
                _idtag = value;
            }
        }
        [Display(Name = "Etiqueta")]
        public String name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Boolean ischecked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }

        public Int64 idpublicationbctag
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
        #endregion
    }
}