using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class PublicationSearchVM : BaseVM
    {
        #region Members
        private String _title;
        private String _description;
        private String _photo;
        private String _termscondition;
        private Int32 _maxquantity;
        private String _visiblecondition;
        private Int64 _idpublicationcategory;
        private Int32 _state;
        private String _tags;
        private List<PublicationCategoryVM> _publicationcategory;


        //private List<PublicationBCTagVM> _tags;
        #endregion

        #region Properties
        public Int64 idpublication
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

        public String title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public String description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public String photo
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

        public String termscondition
        {
            get
            {
                return _termscondition;
            }

            set
            {
                _termscondition = value;
            }
        }

        public Int32 maxquantity
        {
            get
            {
                return _maxquantity;
            }

            set
            {
                _maxquantity = value;
            }
        }

        public String visiblecondition
        {
            get
            {
                return _visiblecondition;
            }

            set
            {
                _visiblecondition = value;
            }
        }

        public Int64 idpublicationcategory
        {
            get
            {
                return _idpublicationcategory;
            }

            set
            {
                _idpublicationcategory = value;
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

        public List<PublicationCategoryVM> publicationcategory
        {
            get
            {
                return _publicationcategory;
            }

            set
            {
                _publicationcategory = value;
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