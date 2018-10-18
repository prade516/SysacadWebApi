using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public static class TagCategoryBuilder
    {
        public static List<TagCategoryVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["tagcategory"].ToList();
            TagCategoryVM tagcategory;
            List<TagCategoryVM> listdto = new List<TagCategoryVM>();
            foreach (var item in embeeded)
            {
                tagcategory = new TagCategoryVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idtagcategory")).Value),
                    name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                    MyTagsLink = item.Links.First(t => t.Key.Equals("tags")).Value.First(d => d.Rel.Equals("tags")).Href.ToString()
                };
                listdto.Add(tagcategory);
            };
            return listdto;
        }

        public static TagCategoryVM Fill(IRootResourceObject resource)
        {
            return new TagCategoryVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtagcategory")).Value),
                name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString()
            };
        }
    }
}