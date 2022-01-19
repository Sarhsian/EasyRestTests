using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
	public class WaiterOrdersTest : BaseTest
	{
		[Test]

		public void StartOrder()
		{
			//Arrange
			LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
			SignInPage signInPageObject = new SignInPage(driver);
			WaiterOrdersPageObject waiterOrdersPageObject = new WaiterOrdersPageObject(driver);
			string expectedString = "success";

			//Act
			signInPageObject.SignIn("alexandriawright@test.com", "1");
			//loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
			//loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
			waiterOrdersPageObject.ClickAssignedWaiterTab();
			waiterOrdersPageObject.ClickShowMoreButton();
			waiterOrdersPageObject.ClickStartOrderButton();
			string actualString = waiterOrdersPageObject.GetStartOrderMessage();


			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");

		}

		[Test]
		public void CloseOrder()
		{
			//Arrange
			LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
			SignInPage signInPageObject = new SignInPage(driver);
			WaiterOrdersPageObject waiterOrdersPageObject = new WaiterOrdersPageObject(driver);
			string expectedString = "success";

			//Act
			signInPageObject.SignIn("alexandriawright@test.com", "1");
			//loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
			//loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
			waiterOrdersPageObject.ClickInProgressTab();
			waiterOrdersPageObject.ClickShowMoreButton();
			waiterOrdersPageObject.ClickCloseOrderButton();
			string actualString = waiterOrdersPageObject.GetStartOrderMessage();


			// Assert
			Assert.AreEqual(expectedString, actualString, $"{expectedString} is not equal {actualString}");

		}

		[Test]

		public void GetAllOrderStatus()
		{
			//Arrange
			LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
			SignInPage signInPageObject = new SignInPage(driver);
			WaiterOrdersPageObject waiterOrdersPageObject = new WaiterOrdersPageObject(driver);
			int allOrdersCount;
			int actualOrdersCount = 0;

			//Act
			signInPageObject.SignIn("alexandriawright@test.com", "1");
			//loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
			//loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
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
