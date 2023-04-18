using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Assessment_OUTsurance
{
    [Binding]
    public class BooksSteps
    {
        [Given(@"the user adds to cart the book")]
        public void GivenTheUserAddsTo()
        {
            if (!Pages.BooksPage.AddToCart())
            {
                Assert.Inconclusive($"No products not present in the menu or not available to Add to the cart");
            }
        }
    }
}