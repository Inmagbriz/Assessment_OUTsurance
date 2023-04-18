using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class LoginSteps
    {
        [When(@"the user introduces '(.*)' in '(.*)'")]
        public void ThenTheUserIntroducesIn(string value, string field)
        {
            if (!Pages.LoginPage.IntroduceValues(value, field))
            {
                Assert.Inconclusive($"The box {field} is not present");
            }
        }

        [When(@"the user clicks Log in button")]
        public void WhenTheUserClicksLogInButton()
        {
            if (!Pages.LoginPage.ClickLoginButton())
            {
                Assert.Inconclusive("The Log in button is not present");
            }
        }

        [When(@"the user is logged as '(.*)' with password '(.*)'")]
        public void WhenTheUserIsLoggedAsWithPassword(string user, string password)
        {
            if (!Pages.LoginPage.UserLoggedIn().Equals(user))
            {
                ThenTheUserIntroducesIn(user, "Email");
                ThenTheUserIntroducesIn(password, "Password");
                WhenTheUserClicksLogInButton();
                Pages.ShoppingCart.ClickAgreeTerms();
                Pages.ShoppingCart.ClickCheckoutButton();
            }
        }

        [Then(@"the user is logged in as '(.*)'")]
        public void ThenTheUserIsLoggedInAs(string user)
        {
            Assert.That(Pages.LoginPage.UserLoggedIn(), Is.EqualTo(user), "The user has not logged in correctly");
        }
    }
}