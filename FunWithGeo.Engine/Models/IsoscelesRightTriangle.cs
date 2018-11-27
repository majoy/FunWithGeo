using System.Collections.Generic;

namespace FunWithGeo.Engine.Models
{
	/// <summary>
	/// Isosceles-right triangle
	/// </summary>
	public class IsoscelesRightTriangle : RightTriangle
	{
		public IsoscelesRightTriangle(int nonHypotenuseLengthInPixels, List<Coordinate> coordinates, string label) : base(coordinates, label)
		{
			NonHypotenuseLengthInPixels = nonHypotenuseLengthInPixels;
		}

		public int NonHypotenuseLengthInPixels { get; private set; }
		
	}
}
