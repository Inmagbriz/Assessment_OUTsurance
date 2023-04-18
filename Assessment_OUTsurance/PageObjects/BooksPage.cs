namespace Assessment_OUTsurance
{
    public class BooksPage : Common
    {
        #region Locators
        public string OptionProductLocator = "xpath=//div[@class='item-box']";
        public string AddToCarButtonLocator = "xpath=//div[@class='item-box']/descendant::input[contains(@class , 'product-box-add-to-cart-button')]";
        #endregion

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
    }
}
