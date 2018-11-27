using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace FunWithGeo.Website.Extensions
{
	public static class NameValueCollectionExtensions
	{
		public static string ConstructQueryString(this NameValueCollection parameters)
		{
			List<string> items = new List<string>();

			foreach (string name in parameters)
				items.Add(string.Concat(name, "=", WebUtility.UrlEncode(parameters[name])));

			return string.Join("&", items.ToArray());
		}
	}
}
