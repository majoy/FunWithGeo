using FunWithGeo.Engine.Models;

namespace FunWithGeo.Api
{
	public interface ICartesianPlanProvider
	{
		CartesianPlane CartesianPlaneOn60X60GridWithIsoscelesRightTriangles { get; }
	}
}
