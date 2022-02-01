using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
	public class WaiterOrdersPage
	{
		protected static IWebDriver driver;
		public WaiterOrdersPage(IWebDriver webDriver)
		{
			driver = webDriver;
		}
		private IWebElement AllTab => driver.FindElement(By.XPath("//span[contains(@class, 'MuiTab') and contains(text(), 'All')]"));
		private IWebElement AssignedWaiterTab => driver.FindElement(By.XPath("//span[contains(@class, 'MuiTab') and contains(text(), 'Assigned waiter')]"));
		private IWebElement InProgressTab => driver.FindElement(By.XPath("//span[contains(@class, 'MuiTab') and contains(text(), 'In progress')]"));
		private IWebElement HistoryTab => driver.FindElement(By.XPath("//span[contains(@class, 'MuiTab') and contains(text(), 'History')]"));
		private IWebElement ShowMoreButton => driver.FindElement(By.XPath("//button[contains(@aria-label, 'Show more')][1]"));
		private IWebElement StartOrderButton => driver.FindElement(By.XPath("//span[text()='Start order']"));
		private IWebElement CloseOrderButton => driver.FindElement(By.XPath("//span[text()='Close order']"));
		private IWebElement SuccessOrderMessage => driver.FindElement(By.XPath("//p[text()='success']"));
		[AllureStep("Click on all tab")]
		public void ClickAllTab() => AllTab.Click();
		[AllureStep("Click on assigned waiter tab")]
		public void ClickAssignedWaiterTab() =>	AssignedWaiterTab.Click();
		[AllureStep("Click on in progress tab")]
		public void ClickInProgressTab() => InProgressTab.Click();
		[AllureStep("Click on history tab")]
		public void ClickHistoryTab() => HistoryTab.Click();
		[AllureStep("Click on show more button")]
		public void ClickShowMoreButton() => ShowMoreButton.Click();
		[AllureStep("Click on start order button")]
		public void ClickStartOrderButton() => StartOrderButton.Click();
		[AllureStep("Click on close order button")]
		public void ClickCloseOrderButton() => CloseOrderButton.Click();

		[AllureStep("Gets web element with \"success\" text")]
		public string GetSuccessOrderMessage()
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='success']")));
			return SuccessOrderMessage.Text;
		}
		[AllureStep("Count of orders in selected tab")]
		public int GetOrdersTabCount()
		{
			List<IWebElement> getListOfOrders = driver.FindElements(By.XPath("//button[contains(@aria-label, 'Show more')]")).ToList();
			return getListOfOrders.Count;
		}
	}
}