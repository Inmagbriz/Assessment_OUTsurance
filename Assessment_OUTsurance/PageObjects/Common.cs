using FluentAssertions;
using NUnit;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Action = OpenQA.Selenium.Interactions.Actions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter;
using System;
using System.Collections.Specialized;

namespace Assessment_OUTsurance
{
    public class Common
    {
        public static readonly IWebDriver _driver = new ChromeDriver();

        public static void CloseChrome()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        public bool IsElementVisible(string locator, int timeout = 0)
        {
            if (timeout != 0) WaitForVisibilityOfElement(locator, timeout);
            try
            {
                return FindElement(ByLocator(locator)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitForVisibilityOfElement(string locator, int timeout)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(ByLocator(locator)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement FindElement(By by)
        {
            var elem = _driver.FindElement(by);
            return elem;
        }

        public By ByLocator(string locator)
        {
            var prefix = locator.Substring(0, locator.IndexOf('='));
            var suffix = locator.Substring(locator.IndexOf('=') + 1);

            switch (prefix)
            {
                case "xpath":
                    return By.XPath(suffix);
                case "css":
                    return By.CssSelector(suffix);
                case "link":
                    return By.LinkText(suffix);
                case "partLink":
                    return By.PartialLinkText(suffix);
                case "id":
                    return By.Id(suffix);
                case "name":
                    return By.Name(suffix);
                case "tag":
                    return By.TagName(suffix);
                case "class":
                    return By.ClassName(suffix);
                default:
                    return By.Id(suffix);
            }
        }

        public void SendText(string value)
        {
            var action = new Action(_driver);
            action.SendKeys(value);
            action.Build().Perform();
        }

        public IWebElement FindAndHighlightElement(By by)
        {
            var elem = _driver.FindElement(by);

            // draw a border around the found element
            if (_driver is IJavaScriptExecutor executor)
            {
                executor.ExecuteScript("arguments[0].style.border='2px solid green'", elem);
            }
            return elem;
        }
    }
}
