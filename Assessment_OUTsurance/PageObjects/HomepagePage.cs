namespace Assessment_OUTsurance
{
    public class HomepagePage : Common
    {
        #region Locators
        public string titleLocator = "xpath=//img[@alt = 'Tricentis Demo Web Shop']";
        public string LoginOptionLocator = "xpath=//a[@class = 'ico-login']";
        public string OptionCatalogLocator = "xpath=//a[@href = '/{0}']";
        public string CartOptionLocator = "xpath=//a[@class = 'ico-cart']";
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

        public bool ClickCatalogOption(string option)
        {
            if (IsElementVisible(string.Format(OptionCatalogLocator, option), 1))
            {
                FindElement(ByLocator(string.Format(OptionCatalogLocator, option))).Click();
                return true;
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
    }
}
