using System;
using System.Collections.Generic;
using FluentAssertions;
using FunWithGeo.Engine.Models;
using NUnit.Framework;

namespace FunWithGeo.Engine.Tests.Models
{
	public class CartesianPlaneTests : BaseTest
	{

		[TestCase(0, 1)]
		[TestCase(1, 0)]
		[TestCase(0, 0)]
		public void Constructor_ThrowsNotSupportedException_WhenMaxXOrMaxYAreZeroes(int maxXCoordinate,
			int maxYCoordinate)
		{
			Assert.Throws<NotSupportedException>(() =>
			{
				var plane = new CartesianPlane(maxXCoordinate, maxYCoordinate); //should throw exception
			});
		}

		[TestCase(-1, 1)]
		[TestCase(1, -1)]
		[TestCase(-1, -1)]
		public void Constructor_ThrowsNotSupportedException_WhenMaxXOrMaxYAreNegatives(int maxXCoordinate,
			int maxYCoordinate)
		{
			Assert.Throws<NotSupportedException>(() =>
			{
				var plane = new CartesianPlane(maxXCoordinate, maxYCoordinate); //should throw exception
			});
		}

		[TestCase(1)]
		[TestCase(5)]
		[TestCase(9)]
		public void AddShapes_ExecutesSuccessfully(int shapesCount)
		{
			var plane = new CartesianPlane(10, 10);
			var shapes = new List<Shape>();

			for (int i = 0; i < shapesCount; i++)
			{
				shapes.Add(new Shape(new List<Coordinate> { new Coordinate(i, i) }, $"A{i}"));
			}
			plane.AddShapes(shapes);
			plane.ShapesCount.Should().Be(shapesCount);
		}
	}
}
