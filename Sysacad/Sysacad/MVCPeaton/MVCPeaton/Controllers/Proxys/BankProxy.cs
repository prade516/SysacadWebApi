using HalClient.Net.Parser;
using MVCPeaton.Models.ModelBuilders;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Controllers.Proxys
{
    public class BankProxy : BaseProxy<BankVM>
    {
        protected override BankVM Fill(IRootResourceObject resource)
        {
            return BankBuilder.Fill(resource);
        }

        protected override List<BankVM> FillCollection(IRootResourceObject list)
        {
            return BankBuilder.FillCollection(list);
        }

        protected override string MyRelationEmbeeded()
        {
            throw new NotImplementedException();
        }

        protected override string MySpecificUrl()
        {
            return "/api/banks";
        }
    }
}