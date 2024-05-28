using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using SeleniumAutomation.Common;
using SeleniumAutomation.PageObjects;

namespace SeleniumAutomation.UITests;

public class CheckoutTests : BaseTest
{
    public CheckoutTests(ITestOutputHelper output)
        : base(output) { }

    [Fact]
    [AllureDescription("Login with invalid credentials and verify failed login")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Kevin Valencia")]
    public void CanAddProductToCart()
    {
        const string productName = "Proteus Fitness Jackshirt";

        Task("Go to the login page", () =>
        {
            CatalogPage.GoToCatalogPage();
        });

        Task("Go to Men > Top > Jackets", () =>
        {
            CatalogPage.GoToCatalogSection("Men", "Tops", "Jackets");
        });

        Task("Add a product to the cart", () =>
        {
            CatalogPage.AddProductToCart(productName, "XS", "Black");
        });

        Task("Assert mini cart count is 1", () =>
        {
            CatalogPage.AssertMiniCartCount(1);
        });

        Task("Assert product is in the cart", () =>
        {
            CatalogPage.AssertProductInCart(productName);
        });
    }
}
