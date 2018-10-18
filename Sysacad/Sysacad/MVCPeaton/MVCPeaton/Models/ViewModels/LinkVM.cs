using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class LinkVM : BaseVM
    {
        #region members
        private Int64 _idlink;
        private String _link;
        private Int32 _type;
        private Int32 _state;

        private Int64 _idbusinessprofile;
        private BusinessProfileVM _businessprofile;
        #endregion

        #region properties

        public long idlink
        {
            get
            {
                return _idlink;
            }

            set
            {
                _idlink = value;
            }
        }

        public string link
        {
            get
            {
                return _link;
            }

            set
            {
                _link = value;
            }
        }

        public Int32 type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
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
        #endregion
    }
}