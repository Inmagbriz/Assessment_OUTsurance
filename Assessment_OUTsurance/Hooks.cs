﻿using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class Hooks : Common
    {
        [AfterFeature]
        public static void TearDown()
        {
            CloseChrome();
        }
    }

}
