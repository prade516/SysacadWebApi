using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using MVCPeaton.Models.ViewModels.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
    public class PreferenceBuilder
    {
        public static List<PreferenceVM> FillCollection(IRootResourceObject resource)
        {
            List<PreferenceVM> listdto = new List<PreferenceVM>();
            foreach (var item in resource.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : resource.Embedded["preferences"].ToList())
            {
                var preference = new PreferenceVM()
                {
                    Id = Int64.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idpreference")).Value),
                    username = item.State.Values.FirstOrDefault(t => t.Name.Equals("username")) == null ? string.Empty
                    : item.State.Values.FirstOrDefault(t => t.Name.Equals("username")).Value,
                    MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                    UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                    DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                    mybankslink = item.Links.First(t => t.Key.Equals("banks")).Value.
                        First(d => d.Rel.Equals("banks")).Href.ToString(),
                    myitemslink = item.Links.First(t => t.Key.Equals("items")).Value.
                        First(d => d.Rel.Equals("items")).Href.ToString(),
                    mytagslink = item.Links.First(t => t.Key.Equals("tags")).Value.
                        First(d => d.Rel.Equals("tags")).Href.ToString(),
                    mybanks = new List<PreferenceBankVM>(),
                    myitems = new List<PreferenceItemVM>(),
                    mytags = new List<PreferenceTagVM>()
                };
                foreach(var itemsubnivel in item.Embedded.Keys.Any(x=>x == "banks") ? item.Embedded["banks"].ToList() : new List<IEmbeddedResourceObject>())
                    FillCollectionPreferenceBank(preference, itemsubnivel);
                foreach (var itemsubnivel in item.Embedded.Keys.Any(x => x == "items") ? item.Embedded["items"].ToList() : new List<IEmbeddedResourceObject>())
                    FillCollectionPreferenceItem(preference, itemsubnivel);
                foreach (var itemsubnivel in item.Embedded.Keys.Any(x => x == "tags") ? item.Embedded["tags"].ToList() : new List<IEmbeddedResourceObject>())
                    FillCollectionPreferenceTag(preference, itemsubnivel);
                listdto.Add(preference);
            };
            return listdto;
        }

        public static void FillCollectionPreferenceBank(PreferenceVM preference, IEmbeddedResourceObject itemsubnivel)
        {
            var bank = new PreferenceBankVM()
            {
                Id = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreferencebank")).Value),
                Idbank = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idbank")).Value),
                Idpreference = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreference")).Value),
                State = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Name = itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                Logo = itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("logo")) == null ? string.Empty :
                                        itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("logo")).Value,
                MyLink = itemsubnivel.Links.First(t => t.Key.Equals("self")).Value.
                                    First(d => d.Rel.Equals("self")).Href.ToString(),
            };
            preference.mybanks.Add(bank);
        }

        public static void FillCollectionPreferenceItem(PreferenceVM preference, IEmbeddedResourceObject itemsubnivel)
        {
            var item = new PreferenceItemVM()
            {
                Id = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreferenceitem")).Value),
                IdItem = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("IdItem")).Value),
                Idpreference = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreference")).Value),
                State = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Name = itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("Name")).Value,
                MyLink = itemsubnivel.Links.First(t => t.Key.Equals("self")).Value.
                                    First(d => d.Rel.Equals("self")).Href.ToString(),
            };
            preference.myitems.Add(item);
        }

        public static void FillCollectionPreferenceTag(PreferenceVM preference, IEmbeddedResourceObject itemsubnivel)
        {
            var tag = new PreferenceTagVM()
            {
                Id = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreferencetag")).Value),
                Idtag  = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idtag")).Value),
                Idpreference = Int64.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("idpreference")).Value),
                State = Int32.Parse(itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("state")).Value),
                Name = itemsubnivel.State.Values.FirstOrDefault(t => t.Name.Equals("name")).Value,
                MyLink = itemsubnivel.Links.First(t => t.Key.Equals("self")).Value.
                                    First(d => d.Rel.Equals("self")).Href.ToString(),
            };
            preference.mytags.Add(tag);
        }

        public static PreferenceVM Fill(IRootResourceObject resource)
        {
            var preference = new PreferenceVM()
            {
                Id = Int64.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idpreference")).Value),
                username = resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")) == null ? string.Empty
                    : resource.State.Values.FirstOrDefault(t => t.Name.Equals("username")).Value,

                MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
                        First(d => d.Rel.Equals("self")).Href.ToString(),
                UpdateLink = resource.Links.First(t => t.Key.Equals("update")).Value.
                        First(d => d.Rel.Equals("update")).Href.ToString(),
                DeleteLink = resource.Links.First(t => t.Key.Equals("delete")).Value.
                        First(d => d.Rel.Equals("delete")).Href.ToString(),
                mybankslink = resource.Links.First(t => t.Key.Equals("banks")).Value.
                        First(d => d.Rel.Equals("banks")).Href.ToString(),
                myitemslink = resource.Links.First(t => t.Key.Equals("items")).Value.
                        First(d => d.Rel.Equals("items")).Href.ToString(),
                mytagslink = resource.Links.First(t => t.Key.Equals("tags")).Value.
                        First(d => d.Rel.Equals("tags")).Href.ToString(),
                mybanks = new List<PreferenceBankVM>(),
                myitems = new List<PreferenceItemVM>(),
                mytags = new List<PreferenceTagVM>()
            };
            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "banks") ? resource.Embedded["banks"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionPreferenceBank(preference, itemsubnivel);
            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "items") ? resource.Embedded["items"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionPreferenceItem(preference, itemsubnivel);
            foreach (var itemsubnivel in resource.Embedded.Keys.Any(x => x == "tags") ? resource.Embedded["tags"].ToList() : new List<IEmbeddedResourceObject>())
                FillCollectionPreferenceTag(preference, itemsubnivel);
            return preference;
        }
    }
}