using System.Collections.Generic;
using System.Linq;
using FunWithGeo.Engine.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunWithGeo.Api.Controllers
{
	/// <summary>
	/// Exposes methods for finding isosceles-right triangles inside 60x60 grid
	/// </summary>
	[Route("triangle")]
	[ApiController]
	public class TriangleController : ControllerBase
	{
		private readonly ICartesianPlanProvider _cartesianPlanProvider;

		/// <summary>
		/// Controller
		/// </summary>
		/// <param name="cartesianPlanProvider"></param>
		public TriangleController(ICartesianPlanProvider cartesianPlanProvider)
		{
			_cartesianPlanProvider = cartesianPlanProvider;
		}
		
		/// <summary>
		/// Returns json representation of isosceles triangle that matches <paramref name="label"/>
		/// </summary>
		/// <param name="label">The label of the triangle to search by</param>
		/// <returns></returns>
		[HttpGet("findbylabel")]
		[ProducesResponseType(200, Type=typeof(IsoscelesRightTriangle))]
		[ProducesResponseType(404)]
		public ActionResult<IsoscelesRightTriangle> Get([FromQuery] string label)
		{
			var shape =
				_cartesianPlanProvider.CartesianPlaneOn60X60GridWithIsoscelesRightTriangles.FindShapeByLabel(label);

			if (!(shape is IsoscelesRightTriangle))
				return NotFound($"Triangle with label {label} was not found");

			return Ok((IsoscelesRightTriangle)shape);
		}

		/// <summary>
		/// Returns json representation of isosceles triangle that matches coordinates
		/// </summary>
		/// <returns></returns>
		[HttpGet("findbycoordinates")]
		[ProducesResponseType(200, Type=typeof(IsoscelesRightTriangle))]
		[ProducesResponseType(404)]
		public ActionResult<IsoscelesRightTriangle> Get([FromQuery] float x1, float y1, float x2, float y2, float x3, float y3)
		{
			var coordinates = new List<Coordinate>();
			coordinates.Add(new Coordinate(x1, y1));
			coordinates.Add(new Coordinate(x2, y2));
			coordinates.Add(new Coordinate(x3, y3));

			var shape =
				_cartesianPlanProvider.CartesianPlaneOn60X60GridWithIsoscelesRightTriangles.FindShapeByCoordinates(
					coordinates);

			if (!(shape is IsoscelesRightTriangle))
				return NotFound(
					$"Triangle not found with coordinates ({string.Join("  ", coordinates.Select(c => c.ToString()))})");

			return Ok((IsoscelesRightTriangle)shape);
		}

	}
}
