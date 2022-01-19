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
			var signInPageObject = new SignInPage(driver);
			var waiterOrdersPageObject = new WaiterOrdersPage(driver);
			string expectedString = "success";

			//Act
			signInPageObject.SignInAsWaiter2();
			waiterOrdersPageObject.ClickAssignedWaiterTab();
			waiterOrdersPageObject.ClickShowMoreButton();
			waiterOrdersPageObject.ClickStartOrderButton();
			string actualString = waiterOrdersPageObject.GetSuccessOrderMessage();

			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");
		}

		[Test]
		public void CloseOrder()
		{
			//Arrange
			var signInPageObject = new SignInPage(driver);
			var waiterOrdersPageObject = new WaiterOrdersPage(driver);
			string expectedString = "success";

			//Act
			signInPageObject.SignInAsWaiter2();
			waiterOrdersPageObject.ClickInProgressTab();
			waiterOrdersPageObject.ClickShowMoreButton();
			waiterOrdersPageObject.ClickCloseOrderButton();
			string actualString = waiterOrdersPageObject.GetSuccessOrderMessage();

			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");
		}

		[Test]
		public void GetAllOrderStatus()
		{
			//Arrange
			var signInPageObject = new SignInPage(driver);
			var waiterOrdersPageObject = new WaiterOrdersPage(driver);
			int allOrdersCount;
			int actualOrdersCount = 0;

			//Act
			signInPageObject.SignInAsWaiter2();
			waiterOrdersPageObject.ClickAllTab();
			allOrdersCount = waiterOrdersPageObject.GetOrdersTabCount();
			waiterOrdersPageObject.ClickAssignedWaiterTab();
			actualOrdersCount += waiterOrdersPageObject.GetOrdersTabCount();
			waiterOrdersPageObject.ClickInProgressTab();
			actualOrdersCount += waiterOrdersPageObject.GetOrdersTabCount();
			waiterOrdersPageObject.ClickHistoryTab();
			actualOrdersCount += waiterOrdersPageObject.GetOrdersTabCount();

			// Assert
			Assert.AreEqual(allOrdersCount, actualOrdersCount, $"{allOrdersCount} is not equal {actualOrdersCount}");
		}
	}
}