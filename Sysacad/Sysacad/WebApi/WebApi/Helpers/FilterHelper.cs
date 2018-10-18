using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
	public static class FilterHelper
	{
		public static string GenerateFilter(int top, string orderby, string ascending)
		{
			return "?top=" + top + "&orderby=" + orderby + "&ascending=" + ascending;
		}

		public static string GenerateFilter(HybridDictionary filterscollection, int top, string orderby, string ascending)
		{
			String myfilters = "?";
			foreach (String clave in filterscollection.Keys)
			{
				myfilters += clave + "=" + filterscollection[clave].ToString() + "&";
			}
			return myfilters + "top=" + top + "&orderby=" + orderby + "&ascending=" + ascending;
		}
	}
}