using System;
using System.Collections.Generic;
using FunWithGeo.Engine.Extensions;

namespace FunWithGeo.Engine.Models
{
	/// <summary>
	/// Represents an instance of a cartesian plan that stores shapes
	/// </summary>
	public class CartesianPlane
	{
		private List<Shape> _shapes = new List<Shape>();
		public int MaxXCoordinate { get; private set; }
		public int MaxYCoordinate { get; private set; }
		public int ShapesCount => _shapes.Count;

		/// <summary>
		/// Constructor that returns an instance of a cartesian plan
		/// </summary>
		public CartesianPlane(int maxXCoordinate, int maxYCoordinate)
		{
			if ((maxXCoordinate == 0 && maxXCoordinate == maxYCoordinate) || maxXCoordinate <= 0 || maxYCoordinate <= 0)
				throw new NotSupportedException(
					$"Unable to initialize cartesian plane properties when the maximum X is {maxXCoordinate} and the maximum Y coordinate is {maxYCoordinate}");

			MaxXCoordinate = maxXCoordinate;
			MaxYCoordinate = maxYCoordinate;
		}

		public void AddShapes(List<Shape> shapes)
		{
			//todo: validate that shapes coordinates all fit within cartesian plane size

			_shapes.AddRange(shapes);
		}

		public Shape FindShapeByLabel(string shapeLabel)
		{
			return _shapes.FindOneShapeByLabel(shapeLabel);
		}

		public Shape FindShapeByCoordinates(List<Coordinate> coordinates)
		{
			return _shapes.FindOneShapeByCoordinates(coordinates);
		}
	}
}
