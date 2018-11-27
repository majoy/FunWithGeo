using FluentAssertions;
using FunWithGeo.Website.Tests.Extensions;
using FunWithGeo.Website.Tests.PageObjects;
using NUnit.Framework;

namespace FunWithGeo.Website.Tests.PageTests
{
	public class FindByCoordinatesPageTests : BaseTest<FindByCoordinatesPage>
	{
		[Test]
		public void ClickFindButton_ReturnsSuccessfully_WhenTriangleIsFoundWithMatchingLabel()
		{
			Page.X1Text.EnterText("0");
			Page.Y1Text.EnterText("0");

			Page.X2Text.EnterText("0");
			Page.Y2Text.EnterText("10");

			Page.X3Text.EnterText("10");
			Page.Y3Text.EnterText("0");
			
			Page.FindButton.ClickAndWaitForPageToReload(Driver);
			Page.SuccessMsg.Displayed.Should().BeTrue();
			Page.SuccessMsg.Text.Should().Contain("labeled F1");
		}

		[Test]
		public void ClickFindButton_ReturnsError_WhenTriangleLabelIsNotFound()
		{
			Page.FindButton.ClickAndWaitForPageToReload(Driver);
			Page.ErrorMsg.Displayed.Should().BeTrue();
		}

	}
}
