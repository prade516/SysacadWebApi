using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class BusinessConfigurationBuilder
    {
        //BusinessConfiguration----------------------------------------------------------------------------------------------------------
        public static List<BusinessConfigurationVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["businessconfigurations"].ToList();
            BusinessConfigurationVM businessconfiguration;
            List<BusinessConfigurationVM> listdto = new List<BusinessConfigurationVM>();
            foreach (var item in embeeded)
            {
                businessconfiguration = new BusinessConfigurationVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                    slogan = item.State.Values.FirstOrDefault(t => t.Name.Equals("slogan")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("slogan")).Value,
                    profilephoto = item.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value,
                    quanityemployees = item.State.Values.FirstOrDefault(t => t.Name.Equals("quanityemployees")) == null ? 0 : Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("quanityemployees")).Value),
                    iditem = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("iditem")).Value),
                    idbusiness = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                    businesstype = item.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")) == null ? String.Empty : item.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                    MyBranchesLink = item.Links.First(t => t.Key.Equals("branches")).Value.First(d => d.Rel.Equals("branches")).Href.ToString(),
                    MyEmployeeAccountsLink = item.Links.First(t => t.Key.Equals("employeeaccounts")).Value.First(d => d.Rel.Equals("employeeaccounts")).Href.ToString()
                };
                listdto.Add(businessconfiguration);
            };
            return listdto;
        }

        public static BusinessConfigurationVM Fill(IRootResourceObject resource)
        {
            //BusinessConfiguration
            BusinessConfigurationVM vm = new BusinessConfigurationVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                slogan = resource.State.Values.FirstOrDefault(t => t.Name.Equals("slogan")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("slogan")).Value,
                profilephoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value,
                quanityemployees = resource.State.Values.FirstOrDefault(t => t.Name.Equals("quanityemployees")) == null ? 0 : Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("quanityemployees")).Value),
                idbusiness = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                iditem = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("iditem")).Value),
                businesstype = resource.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")) == null ? String.Empty : resource.State.Values.FirstOrDefault(t => t.Name.Equals("businesstype")).Value,
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                //MyBranchesLink = resource.Links.First(t => t.Key.Equals("branches")).Value.First(d => d.Rel.Equals("branches")).Href.ToString(),
                //MyEmployeeAccountsLink = resource.Links.First(t => t.Key.Equals("employeeaccounts")).Value.First(d => d.Rel.Equals("employeeaccounts")).Href.ToString(),
            };

            #region With lists
            foreach (var item in resource.Embedded)
            {
                if (item.Key == "branches")
                {
                    vm.Branches = listBranches(resource);
                }
                else if (item.Key == "employeeaccounts")
                {
                    vm.EmployeeAccounts = listEmployeeAccounts(resource);
                }
                else if (item.Key == "tags")
                {
                    vm.MyBusinessConfigurationTags = listBusinessConfigurationTags(resource);
                }
            }
            if (vm.Branches == null) { vm.Branches = new List<BrancheVM>(); }
            if (vm.EmployeeAccounts == null) { vm.EmployeeAccounts = new List<EmployeeAccountVM>(); }
            if (vm.MyBusinessConfigurationTags == null) { vm.MyBusinessConfigurationTags = new List<BusinessConfigurationTagVM>(); }
            #endregion

            return vm;
        }

        public static BusinessConfigurationVM Fill(IEmbeddedResourceObject resource)
        {
            return new BusinessConfigurationVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                idbusiness = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idbusiness")).Value),
                iditem = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("iditem")).Value),
                //profilephoto = resource.State.Values.FirstOrDefault(t => t.Name.Equals("profilephoto")).Value,
                quanityemployees = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("quanityemployees")).Value),
                slogan = resource.State.Values.FirstOrDefault(t => t.Name.Equals("slogan")).Value,
            };
        }

        //Branches------------------------------------------------------------------------------------------------------
        private static List<BrancheVM> listBranches(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["branches"].ToList();
            List<BrancheVM> listdto = new List<BrancheVM>();
            foreach (var item in embeeded)
            {
                BrancheVM vm = new BrancheVM()
                {
                    idbranche = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbranche")).Value),
                    address = item.State.Values.FirstOrDefault(t => t.Name.Equals("address")).Value,
                    addressnumber = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("addressnumber")).Value),
                    idbusinessconfiguration = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                    name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value)
                };
                listdto.Add(vm);
            }
            return listdto;
        }

        //Employee Accounts---------------------------------------------------------------------------------------------
        private static List<EmployeeAccountVM> listEmployeeAccounts(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["employeeaccounts"].ToList();
            List<EmployeeAccountVM> listdto = new List<EmployeeAccountVM>();
            foreach (var item in embeeded)
            {
                EmployeeAccountVM vm = new EmployeeAccountVM()
                {
                    username = item.State.Values.FirstOrDefault(t => t.Name.Equals("username")).Value,
                    password = item.State.Values.FirstOrDefault(t => t.Name.Equals("password")).Value,
                    idemployeeaccount = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idemployeeaccount")).Value),
                    idbusinessconfiguration = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value)
                };
                listdto.Add(vm);
            }
            return listdto;
        }

        //BusinessConfigurationTags----------------------------------------------------------------------------------------------------------
        public static List<BusinessConfigurationTagVM> listBusinessConfigurationTags(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded.Keys.Any(x => x == "tags") ? resource.Embedded["tags"].ToList() : new List<IEmbeddedResourceObject>();
            List<BusinessConfigurationTagVM> listdto = new List<BusinessConfigurationTagVM>();
            foreach (var item in embeeded)
            {
                BusinessConfigurationTagVM vm = new BusinessConfigurationTagVM()
                {
                    idbusinessconfigurationtag = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfigurationtag")).Value),
                    idtag = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idtag")).Value),
                    ischecked = false,
                    idbusinessconfiguration = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idbusinessconfiguration")).Value),
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                };

                //Tags
                foreach (var item2 in item.Embedded["tags"].ToList())
                {
                    vm.Tag = new TagVM()
                    {
                        name = item2.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value
                    };
                }
                listdto.Add(vm);
            };
            return listdto;
        }
    }
}