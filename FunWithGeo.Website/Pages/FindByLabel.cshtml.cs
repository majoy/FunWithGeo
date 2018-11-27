using System;
using System.Threading.Tasks;
using FunWithGeo.Website.ApiClients;
using FunWithGeo.Website.ApiClients.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunWithGeo.Website.Pages
{
    public class FindByLabelModel : PageModel
    {
	    private readonly IFunWithGeoApiClient _funWithGeoApiClient;

	    [BindProperty]
		public string Label { get; set; }

	    public IsoscelesRightTriangle FoundTriangle { get; set; }

	    public FindByLabelModel(IFunWithGeoApiClient funWithGeoApiClient)
	    {
		    _funWithGeoApiClient = funWithGeoApiClient;
	    }
		
        public void OnGet()
        {
        }

	    public async Task OnPostAsync()
	    {
			//todo: remove try/catch once exception middleware is put in place
		    try
		    {
			    FoundTriangle = await _funWithGeoApiClient.FindTriangleByLabelAsync(Label);
		    }
		    catch (Exception)
		    {
			    //todo: create exception handling middleware, should be able to bubble api exceptions from internal micro-services to the UI
			    //im taking a shortcut for now...swallowing exception not goody!
				FoundTriangle = null;
		    }
		}
    }
}