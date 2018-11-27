using FunWithGeo.Engine.Models;
using FunWithGeo.Engine.Strategies;

namespace FunWithGeo.Api
{
	/// <summary>
	/// Provides cartesian planes represented in memory
	/// </summary>
	public sealed class CartesianPlaneProvider : ICartesianPlanProvider
	{
		private CartesianPlane _cartesianPlaneOn60X60GridWithIsoscelesRightTriangles;

		/// <summary>
		/// A cartesian plane of size 60x60 pixels populated by isosceles triangles whose non-hypotenuse side length is 10px
		/// </summary>
		public CartesianPlane CartesianPlaneOn60X60GridWithIsoscelesRightTriangles
		{
			get
			{
				if (_cartesianPlaneOn60X60GridWithIsoscelesRightTriangles == null)
				{

					_cartesianPlaneOn60X60GridWithIsoscelesRightTriangles =
						CreateNewCartesianPlaneOn60X60GridWithIsoscelesRightTriangles();
				}

				return _cartesianPlaneOn60X60GridWithIsoscelesRightTriangles;
			}
		}

		/// <summary>
		/// Configured desired shapes in the cartesian plane
		/// </summary>
		/// <returns></returns>
		private CartesianPlane CreateNewCartesianPlaneOn60X60GridWithIsoscelesRightTriangles()
		{
			int maxX = 60;
			int maxY = 60;
			int nonHypotenuseSideLengthInPixels = 10;

			var strategyProperties = new IsoscelesTriangleCreatorStrategyProperties();
			strategyProperties.NonHypotenuseSideLengthInPixels = nonHypotenuseSideLengthInPixels;
			strategyProperties.GridMaxXCoordinateInPixels = maxX;
			strategyProperties.GridMaxYCoordinateInPixels = maxY;
			strategyProperties.IncreaseCountOn = IsoscelesTriangleCreatorStrategyProperties.IncreaseCountOns
				.IncreaseCountOnRightTriangle;
			strategyProperties.TriangleHypotenusePosition = IsoscelesTriangleCreatorStrategyProperties
				.TriangleHypotenusePositions.BackslashHypotenuse;
			strategyProperties.StartRowOption =
				IsoscelesTriangleCreatorStrategyProperties.StartRowOptions.StartRowAtMaxY;

			var strategy = new IsoscelesTriangleCreatorStrategy(strategyProperties);

			var plane = new CartesianPlane(maxX, maxY);
			plane.AddShapes(strategy.GenerateShapes());
			return plane;
		}
	}
}
