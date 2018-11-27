using FluentAssertions;
using FunWithGeo.Engine.Models;
using NUnit.Framework;

namespace FunWithGeo.Engine.Tests.Models
{
	public class CoordinateTests : BaseTest
	{
		[Test]
		public void EqualOperator_Works()
		{
			Coordinate coor1 = new Coordinate(0, 1);
			Coordinate coor1Clone = (Coordinate)coor1.Clone();

			(coor1 == coor1Clone).Should().BeTrue();
			(coor1 == new Coordinate(coor1.X + 1, coor1.Y)).Should().BeFalse();
		}

		[Test]
		public void NotEqualOperator_Works()
		{
			Coordinate coor1 = new Coordinate(0, 1);
			Coordinate coor1Clone = (Coordinate)coor1.Clone();
			
			(coor1 != new Coordinate(coor1.X + 1, coor1.Y)).Should().BeTrue();
			(coor1 != coor1Clone).Should().BeFalse();
		}
	}
}
