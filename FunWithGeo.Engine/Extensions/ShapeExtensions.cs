using System;
using System.Collections.Generic;
using FunWithGeo.Engine.Models;

namespace FunWithGeo.Engine.Extensions
{
	public static class ShapeExtensions
	{
		/// <summary>
		/// Finds a shape in the list of shapes based on <see cref="shapeLabel"/>. If the shape isn't found, it returns null
		/// </summary>
		/// <param name="shapes"></param>
		/// <param name="shapeLabel"></param>
		/// <returns></returns>
		public static Shape FindOneShapeByLabel(this List<Shape> shapes, string shapeLabel)
		{
			foreach (Shape shape in shapes)
			{
				if (shape.Label.Equals(shapeLabel, StringComparison.InvariantCultureIgnoreCase))
					return shape;
			}

			return null;
		}

		/// <summary>
		/// Finds a shape in the list of shapes containing the same list of coordinates to look by. Returns null if it can't find it
		/// </summary>
		/// <param name="shapes"></param>
		/// <param name="shapeCoordinatesToFind"></param>
		/// <returns></returns>
		public static Shape FindOneShapeByCoordinates(this List<Shape> shapes, List<Coordinate> shapeCoordinatesToFind)
		{
			foreach (Shape shape in shapes)
			{
				if (shape.Coordinates.Count != shapeCoordinatesToFind.Count)
					continue;

				bool areEquivalent = shape.Coordinates.Matches(shapeCoordinatesToFind);

				if (areEquivalent)
					return shape;
			}

			return null;
		}
	}
}