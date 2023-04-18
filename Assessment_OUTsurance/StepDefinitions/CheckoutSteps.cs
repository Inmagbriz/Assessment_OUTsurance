using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class CheckoutSteps
    {
        [When(@"the user clicks Continue in '(.*)' Address")]
        [When(@"the user clicks Continue in '(.*)'")]
        [When(@"the user clicks in '(.*)'")]
        public void WhenTheUserClicksContinueInAddress(string section)
        {
            if (!Pages.CheckoutPage.ClickNextButtonInSection(section))
            {
                Assert.Inconclusive($"The Continue/Confirm button is not present in {section} section");
            }
        }

        [When(@"the user selects In-Store Pickup")]
        public void WhenTheUserSelectsIn_StorePickup()
        {
            if (!Pages.CheckoutPage.ClickInStorePickupButton())
            {
                Assert.Inconclusive("The checkbox to select In-Store Pickup is not present in the checkout page");
            }
        }

        [Then(@"the user gets the message with an Order number")]
        public void ThenTheUserGetsTheMessageWithAnOrderNumber()
        {
            Assert.That(Pages.CheckoutPage.GetOrderNumber(), Is.Not.Null, "No order has been created");
        }
    }
}