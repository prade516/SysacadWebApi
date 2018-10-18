using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class TagBuilder
    {
        public static List<TagVM> FillCollection(IRootResourceObject resource)
        {
            var embeeded = resource.Embedded["tags"].ToList();
            TagVM tag;
            List<TagVM> listdto = new List<TagVM>();
            foreach (var item in embeeded)
            {
                tag = new TagVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idtag")).Value),
                    name = item.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                    idtagcategory = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idtagcategory")).Value),
                    state = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.First(d => d.Rel.Equals("delete")).Href.ToString(),
                    MyTagCategoryLink = item.Links.First(t => t.Key.Equals("tagcategories")).Value.First(d => d.Rel.Equals("tagcategories")).Href.ToString()
                };
                listdto.Add(tag);
            };
            return listdto;
        }

        public static TagVM Fill(IRootResourceObject resource)
        {
            return new TagVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtag")).Value),
                name = resource.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                state = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                idtagcategory = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idtagcategory")).Value),
                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.First(d => d.Rel.Equals("self")).Href.ToString()
                
            };
        }
    }
}