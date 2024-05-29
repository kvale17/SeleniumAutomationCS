using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Common;

namespace SeleniumAutomation.PageObjects
{
    public static class CatalogPage
    {
        public static IWebDriver Driver => WebDriverContext.CurrentDriver;

        private static readonly string url = "https://magento.softwaretestingboard.com/";

        // Locators
        private static readonly By miniCartCounter = By.CssSelector(".counter-number");
        private static readonly By showCartButton = By.CssSelector(".showcart");
        private static readonly By miniCartDialog = By.CssSelector(".block-minicart");
        private static readonly By productNameInCart = By.CssSelector(".product-item-name");
        private static readonly By addToCartButton = By.XPath("//button[@title = 'Add to Cart']");

        // Dynamic Locators
        private static By ProductItemLocator(string name) =>
            By.XPath(
                $"//div[contains(@class, 'product-item-info')]//*[contains(text(), '{name}')]"
            );

        private static By ProductOptionLocator(string optionLabel) =>
            By.XPath($"//div[@option-label='{optionLabel}']");

        private static By MenuItemLocator(string text) =>
            By.XPath($".//*[@role='menuitem' and contains(.,'{text}')]");

        public static void AddProductToCart(string name, string size, string color)
        {
            IWebElement productContainer = Driver.FindElement(ProductItemLocator(name));

            UIMethods.Click(productContainer, ProductOptionLocator(size));
            UIMethods.Click(productContainer, ProductOptionLocator(color));

            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(Driver.FindElement(ProductOptionLocator(size))).Perform();

            UIMethods.Click(productContainer, addToCartButton);

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(driver =>
            {
                var miniCartCount = UIMethods.GetText(miniCartCounter);
                return !string.IsNullOrEmpty(miniCartCount) && miniCartCount != "0";
            });
        }

        public static void AssertMiniCartCount(int count)
        {
            Assert.Equal(count.ToString(), UIMethods.GetText(miniCartCounter));
        }

        public static void GoToCatalogSection(string gender, string category, string type)
        {
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);

            IWebElement genderContainer = Driver.FindElement(
                By.XPath($"//*[contains(@class, 'category-item') and contains(., '{gender}')]")
            );

            actions.MoveToElement(genderContainer.FindElement(MenuItemLocator(gender))).Perform();

            actions.MoveToElement(genderContainer.FindElement(MenuItemLocator(category))).Perform();

            actions.Click(genderContainer.FindElement(MenuItemLocator(type))).Perform();
        }

        public static void AssertProductInCart(string name)
        {
            UIMethods.Click(showCartButton);

            IWebElement miniCartDialogElement = Driver.FindElement(miniCartDialog);

            IWebElement productNameInCartElement = miniCartDialogElement.FindElement(
                productNameInCart
            );

            Assert.Contains(UIMethods.GetText(productNameInCartElement), name);
        }

        public static void GoToCatalogPage()
        {
            WebDriverContext.CurrentDriver.Navigate().GoToUrl(url);
        }
    }
}
