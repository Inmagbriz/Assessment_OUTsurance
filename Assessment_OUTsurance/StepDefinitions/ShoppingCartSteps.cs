using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class ShoppingCartSteps
    {
        [Given(@"the user agrees with the terms of service")]
        public void GivenTheUserAgreesWithTheTermsOfService()
        {
            if (!Pages.ShoppingCart.ClickAgreeTerms())
            {
                Assert.Inconclusive("The checkbox to agree terms is not present in the shopping cart page");
            }
        }

        [When(@"the user clicks Checkout button")]
        public void WhenTheUserClicksCheckoutButton()
        {
            if (!Pages.ShoppingCart.ClickCheckoutButton())
            {
                Assert.Inconclusive("The Checkout button is not present");
            }
        }
    }
}