namespace Assessment_OUTsurance
{
    public class LoginPage : Common
    {
        #region Locators
        public string IdLocator = "id={0}";
        public string LoginButtonLocator = "xpath=//input[contains(@class , 'login-button')]";
        public string UserLoggedInLocator = "xpath=//a[@class = 'account']";
        #endregion

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
    }
}
