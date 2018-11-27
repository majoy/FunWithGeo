using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FunWithGeo.Website.Tests.Extensions;
using FunWithGeo.Website.Tests.PageObjects;
using NUnit.Framework;
using SeleniumExtras.PageObjects;

namespace FunWithGeo.Website.Tests.PageTests
{
	public class FindByLabelPageTests : BaseTest<FindByLabelPage>
	{
		[Test]
		public void ClickFindButton_ReturnsSuccessfully_WhenTriangleIsFoundWithMatchingLabel()
		{
			Page.ShapeLabelText.EnterText("A1");
			Page.FindButton.ClickAndWaitForPageToReload(Driver);
			Page.SuccessMsg.Displayed.Should().BeTrue();
			string successMsg = Page.SuccessMsg.Text;
			Page.SuccessMsg.Text.Contains(" (0,60) (0,50) (10,50)");
		}

		[Test]
		public void ClickFindButton_ReturnsError_WhenTriangleLabelIsNotFound()
		{
			Page.ShapeLabelText.EnterText("A88888");
			Page.FindButton.ClickAndWaitForPageToReload(Driver);
			Page.ErrorMsg.Displayed.Should().BeTrue();
		}

	}
}
