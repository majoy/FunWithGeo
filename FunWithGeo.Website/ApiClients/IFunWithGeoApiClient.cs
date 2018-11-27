using System.Collections.Generic;
using System.Threading.Tasks;
using FunWithGeo.Website.ApiClients.Models;

namespace FunWithGeo.Website.ApiClients
{
	/// <summary>
	/// Contract for RESTful FunWithGeo.Api
	/// </summary>
	public interface IFunWithGeoApiClient
	{
		/// <summary>
		/// Sends a GET request to FunWithGeo.Api to find a triangle based on a label in a cartesian plane that lives somewhere in the 'cloud'
		/// </summary>
		/// <param name="label"></param>
		/// <returns></returns>
		Task<IsoscelesRightTriangle> FindTriangleByLabelAsync(string label);

		/// <summary>
		/// Sends a GET request to FunWithGeo.Api to find a triangle based on a list of coordinates that represent a shape in a cartesian plane that lives somewhere in the 'cloud'
		/// </summary>
		/// <param name="label"></param>
		/// <returns></returns>
		Task<IsoscelesRightTriangle> FindTriangleByCoordinatesAsync(List<Coordinate> coordinates);
	}
}