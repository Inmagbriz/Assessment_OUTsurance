namespace Assessment_OUTsurance
{ 
    public class Pages
    {
    private static T GetPage<T>() where T : new() => new T();
    public static BooksPage BooksPage => GetPage<BooksPage>();
    public static CheckoutPage CheckoutPage => GetPage<CheckoutPage>();
    public static HomepagePage HomepagePage => GetPage<HomepagePage>();
    public static LoginPage LoginPage => GetPage<LoginPage>();
    public static ShoppingCart ShoppingCart => GetPage<ShoppingCart>();
    }
}