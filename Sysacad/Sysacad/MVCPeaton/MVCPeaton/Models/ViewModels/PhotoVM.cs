using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class PhotoVM :BaseVM
    {
        #region members
        private Int64 _idphoto;
        private String _photo;
        private Int64 _idbusinessprofile;
        private Int32 _state;
        private BusinessProfileVM _businessprofile;
        #endregion

        #region properties
        public long idphoto
        {
            get
            {
                return _idphoto;
            }

            set
            {
                _idphoto = value;
            }
        }

        public string photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }

        public long idbusinessprofile
        {
            get
            {
                return _idbusinessprofile;
            }

            set
            {
                _idbusinessprofile = value;
            }
        }

        public BusinessProfileVM Businessprofile
        {
            get
            {
                return _businessprofile;
            }

            set
            {
                _businessprofile = value;
            }
        }

        public int state
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
        #endregion
    }
}