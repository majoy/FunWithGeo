using System;
using System.Collections.Generic;
using FluentAssertions;
using FunWithGeo.Engine.Extensions;
using FunWithGeo.Engine.Models;
using FunWithGeo.Engine.Strategies;
using NUnit.Framework;

namespace FunWithGeo.Engine.Tests.Strategies
{
	public class IsoscelesTriangleCreatorStrategyTests : BaseTest
	{
		[TestCase(1, 1, 1)]
		[TestCase(1, 2, 2)]
		[TestCase(1, 5, 5)]
		[TestCase(1, 7, 7)]
		[TestCase(1, 10, 10)]
		[TestCase(10, 60, 60)]
		public void GenerateShapes_CorrectCountOfIsoscelesRightTriangles_WhenGridIsSquare(int nonHypotenuseSideLengthInPixels, int maxX, int maxY)
		{
			if (maxX != maxY || maxY <= 0 || maxY <= 0 || maxX < nonHypotenuseSideLengthInPixels ||
			    maxY < nonHypotenuseSideLengthInPixels)
			{
				throw new NotSupportedException(
					"Assertions will only work when the grid is a perfect square of at least 1x1 size");
			}

			//arrange
			var properties = new IsoscelesTriangleCreatorStrategyProperties
			{
				NonHypotenuseSideLengthInPixels = nonHypotenuseSideLengthInPixels,
				GridMaxXCoordinateInPixels = maxX,
				GridMaxYCoordinateInPixels = maxY
			};

			var strategy = new IsoscelesTriangleCreatorStrategy(properties);

			//act
			List<Shape> shapes = strategy.GenerateShapes();

			int expectedTriangleCount =
				(maxX / nonHypotenuseSideLengthInPixels) * (maxY / nonHypotenuseSideLengthInPixels) * 2;

			//assert
			shapes.Count.Should().Be(expectedTriangleCount,
				$"A grid of {maxX}x{maxY} should be populated with {expectedTriangleCount} isosceles right triangles with non-hypotenuse side length of {properties.NonHypotenuseSideLengthInPixels}");
		}


		[TestCase(
			IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnRightTriangle,
			IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)]
		[TestCase(
			IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnLeftTriangle,
			IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)]

		[TestCase(
			IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnRightTriangle,
			IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.ForwardSlashHypotenuse)]
		[TestCase(
			IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnLeftTriangle,
			IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.ForwardSlashHypotenuse)]

		public void GenerateShapes_Returns2IsoscelesRightTrianglesWithNonHypotenuseSideOf1p_For1x1Grid(
			IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns increaseCountOn,
			IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions triangleHypotenusePosition
			)
		{
			//arrange
			var properties = new IsoscelesTriangleCreatorStrategyProperties
			{
				NonHypotenuseSideLengthInPixels = 1,
				GridMaxXCoordinateInPixels = 1,
				GridMaxYCoordinateInPixels = 1,
				IncreaseCountOn = increaseCountOn,
				TriangleHypotenusePosition = triangleHypotenusePosition
			};

			var strategy = new IsoscelesTriangleCreatorStrategy(properties);

			//act
			List<Shape> shapes = strategy.GenerateShapes();


			//assert
			shapes.Count.Should().Be(2, $"a grid of 1x1 can be populated with 2 isosceles-right triangles");

			//Shape leftTriangle, rightTriangle;
			var shapeA1 = shapes.FindOneShapeByLabel("A1");
			var shapeA2 = shapes.FindOneShapeByLabel("A2");
			var expectedCoordinatesA1 = GetExpectedShapeA1For1x1Grid(properties);
			var expectedCoordinatesA2 = GetExpectedShapeA2For1x1Grid(properties);

			var expectedA1Shape = shapes.FindOneShapeByCoordinates(expectedCoordinatesA1);
			var expectedA2Shape = shapes.FindOneShapeByCoordinates(expectedCoordinatesA2);

			shapeA1.Equals(expectedA1Shape).Should().BeTrue();
			shapeA2.Equals(expectedA2Shape).Should().BeTrue();
		}

		private List<Coordinate> GetExpectedShapeA1For1x1Grid(IsoscelesTriangleCreatorStrategyProperties properties)
		{
			List<Coordinate> expectedCoordinates = new List<Coordinate>();

			if (properties.IncreaseCountOn == IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnLeftTriangle)
			{
				if (properties.TriangleHypotenusePosition == IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)
				{
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 0));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
				else
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(1, 0));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
			}
			else
			{
				if (properties.TriangleHypotenusePosition == IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 0));
				}
				else
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
			}

			return expectedCoordinates;
		}
		private List<Coordinate> GetExpectedShapeA2For1x1Grid(IsoscelesTriangleCreatorStrategyProperties properties)
		{
			List<Coordinate> expectedCoordinates = new List<Coordinate>();

			if (properties.IncreaseCountOn == IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns.IncreaseCountOnLeftTriangle)
			{
				if (properties.TriangleHypotenusePosition == IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 0));
				}
				else
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
			}
			else
			{
				if (properties.TriangleHypotenusePosition == IsoscelesTriangleCreatorStrategyProperties.TriangleHypotenusePositions.BackslashHypotenuse)
				{
					expectedCoordinates.Add(new Coordinate(0, 1));
					expectedCoordinates.Add(new Coordinate(1, 0));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
				else
				{
					expectedCoordinates.Add(new Coordinate(0, 0));
					expectedCoordinates.Add(new Coordinate(1, 0));
					expectedCoordinates.Add(new Coordinate(1, 1));
				}
			}

			return expectedCoordinates;
		}
	}
}
