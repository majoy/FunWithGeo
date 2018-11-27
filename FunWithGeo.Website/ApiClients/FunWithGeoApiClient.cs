using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FunWithGeo.Website.ApiClients.Models;
using FunWithGeo.Website.Extensions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FunWithGeo.Website.ApiClients
{
	/// <inheritdoc />
	public class FunWithGeoApiClient : IFunWithGeoApiClient
	{
		private readonly HttpClient _client;
		private string _baseUrl;

		public FunWithGeoApiClient(IConfiguration configuration, HttpClient httpClient)
		{
			_baseUrl = configuration.GetValue<string>("FunWithGeoApi:Url");

			httpClient.BaseAddress = new Uri(_baseUrl);

			_client = httpClient;
		}
		/// <inheritdoc />
		public async Task<IsoscelesRightTriangle> FindTriangleByLabelAsync(string label)
		{
			NameValueCollection queryStringParams = new NameValueCollection();
			queryStringParams.Add("label", label);

			var response = await _client.GetAsync(
				$"triangle/findbylabel?{queryStringParams.ConstructQueryString()}");

			string content = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<IsoscelesRightTriangle>(content);
		}

		/// <inheritdoc />
		public async Task<IsoscelesRightTriangle> FindTriangleByCoordinatesAsync(List<Coordinate> coordinates)
		{
			NameValueCollection queryStringParams = new NameValueCollection();
			int coordinatesCount = 0;
			foreach (var coordinate in coordinates)
			{
				coordinatesCount++;
				queryStringParams.Add($"x{coordinatesCount}", coordinate.X.ToString());
				queryStringParams.Add($"y{coordinatesCount}", coordinate.Y.ToString());
			}

			var response = await _client.GetAsync(
				$"triangle/findbycoordinates?{queryStringParams.ConstructQueryString()}");

			string content = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<IsoscelesRightTriangle>(content);

		}
	}
}
