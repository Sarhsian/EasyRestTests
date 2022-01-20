﻿using OpenQA.Selenium;
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

		public void ClickAllTab() => AllTab.Click();
		public void ClickAssignedWaiterTab() =>	AssignedWaiterTab.Click();
		public void ClickInProgressTab() => InProgressTab.Click();
		public void ClickHistoryTab() => HistoryTab.Click();
		public void ClickShowMoreButton() => ShowMoreButton.Click();
		public void ClickStartOrderButton() => StartOrderButton.Click();
		public void ClickCloseOrderButton() => CloseOrderButton.Click();
	
		public string GetSuccessOrderMessage()
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='success']")));
			return SuccessOrderMessage.Text;
		}
		public int GetOrdersTabCount()
		{
			List<IWebElement> getListOfOrders = driver.FindElements(By.XPath("//button[contains(@aria-label, 'Show more')]")).ToList();
			return getListOfOrders.Count;
		}
	}
}