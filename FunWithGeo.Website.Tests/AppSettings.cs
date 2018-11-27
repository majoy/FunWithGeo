using System.Configuration;

namespace FunWithGeo.Website.Tests
{
	public static class AppSettings
	{
		public static string FunWithGeoWebsiteBaseUrl =>
			ConfigurationManager.AppSettings["FunWithGeo.Website.BaseUrl"].ToString();
	}
}
