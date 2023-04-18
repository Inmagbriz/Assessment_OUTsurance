using FluentAssertions;
using NUnit;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter;
using System;



namespace Assessment_OUTsurance
{
    public class Actions : Common
    {
        #region Locators
        public string titleLocator = "xpath=//img[@alt = 'Tricentis Demo Web Shop']";
        public string LoginOptionLocator = "xpath=//a[@class = 'ico-login']";
        public string IdLocator = "id={0}";
        public string LoginButtonLocator = "xpath=//input[contains(@class , 'login-button')]";
        public string UserLoggedInLocator = "xpath=//a[@class = 'account']";
        public string OptionCatalogLocator = "xpath=//a[@href = '/{0}']";
        public string CartOptionLocator = "xpath=//a[@class = 'ico-cart']";
        public string OptionProductLocator = "xpath=//div[@class='item-box']";
        public string AddToCarButtonLocator = "xpath=//div[@class='item-box']/descendant::input[contains(@class , 'product-box-add-to-cart-button')]";
        public string AgreeTermsCheckLocator = "id=termsofservice";
        public string CheckoutButtonLocator = "xpath=//div[@class='checkout-buttons']";
        public string CheckoutAsGuessButtonLocator = "xpath=//input[contains(@class , 'checkout-as-guest-button')]";
        public string InStorePickupCheckLocator = "id=PickUpInStore";
        public string NextButtonLocator = "xpath=//div[@id='{0}-buttons-container']/descendant::input[contains(@class, 'next-step-button')]";
        public string OrderNumberLocator = "xpath=//ul[@class = 'details']/li";
        #endregion

        public bool NavigateTo(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
            if (IsElementVisible(titleLocator, 2))
            {
                return true;
            }
            return false;
        }

        public bool ClickLoginMenuOption()
        {
            if (IsElementVisible(LoginOptionLocator, 1))
            {
                FindElement(ByLocator(LoginOptionLocator)).Click();
                return true;
            }
            return false;
        }

        public bool IntroduceValues(string value, string field)
        {
            if (IsElementVisible(string.Format(IdLocator, field), 2))
            {
                FindElement(ByLocator(string.Format(IdLocator, field))).Click();
                SendText(value);
                return true;
            }
            return false;
        }

        public bool ClickLoginButton()
        {
            if (IsElementVisible(LoginButtonLocator, 1))
            {
                FindElement(ByLocator(LoginButtonLocator)).Click();
                return true;
            }
            return false;
        }

        public string UserLoggedIn()
        {   
            return FindElement(ByLocator(UserLoggedInLocator)).GetAttribute("innerText");
        }

        public bool ClickCatalogOption(string option)
        {
            if (IsElementVisible(string.Format(OptionCatalogLocator, option), 1))
            {
                FindElement(ByLocator(string.Format(OptionCatalogLocator, option))).Click();
                return true;
            }
            return false;
        }

        public bool AddToCart()
        {
            if (IsElementVisible(OptionProductLocator, 1))
            {
                if (IsElementVisible(AddToCarButtonLocator, 1))
                {
                    FindElement(ByLocator(AddToCarButtonLocator)).Click();
                    return true;
                }
            }
            return false;
        }

        public bool ClickShoppingCartMenuOption()
        {
            if (IsElementVisible(CartOptionLocator, 1))
            {
                FindElement(ByLocator(CartOptionLocator)).Click();
                return true;
            }
            return false;
        }

        public bool ClickAgreeTerms()
        {
            if (IsElementVisible(AgreeTermsCheckLocator, 1))
            {
                FindElement(ByLocator(AgreeTermsCheckLocator)).Click();
                return true;
            }
            return false;
        }

        public bool ClickCheckoutButton()
        {
            if (IsElementVisible(CheckoutButtonLocator, 1))
            {
                FindElement(ByLocator(CheckoutButtonLocator)).Click();
                return true;
            }
            return false;
        }

        public bool ClickCheckoutAsGuestButton()
        {
            if (IsElementVisible(CheckoutAsGuessButtonLocator, 1))
            {
                FindElement(ByLocator(CheckoutAsGuessButtonLocator)).Click();
                return true;
            }
            return false;
        }

        public bool ClickNextButtonInSection(string section)
        {
            if (IsElementVisible(string.Format(NextButtonLocator, section), 1))
            {
                FindElement(ByLocator(string.Format(NextButtonLocator, section))).Click();
                return true;
            }
            return false;
        }

        public bool ClickInStorePickupButton()
        {
            if (IsElementVisible(InStorePickupCheckLocator, 1))
            {
                FindElement(ByLocator(InStorePickupCheckLocator)).Click();
                return true;
            }
            return false;
        }

        public string GetOrderNumber()
        {
            if (IsElementVisible(OrderNumberLocator, 1))
            {
                Console.WriteLine(FindElement(ByLocator(OrderNumberLocator)).GetAttribute("innerText"));
                return FindElement(ByLocator(OrderNumberLocator)).GetAttribute("innerText");
            }
            return string.Empty;
        }
    }
}
