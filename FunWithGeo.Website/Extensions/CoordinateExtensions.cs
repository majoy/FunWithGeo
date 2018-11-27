using System.Collections.Generic;
using System.Linq;
using FunWithGeo.Website.ApiClients.Models;

namespace FunWithGeo.Website.Extensions
{
	public static class CoordinateExtensions
	{
		public static string DisplayAsString(this List<Coordinate> coordinates)
		{
			return string.Join("  ", coordinates.Select(c => c.ToString()));
		}
	}
}
