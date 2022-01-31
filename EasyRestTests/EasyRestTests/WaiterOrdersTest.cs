using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;

namespace Tests
{
	[AllureNUnit]
	[TestFixture(Author = "Vadym", Description = "Tests for waiter role")]
	[AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1420718935")]
	public class WaiterOrdersTest : BaseTest
	{
		[Test(Description = "Start order as waiter when logged in")]
		[AllureTag("Test-Case#00002")]
		[AllureTms("https://app.clickup.com/t/1ptgcx2")]
		[AllureSeverity(SeverityLevel.normal)]
		public void WaiterStartOrder_WhenLoggedIn_ShouldShowSuccessMessage()
		{
			//Arrange
			var signInPage = new SignInPage(driver);
			var waiterOrdersPage = new WaiterOrdersPage(driver);
			string expectedString = "success";

			//Act
			signInPage.SignInAsWaiter2();
			waiterOrdersPage.ClickAssignedWaiterTab();
			waiterOrdersPage.ClickShowMoreButton();
			waiterOrdersPage.ClickStartOrderButton();
			string actualString = waiterOrdersPage.GetSuccessOrderMessage();

			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");
		}

		[Test(Description = "Close order as waiter when logged in")]
		[AllureTag("Test-Case#00001")]
		[AllureTms("https://app.clickup.com/t/1ptgcwd")]
		[AllureSeverity(SeverityLevel.normal)]
		public void WaiterCloseOrder_WhenLoggedIn_ShouldShowSuccessMessage()
		{
			//Arrange
			var signInPage = new SignInPage(driver);
			var waiterOrdersPage = new WaiterOrdersPage(driver);
			string expectedString = "success";

			//Act
			signInPage.SignInAsWaiter2();
			waiterOrdersPage.ClickInProgressTab();
			waiterOrdersPage.ClickShowMoreButton();
			waiterOrdersPage.ClickCloseOrderButton();
			string actualString = waiterOrdersPage.GetSuccessOrderMessage();

			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");
		}

		[Test(Description = "Compare orders from all tab with assigned waiter, in progress and history tabs")]
		[AllureTag("Test-Case#00003")]
		[AllureSeverity(SeverityLevel.normal)]
		[AllureTms("https://app.clickup.com/t/1ptgcx6")]
		public void WaiterCompareCountOfAllOrders_WhenLoggedIn_OrdersShouldBeListedOnAllTab()
		{
			//Arrange
			var signInPage = new SignInPage(driver);
			var waiterOrdersPage = new WaiterOrdersPage(driver);
			int allOrdersCount;
			int actualOrdersCount = 0;

			//Act
			signInPage.SignInAsWaiter2();
			waiterOrdersPage.ClickAllTab();
			allOrdersCount = waiterOrdersPage.GetOrdersTabCount();
			waiterOrdersPage.ClickAssignedWaiterTab();
			actualOrdersCount += waiterOrdersPage.GetOrdersTabCount();
			waiterOrdersPage.ClickInProgressTab();
			actualOrdersCount += waiterOrdersPage.GetOrdersTabCount();
			waiterOrdersPage.ClickHistoryTab();
			actualOrdersCount += waiterOrdersPage.GetOrdersTabCount();

			// Assert
			Assert.AreEqual(allOrdersCount, actualOrdersCount, $"{allOrdersCount} is not equal {actualOrdersCount}");
		}
	}
}