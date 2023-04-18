

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance.Steps
{
    [Binding]
    public class Assessment_OUTsurance : Actions
    {
        private readonly FeatureContext _featureContext;

        public Assessment_OUTsurance(FeatureContext featurecontext)
        {
            _featureContext = featurecontext;
        }

        [Given(@"the user has navigated to '(.*)'")]
        public void GivenTheUserHasNavigatedTo(string URL)
        {
            if (!_featureContext.ContainsKey("navigated"))
            {
                if (NavigateTo(URL))
                {
                    if (!_featureContext.ContainsKey("navigated"))
                    {
                        _featureContext.Add("navigated", true);
                    }
                    else
                    {
                        _featureContext["navigated"] = true;
                    }
                    Console.WriteLine("Navigation OK");
                }
                else
                {
                    Assert.Inconclusive("Web page not correctly displayed");
                }
            }
        }

        [Given(@"the user clicks Log in menu option")]
        public void GivenTheUserClicksLogInMenuOption()
        {
            if (!ClickLoginMenuOption())
            {
                Assert.Inconclusive("The Log in option is not present in menu option");
            }
        }

        [Given(@"the user selects the catalogue '(.*)'")]
        public void GivenTheUserSelectsTheCatalogue(string catalog)
        {
            if (!ClickCatalogOption(catalog))
            {
                Assert.Inconclusive($"The catalog {catalog} is not present in the menu");
            }
        }

        [Given(@"the user adds to cart the book")]
        public void GivenTheUserAddsTo()
        {
            if (!AddToCart())
            {
                Assert.Inconclusive($"No products not present in the menu or not available to Add to the cart");
            }
        }

        [Given(@"the user navigates to the Shopping cart")]
        public void GivenTheUserNavigatesToTheShoppingCart()
        {
            if (!ClickShoppingCartMenuOption())
            {
                Assert.Inconclusive("The Shopping Cart is not present in menu option");
            }
        }

        [Given(@"the user agrees with the terms of service")]
        public void GivenTheUserAgreesWithTheTermsOfService()
        {
            if (!ClickAgreeTerms())
            {
                Assert.Inconclusive("The checkbox to agree terms is not present in the shopping cart page");
            }
        }

        [When(@"the user introduces '(.*)' in '(.*)'")]
        public void ThenTheUserIntroducesIn(string value, string field)
        {
            if (!IntroduceValues(value, field))
            {
                Assert.Inconclusive($"The box {field} is not present");
            }
        }

        [When(@"the user clicks Log in button")]
        public void WhenTheUserClicksLogInButton()
        {
            if (!ClickLoginButton())
            {
                Assert.Inconclusive("The Log in button is not present");
            }
        }

        [When(@"the user clicks Checkout button")]
        public void WhenTheUserClicksCheckoutButton()
        {
            if (!ClickCheckoutButton())
            {
                Assert.Inconclusive("The Checkout button is not present");
            }
        }

 
        [When(@"the user is logged as '(.*)' with password '(.*)'")]
        public void WhenTheUserIsLoggedAsWithPassword(string user, string password)
        {
            if (!UserLoggedIn().Equals(user))
            {
                ThenTheUserIntroducesIn(user, "Email");
                ThenTheUserIntroducesIn(password, "Password");
                WhenTheUserClicksLogInButton();
                GivenTheUserAgreesWithTheTermsOfService();
                WhenTheUserClicksCheckoutButton();
            }
        }

        [When(@"the user clicks Continue in '(.*)' Address")]
        [When(@"the user clicks Continue in '(.*)'")]
        [When(@"the user clicks in '(.*)'")]
        public void WhenTheUserClicksContinueInAddress(string section)
        {
            if (!ClickNextButtonInSection(section))
            {
                Assert.Inconclusive($"The Continue/Confirm button is not present in {section} section");
            }
        }

        [When(@"the user selects In-Store Pickup")]
        public void WhenTheUserSelectsIn_StorePickup()
        {
            if (!ClickInStorePickupButton())
            {
                Assert.Inconclusive("The checkbox to select In-Store Pickup is not present in the checkout page");
            }
        }

        [Then(@"the user is logged in as '(.*)'")]
        public void ThenTheUserIsLoggedInAs(string user)
        {
            Assert.That(UserLoggedIn(), Is.EqualTo(user), "The user has not logged in correctly");
        }

        [Then(@"the user gets the message with an Order number")]
        public void ThenTheUserGetsTheMessageWithAnOrderNumber()
        {
            Assert.That(GetOrderNumber(), Is.Not.Null, "No order has been created");
        }
    }
}