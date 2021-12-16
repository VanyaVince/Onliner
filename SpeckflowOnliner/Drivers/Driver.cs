using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FluentAssertions.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpeckflowOnliner.Drivers
{
    public class Driver
    {
        private readonly IWebDriver _currentWebDriver;

        public Driver()
        {
            _currentWebDriver = GetDriver();
        }

        public IWebDriver CurrentDriver => _currentWebDriver;

        private IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            return driver;
        }

        
    }
}