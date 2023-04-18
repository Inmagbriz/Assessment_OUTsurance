namespace Assessment_OUTsurance
{
    public class ShoppingCart : Common
    {
        #region Locators
        public string AgreeTermsCheckLocator = "id=termsofservice";
        public string CheckoutButtonLocator = "xpath=//div[@class='checkout-buttons']";
        #endregion

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
    }
}
