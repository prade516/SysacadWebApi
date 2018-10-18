using HalClient.Net.Parser;
using MVCPeaton.Models.ViewModels;
using MVCSysacad.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ModelBuilders
{
	public static class EspecialidadBuilder
	{
		public static List<EspecialidadVM> FillCollection(IRootResourceObject list)
		{
			var embeeded = list.Embedded.Count == 0 ? new List<IEmbeddedResourceObject>() : list.Embedded["especialidades"].ToList();
			List<EspecialidadVM> listdto = new List<EspecialidadVM>();
			foreach (var item in embeeded)
			{
				EspecialidadVM especialidad = new EspecialidadVM()
				{
					idespecialidad = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idespecialidad")).Value),
					desc_especialidad = item.State.Values.FirstOrDefault(t => t.Name.Equals("desc_especialidad")) == null ? string.Empty :
					item.State.Values.FirstOrDefault(t => t.Name.Equals("desc_especialidad")).Value,
					estado = Int32.Parse(item.State.Values.FirstOrDefault(t => t.Name.Equals("idespecialidad")).Value),
					MyLink = item.Links.First(t => t.Key.Equals("self")).Value.
						First(d => d.Rel.Equals("self")).Href.ToString(),
					UpdateLink = item.Links.First(t => t.Key.Equals("update")).Value.
						First(d => d.Rel.Equals("update")).Href.ToString(),
					DeleteLink = item.Links.First(t => t.Key.Equals("delete")).Value.
						First(d => d.Rel.Equals("delete")).Href.ToString()

				};
				listdto.Add(especialidad);
			};
			return listdto;
		}
		public static EspecialidadVM Fill(IRootResourceObject resource)
		{
			return new EspecialidadVM()
			{
				idespecialidad = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idespecialidad")).Value),
				desc_especialidad = resource.State.Values.FirstOrDefault(t => t.Name.Equals("desc_especialidad")) == null ? string.Empty :
					resource.State.Values.FirstOrDefault(t => t.Name.Equals("desc_especialidad")).Value,
				estado = Int32.Parse(resource.State.Values.FirstOrDefault(t => t.Name.Equals("idespecialidad")).Value),
				MyLink = resource.Links.First(t => t.Key.Equals("self")).Value.
					   First(d => d.Rel.Equals("self")).Href.ToString(),
			};
		}
	}
}