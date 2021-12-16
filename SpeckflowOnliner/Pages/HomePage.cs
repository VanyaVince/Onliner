﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Network;
using OpenQA.Selenium.Support.UI;
using SpeckflowOnliner.Drivers;

namespace SpeckflowOnliner.Pages
{
    class HomePage : BasePage
    {
        private string url = "https://www.onliner.by/";

        public HomePage(IWebDriver driver)
        {
            WebDriver = driver;
        }
        private IWebElement ProfileIcon => WebDriver.FindElement(By.XPath("//div[contains(@class,'avatar')]"));
        private IWebElement UserId => WebDriver.FindElement(By.XPath("//div[contains(@class,'profile__name')]/a"));
        private IWebElement LoginBtn => WebDriver.FindElement(By.XPath("//div[@id='userbar']//div[contains(@class, 'auth-bar__item--text')]"));
        private IWebElement LogoutBtn => WebDriver.FindElement(By.XPath("//div[contains(@class, 'logout')]/a"));
        private IWebElement SearchField => WebDriver.FindElement(By.XPath("//input[@name='query']"));

        public void OpenUrl()
        {
            WebDriver.Navigate().GoToUrl(url);
        }
        public void SearchProduct(String value) 
        {
            Driver.CreateWebDriverWait(WebDriver).Until(waiting =>
            {
                SearchField.SendKeys(value);
                return true;
            });
        }
        public void ClickOnLoginBtn()
        {
            LoginBtn.Click();
        }
        public void ClickOnProfileItem()
        {
            ProfileIcon.Click();
        }

        public void ClickOnLogoutBtn()
        {
            LogoutBtn.Click();
        }
        
        public int GetUserId()
        {
            return int.Parse(UserId.Text);
        }

        public bool IsLoginBtnDisplayed()
        {
            return LoginBtn.Displayed;
        }
    }
}