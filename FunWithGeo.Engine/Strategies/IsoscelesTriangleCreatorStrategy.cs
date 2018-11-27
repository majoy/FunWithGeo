using System.Collections.Generic;
using FunWithGeo.Engine.Models;

namespace FunWithGeo.Engine.Strategies
{
	public class IsoscelesTriangleCreatorStrategy : ICartesianPlaneShapeCreatorStrategy
	{
		private readonly IsoscelesTriangleCreatorStrategyProperties _properties;

		/// <summary>
		/// Given a grid of size AxB, generate isosceles-right triangle shapes that could populate the entire grid based on desired <see cref="properties"/>
		/// </summary>
		/// <param name="properties"></param>
		public IsoscelesTriangleCreatorStrategy(IsoscelesTriangleCreatorStrategyProperties properties)
		{
			_properties = properties;
		}
		
		/// <inheritdoc />
		public List<Shape> GenerateShapes()
		{
			int totalRows = _properties.GridMaxXCoordinateInPixels / _properties.NonHypotenuseSideLengthInPixels;
			int totalCols = _properties.GridMaxYCoordinateInPixels / _properties.NonHypotenuseSideLengthInPixels;

			List<Shape> results = new List<Shape>();

			//Approach for generating isosceles-right triangles in a cartesian plane:
			//We think of the cartesian plane as made up of squares, each square can fit two of these triangles
			//Lets go through square and add two triangles at time.
			//The configuration is limited to just a few optional settings that determine how these triangles are labeled or fit inside the plane
			for (int currentSquareRowPosition = 0; currentSquareRowPosition < totalRows; currentSquareRowPosition++)
			{
				for (int currentSquareColPosition = 0;
					currentSquareColPosition < totalCols;
					currentSquareColPosition++)
				{
					results.AddRange(GenerateTrianglesInsideSquare(totalRows, totalCols, currentSquareRowPosition,
						currentSquareColPosition));
				}
			}

			return results;
		}

		private List<IsoscelesRightTriangle> GenerateTrianglesInsideSquare(int totalRows, int totalCols, int squareRowPosition, int squareColPosition)
		{
			DetermineSquareBottomLeftCornerCoordinate(totalRows, squareRowPosition, squareColPosition, out var startingXCoor, out var startingYCoor);

			Coordinate bottomLeftCoordinate = new Coordinate(startingXCoor, startingYCoor);

			Coordinate topLeftCoordinate =
				bottomLeftCoordinate.FindCoordinateByMovingOnYAxis(_properties.NonHypotenuseSideLengthInPixels);
			Coordinate topRightCoordinate =
				topLeftCoordinate.FindCoordinateByMovingOnXAxis(_properties.NonHypotenuseSideLengthInPixels);
			Coordinate bottomRightCoordinate =
				topRightCoordinate.FindCoordinateByMovingOnYAxis(_properties.NonHypotenuseSideLengthInPixels * -1);

			List<IsoscelesRightTriangle> results = Create2TrianglesToFitInsideSquare(topLeftCoordinate, topRightCoordinate,
				bottomLeftCoordinate, bottomRightCoordinate, squareRowPosition + 1, squareColPosition + 1);

			return results;
		}

		private void DetermineSquareBottomLeftCornerCoordinate(int totalRows, int squareRowPos, int squareColPos,
			out int startingXCoor, out int startingYCoor)
		{
			int currentRowCount = squareRowPos + 1;
			int currentColCount = squareColPos + 1;

			if (_properties.StartRowOption == IsoscelesTriangleCreatorStrategyProperties.StartRowOptions.StartRowAtMaxY)
			{
				startingXCoor = squareColPos * _properties.NonHypotenuseSideLengthInPixels;
				startingYCoor = (totalRows - currentRowCount) * _properties.NonHypotenuseSideLengthInPixels;
			}
			else
			{
				startingXCoor = squareColPos * _properties.NonHypotenuseSideLengthInPixels;
				startingYCoor = squareRowPos * _properties.NonHypotenuseSideLengthInPixels;
			}
		}

		private List<IsoscelesRightTriangle> Create2TrianglesToFitInsideSquare(Coordinate topLeft,
			Coordinate topRight,
			Coordinate bottomLeft,
			Coordinate bottomRight,
			int squareRowCount,
			int squareColCount)
		{

			string letterBasedOnRowCount = ((char)(squareRowCount + 64)).ToString();

			//assume right-side triangle will be labeled with a suffix count greater than left-side triangle
			int suffixForRightTriangle = squareColCount * 2;
			int suffixForLeftTriangle = suffixForRightTriangle - 1;

			//otherwise, swap values
			if (_properties.IncreaseCountOn ==
			    IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnLeftTriangle)
			{
				int temp = suffixForRightTriangle;
				suffixForRightTriangle = suffixForLeftTriangle;
				suffixForLeftTriangle = temp;
			}

			if (_properties.TriangleHypotenusePosition == IsoscelesTriangleCreatorStrategyProperties
				    .TriangleHypotenusePositions.BackslashHypotenuse)
			{
				//facing-down triangle uses top side and right side of the square as sides
				var leftTriangle = CreateTriangleFromCoordinates(topLeft, bottomLeft, bottomRight, $"{letterBasedOnRowCount}{suffixForLeftTriangle}"); 

				//facing-up triangle uses left side and bottom side of the square as sides
				var rightTriangle = CreateTriangleFromCoordinates(topLeft, topRight, bottomRight, $"{letterBasedOnRowCount}{suffixForRightTriangle}");
				return new List<IsoscelesRightTriangle> { rightTriangle, leftTriangle };
			}
			else
			{
				var leftTriangle = CreateTriangleFromCoordinates(topLeft, topRight, bottomLeft, $"{letterBasedOnRowCount}{suffixForLeftTriangle}");
				
				var rightTriangle = CreateTriangleFromCoordinates(bottomLeft, bottomRight, topRight, $"{letterBasedOnRowCount}{suffixForRightTriangle}");
				return new List<IsoscelesRightTriangle> { leftTriangle, rightTriangle };
			}

		}

		private IsoscelesRightTriangle CreateTriangleFromCoordinates(Coordinate coor1, Coordinate coor2,
			Coordinate coor3, string label)
		{
			//right sight up triangle:
			Coordinate newCoor1 = (Coordinate)coor1.Clone();
			Coordinate newCoor2 = (Coordinate)coor2.Clone();
			Coordinate newCoor3 = (Coordinate)coor3.Clone();

			List<Coordinate> triangleCoorindates = new List<Coordinate>
			{
				newCoor1,
				newCoor2,
				newCoor3
			};


			var newTriangle = new IsoscelesRightTriangle(_properties.NonHypotenuseSideLengthInPixels, triangleCoorindates, label);

			return newTriangle;
		}
	}
}
