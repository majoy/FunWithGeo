using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FunWithGeo.Website.Tests.PageObjects
{
	public class FindByLabelPage : IPage
	{
		[FindsBy(How = How.Id, Using="Label")]
		public IWebElement ShapeLabelText { get; set; }

		[FindsBy(How = How.Id, Using="success-msg")]
		public IWebElement SuccessMsg { get; set; }

		[FindsBy(How = How.Id, Using = "error-msg")]
		public IWebElement ErrorMsg { get; set; }

		[FindsBy(How = How.Id, Using="find-btn" )] 
		public IWebElement FindButton { get; set; }

		public string PageUrl => "FindByLabel";
		public string PageTitle => "FindByLabel";
	}
}
