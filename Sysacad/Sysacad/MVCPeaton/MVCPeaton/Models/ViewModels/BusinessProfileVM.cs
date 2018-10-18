using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BusinessProfileVM : BaseVM
    {
        #region members
        private Int64 _idbusinessprofile;
        private String _coverphoto;
        private String _photolink;
        private String _linklink;
        private Int64 _idbusiness;
        //private Business business;

        private String foto1;
        private String foto2;
        private String foto3;
        private String foto4;
        private String foto5;
        private String foto6;

        private String link1;
        private String link2;
        private String link3;
        private String link4;
        private String link5;
        private String link6;
        private String link7;
        private String link8;        
        
        private List<LinkVM> _links;
        private List<PhotoVM> _photos;
        #endregion

        #region properties
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


        public string coverphoto
        {
            get
            {
                return _coverphoto;
            }

            set
            {
                _coverphoto = value;
            }
        }


        public long idbusiness
        {
            get
            {
                return _idbusiness;
            }

            set
            {
                _idbusiness = value;
            }
        }

        //public Business Business
        //{
        //    get
        //    {
        //        return business;
        //    }

        //    set
        //    {
        //        business = value;
        //    }
        //}

        public List<LinkVM> Links
        {
            get
            {
                return _links;
            }

            set
            {
                _links = value;
            }
        }

        public List<PhotoVM> Photos
        {
            get
            {
                return _photos;
            }

            set
            {
                _photos = value;
            }
        }

        public string Photolink
        {
            get
            {
                return _photolink;
            }

            set
            {
                _photolink = value;
            }
        }

        public string Linklink
        {
            get
            {
                return _linklink;
            }

            set
            {
                _linklink = value;
            }
        }

        public string Foto1
        {
            get
            {
                return foto1;
            }

            set
            {
                foto1 = value;
            }
        }

        public string Foto2
        {
            get
            {
                return foto2;
            }

            set
            {
                foto2 = value;
            }
        }

        public string Foto3
        {
            get
            {
                return foto3;
            }

            set
            {
                foto3 = value;
            }
        }

        public string Foto4
        {
            get
            {
                return foto4;
            }

            set
            {
                foto4 = value;
            }
        }

        public string Foto5
        {
            get
            {
                return foto5;
            }

            set
            {
                foto5 = value;
            }
        }

        public string Foto6
        {
            get
            {
                return foto6;
            }

            set
            {
                foto6 = value;
            }
        }

        public string Link1
        {
            get
            {
                return link1;
            }

            set
            {
                link1 = value;
            }
        }

        public string Link2
        {
            get
            {
                return link2;
            }

            set
            {
                link2 = value;
            }
        }

        public string Link3
        {
            get
            {
                return link3;
            }

            set
            {
                link3 = value;
            }
        }

        public string Link4
        {
            get
            {
                return link4;
            }

            set
            {
                link4 = value;
            }
        }

        public string Link5
        {
            get
            {
                return link5;
            }

            set
            {
                link5 = value;
            }
        }

        public string Link6
        {
            get
            {
                return link6;
            }

            set
            {
                link6 = value;
            }
        }

        public string Link7
        {
            get
            {
                return link7;
            }

            set
            {
                link7 = value;
            }
        }

        public string Link8
        {
            get
            {
                return link8;
            }

            set
            {
                link8 = value;
            }
        }
        #endregion
    }
}