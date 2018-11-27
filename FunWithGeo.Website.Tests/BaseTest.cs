using FunWithGeo.Website.Tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;

namespace FunWithGeo.Website.Tests
{
	[TestClass]
	public class BaseTest<T> where T : IPage, new()
	{
		protected IWebDriver Driver;
		protected T Page;

		public BaseTest()
		{
			Page = new T();
			Driver = new FirefoxDriver() { Url = $"{AppSettings.FunWithGeoWebsiteBaseUrl}{Page.PageUrl}" };
			PageFactory.InitElements(Driver, Page);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver.Quit();
		}
	}
}
