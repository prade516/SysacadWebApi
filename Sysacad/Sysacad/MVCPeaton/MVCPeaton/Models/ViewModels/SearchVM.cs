using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class SearchVM : BaseVM
    {
        #region members
        private String _SearchTerms;
        private List<BusinessSearchVM> _Business;
        private List<PublicationSearchVM> _Publications;


        #endregion
        #region properties
        public String SearchTerms
        {
            get
            {
                return _SearchTerms;
            }

            set
            {
                _SearchTerms = value;
            }
        }

        public List<BusinessSearchVM> Businesses
        {
            get
            {
                return _Business;
            }

            set
            {
                _Business = value;
            }
        }

        public List<PublicationSearchVM> Publications
        {
            get
            {
                return _Publications;
            }

            set
            {
                _Publications = value;
            }
        }
        //private List<Publi>
        #endregion
    }
}