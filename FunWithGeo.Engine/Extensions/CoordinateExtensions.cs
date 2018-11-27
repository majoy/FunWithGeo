using System;
using System.Collections.Generic;
using System.Linq;
using FunWithGeo.Engine.Models;

namespace FunWithGeo.Engine.Extensions
{
	public static class CoordinateExtensions
	{
		/// <summary>
		/// Orders list of coordinates first by x-coordinate then by y-coordinate
		/// </summary>
		/// <param name="coordinatesToSort"></param>
		/// <returns></returns>
		public static List<Coordinate> OrderByXThenY(this List<Coordinate> coordinatesToSort)
		{
			return coordinatesToSort.OrderBy(coor => coor.X).ThenBy(coor => coor.Y).ToList();
		}

		/// <summary>
		/// Checks if two list of coordinates of the same size are the same
		/// </summary>
		/// <param name="coordinates1"></param>
		/// <param name="coordinates2"></param>
		/// <returns></returns>
		public static bool Matches(this List<Coordinate> coordinates1, List<Coordinate> coordinates2)
		{
			var coordinates1Sorted = coordinates1.OrderByXThenY();
			var coordinates2Sorted = coordinates2.OrderByXThenY();

			return !coordinates1Sorted.Except(coordinates2Sorted).Any();
		}
	}
}
