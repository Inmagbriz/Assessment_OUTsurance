using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class HomepageSteps
    {
        private readonly FeatureContext _featureContext;

        public HomepageSteps(FeatureContext featurecontext)
        {
            _featureContext = featurecontext;
        }

        [Given(@"the user has navigated to '(.*)'")]
        public void GivenTheUserHasNavigatedTo(string URL)
        {
            if (!_featureContext.ContainsKey("navigated"))
            {
                if (Pages.HomepagePage.NavigateTo(URL))
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

        [Given(@"the user selects the catalogue '(.*)'")]
        public void GivenTheUserSelectsTheCatalogue(string catalog)
        {
            if (!Pages.HomepagePage.ClickCatalogOption(catalog))
            {
                Assert.Inconclusive($"The catalog {catalog} is not present in the menu");
            }
        }


        [Given(@"the user clicks Log in menu option")]
        public void GivenTheUserClicksLogInMenuOption()
        {
            if (!Pages.HomepagePage.ClickLoginMenuOption())
            {
                Assert.Inconclusive("The Log in option is not present in menu option");
            }
        }

        [Given(@"the user navigates to the Shopping cart")]
        public void GivenTheUserNavigatesToTheShoppingCart()
        {
            if (!Pages.HomepagePage.ClickShoppingCartMenuOption())
            {
                Assert.Inconclusive("The Shopping Cart is not present in menu option");
            }
        }
    }
}