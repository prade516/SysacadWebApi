using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BusinessConfigurationTagVM
    {
        #region Members
        // Members
        private Int64 _idbusinessconfigurationtag;
        private Int32 _state;
        private Boolean _ischecked;

        // ForeignKey
        private Int64 _idbusinessconfiguration;
        private Int64 _idtag;

        // Navigation property
        private BusinessConfigurationVM _BusinessConfiguration;
        private TagVM _Tag;
        #endregion

        #region Properties
        // Properties
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

        [Required]
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

        [Required]
        public Boolean ischecked
        {
            get
            {
                return _ischecked;
            }

            set
            {
                _ischecked = value;
            }
        }

        // ForeignKey
        public Int64 idbusinessconfiguration
        {
            get
            {
                return _idbusinessconfiguration;
            }

            set
            {
                _idbusinessconfiguration = value;
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

        // Navigation property
        public BusinessConfigurationVM BusinessConfiguration
        {
            get
            {
                return _BusinessConfiguration;
            }

            set
            {
                _BusinessConfiguration = value;
            }
        }
        
        public TagVM Tag
        {
            get
            {
                return _Tag;
            }

            set
            {
                _Tag = value;
            }
        }
        #endregion
    }
}