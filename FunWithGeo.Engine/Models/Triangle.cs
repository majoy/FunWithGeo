using System.Collections.Generic;

namespace FunWithGeo.Engine.Models
{
	public class Triangle : Shape
	{
		public Triangle(List<Coordinate> coordinates, string label) : base(coordinates, label)
		{
		}
	}
}
