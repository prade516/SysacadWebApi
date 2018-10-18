using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BusinessSearchVM : BaseVM
    {
        #region Members
        private String _name;
        private String _address;
        private Int32 _addressnumber;
        private String _floor;
        private String _floornumber;
        private Int32 _idlocation;
        private String _responsablename;
        private String _responsablephone;
        private String _cuitcuilcdi;
        private Int32 _state;
        private Int64 _idtypedocument;
        private String _businesstype;
        private String _email;
        private String _tags;
        #endregion
        #region Properties
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

        public String address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public Int32 addressnumber
        {
            get
            {
                return _addressnumber;
            }

            set
            {
                _addressnumber = value;
            }
        }

        public String floor
        {
            get
            {
                return _floor;
            }

            set
            {
                _floor = value;
            }
        }

        public String floornumber
        {
            get
            {
                return _floornumber;
            }

            set
            {
                _floornumber = value;
            }
        }

        public Int32 idlocation
        {
            get
            {
                return _idlocation;
            }

            set
            {
                _idlocation = value;
            }
        }

        public String responsablename
        {
            get
            {
                return _responsablename;
            }

            set
            {
                _responsablename = value;
            }
        }

        public String responsablephone
        {
            get
            {
                return _responsablephone;
            }

            set
            {
                _responsablephone = value;
            }
        }

        public String cuitcuilcdi
        {
            get
            {
                return _cuitcuilcdi;
            }

            set
            {
                _cuitcuilcdi = value;
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

        public Int64 idtypedocument
        {
            get
            {
                return _idtypedocument;
            }

            set
            {
                _idtypedocument = value;
            }
        }

        public String businesstype
        {
            get
            {
                return _businesstype;
            }

            set
            {
                _businesstype = value;
            }
        }

        public String email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public String tags
        {
            get
            {
                return _tags;
            }

            set
            {
                _tags = value;
            }
        }
        #endregion
    }
}