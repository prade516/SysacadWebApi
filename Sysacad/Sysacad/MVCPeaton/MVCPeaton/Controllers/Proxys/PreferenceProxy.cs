using MVCPeaton.Models.ViewModels.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MVCPeaton.Tools.Exceptions.Handlers;
using System.Web.Mvc;
using System.Net;
using MVCPeaton.Security;

namespace MVCPeaton.Controllers.Proxys
{
    public class PreferenceProxy : BaseProxy<PreferenceVM>
    {
        protected override PreferenceVM Fill(IRootResourceObject resource)
        {
            return PreferenceBuilder.Fill(resource);
        }
        
        protected override List<PreferenceVM> FillCollection(IRootResourceObject list)
        {
            return PreferenceBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/preferences";
        }
    }
}