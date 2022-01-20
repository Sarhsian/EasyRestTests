using NUnit.Framework;
using PageObjects;

namespace Tests
{
	public class WaiterOrdersTest : BaseTest
	{
		[Test]
		public void StartOrder()
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

		[Test]
		public void CloseOrder()
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

		[Test]
		public void GetAllOrderStatus()
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