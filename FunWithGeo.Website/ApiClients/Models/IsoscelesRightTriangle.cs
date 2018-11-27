using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithGeo.Website.ApiClients.Models
{
	public class IsoscelesRightTriangle
	{
		public int NonHypotenuseLengthInPixels { get; set; }
		public string Label { get; set; }
		public List<Coordinate> Coordinates { get; set; }

		public IsoscelesRightTriangle()
		{
			Coordinates = new List<Coordinate>();
		}
	}
}
