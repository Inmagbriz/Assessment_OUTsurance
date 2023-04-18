namespace Assessment_OUTsurance
{
    public class CheckoutPage : Common
    {
        #region Locators
        public string InStorePickupCheckLocator = "id=PickUpInStore";
        public string NextButtonLocator = "xpath=//div[@id='{0}-buttons-container']/descendant::input[contains(@class, 'next-step-button')]";
        public string OrderNumberLocator = "xpath=//ul[@class = 'details']/li";
        #endregion


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
