using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunWithGeo.Website.ApiClients;
using FunWithGeo.Website.ApiClients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunWithGeo.Website.Pages
{
    public class FindByCoordinatesModel : PageModel
    {
	    private IFunWithGeoApiClient _funWithGeoApiClient;

	    public IsoscelesRightTriangle FoundTriangle { get; set; }

	    [BindProperty]
		public float? X1 { get; set; }

		[BindProperty]
		public float? Y1 { get; set; }

	    [BindProperty]
	    public float? X2 { get; set; }

	    [BindProperty]
	    public float? Y2 { get; set; }

	    [BindProperty]
	    public float? X3 { get; set; }

	    [BindProperty]
	    public float? Y3 { get; set; }

	    public FindByCoordinatesModel(IFunWithGeoApiClient funWithGeoApiClient)
	    {
		    _funWithGeoApiClient = funWithGeoApiClient;
	    }

	    public void OnGet()
	    {
	    }

	    public async Task OnPostAsync()
	    {
			//todo: remove try/catch once exception middleware + patterns are put in place
		    try
		    {
			    FoundTriangle = await _funWithGeoApiClient.FindTriangleByCoordinatesAsync(GetCoordinates());
		    }
		    catch (Exception)
		    {
				//todo: create exception handling middleware, should be able to bubble api exceptions from internal micro-services to the UI
				//im taking a shortcut for now...swallowing exception not goody!
			    FoundTriangle = null;
		    }
	    }

	    public List<Coordinate> GetCoordinates()
	    {
		    List<Coordinate> coordinates = new List<Coordinate>();

		    coordinates.Add(new Coordinate(X1 ?? 0, Y1 ?? 0));
		    coordinates.Add(new Coordinate(X2 ?? 0, Y2 ?? 0));
		    coordinates.Add(new Coordinate(X3 ?? 0, Y3 ?? 0));
		    return coordinates;
	    }

    }
}