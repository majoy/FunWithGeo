using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FunWithGeo.Website.Tests.PageObjects
{
	public class FindByCoordinatesPage : IPage
	{
		[FindsBy(How = How.Id, Using = "X1")]
		public IWebElement X1Text { get; set; }

		[FindsBy(How = How.Id, Using = "Y1")]
		public IWebElement Y1Text { get; set; }

		[FindsBy(How = How.Id, Using = "X2")]
		public IWebElement X2Text { get; set; }

		[FindsBy(How = How.Id, Using = "Y2")]
		public IWebElement Y2Text { get; set; }

		[FindsBy(How = How.Id, Using = "X3")]
		public IWebElement X3Text { get; set; }

		[FindsBy(How = How.Id, Using = "Y3")]
		public IWebElement Y3Text { get; set; }

		[FindsBy(How = How.Id, Using = "find-btn")]
		public IWebElement FindButton { get; set; }

		[FindsBy(How = How.Id, Using = "success-msg")]
		public IWebElement SuccessMsg { get; set; }

		[FindsBy(How = How.Id, Using = "error-msg")]
		public IWebElement ErrorMsg { get; set; }

		public string PageUrl => "FindByCoordinates";
		public string PageTitle => "FindByCoordinates";
	}
}