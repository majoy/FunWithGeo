using System.Collections.Generic;
using FunWithGeo.Engine.Models;

namespace FunWithGeo.Engine.Strategies
{
	public interface ICartesianPlaneShapeCreatorStrategy
	{
		/// <summary>
		/// Method contract for generating shapes in memory by some concrete-strategy
		/// </summary>
		/// <returns></returns>
		List<Shape> GenerateShapes();
	}
}
