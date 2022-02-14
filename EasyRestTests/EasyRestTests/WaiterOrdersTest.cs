using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;

namespace Tests
{
	[AllureNUnit]
	[AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1420718935")]
	[AllureSuite("NUnit")]
	public class WaiterOrdersTest : BaseTest
	{
		[Test]
		[AllureDescription("Start order as waiter when logged in")]
		[AllureOwner("Vadym")]
		[AllureTag("Waiter", "TestCase ID#00002")]
		[AllureSeverity(SeverityLevel.normal)]
		[AllureEpic("Waiter")]
		[AllureFeature("Orders")]
		[AllureStory("Start order")]
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
			AllureLifecycle.Instance.WrapInStep(
				 () => { Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}"); },
				 "Check for text");
		}

		[Test]
		[AllureDescription("Close order as waiter when logged in")]
		[AllureOwner("Vadym")]
		[AllureTag("Waiter", "TestCase ID#00001")]
		[AllureSeverity(SeverityLevel.normal)]
		[AllureEpic("Waiter")]
		[AllureFeature("Orders")]
		[AllureStory("Close order")]
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
			AllureLifecycle.Instance.WrapInStep(
				 () => { Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}"); },
				 "Check for text");
		}

		[Test]
		[AllureDescription("Compare orders from all tab with assigned waiter, in progress and history tabs")]
		[AllureOwner("Vadym")]
		[AllureTag("Waiter", "TestCase ID#00003")]
		[AllureSeverity(SeverityLevel.normal)]
		[AllureEpic("Waiter")]
		[AllureFeature("Orders")]
		[AllureStory("Compare count of all orders")]
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
			AllureLifecycle.Instance.WrapInStep(
				 () => { Assert.AreEqual(allOrdersCount, actualOrdersCount, $"{allOrdersCount} is not equal {actualOrdersCount}"); },
				 "Check for text");
		}
	}
}