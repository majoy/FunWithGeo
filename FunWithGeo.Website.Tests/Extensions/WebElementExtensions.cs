using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FunWithGeo.Website.Tests.Extensions
{
	public static class WebElementExtensions
	{
		public static bool ClickAndWaitForPageToReload(this IWebElement elementToClick, IWebDriver driver, int timeout = 10)
		{
			try
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
				elementToClick.Click();
				return wait.Until(d => elementToClick.Displayed);
			}
			catch (NoSuchElementException)
			{
				Console.WriteLine("Element with locator: '" + elementToClick.Text + "' was not found in current context page.");
				throw;
			}
		}

		public static void EnterText(this IWebElement textElement, string text)
		{
			textElement.Clear();
			textElement.SendKeys(text);
		}

	}
}
