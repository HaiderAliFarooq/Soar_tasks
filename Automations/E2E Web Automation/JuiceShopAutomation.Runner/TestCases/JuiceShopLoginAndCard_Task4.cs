using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Pages;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner.TestCases;

public class JuiceShopLoginAndCard_Task4 : TestBase, IClassFixture<AppFixture>
{
    private readonly HomePage _homePage;
    private readonly LoginPage _loginPage;
    private readonly RegistrationPage _registrationPage;
    private readonly BasketPage _basketPage;
    private readonly CheckoutPage _checkoutPage;
    private const int NumberOfProducts = 5;

    public JuiceShopLoginAndCard_Task4(AppFixture fixture, ITestOutputHelper testOutputHelper)
    : base(fixture, testOutputHelper)
    {
        _homePage = PageFactory.GetHomePage();
        _loginPage = PageFactory.GetLoginPage();
        _registrationPage = PageFactory.GetRegistrationPage();
        _basketPage = PageFactory.GetBasketPage();
        _checkoutPage = PageFactory.GetCheckoutPage();
    }

    [Fact]
    public void JuiceShopLoginAndCard_Task4_Test()
    {
        _homePage.NavigateToURL();

        // Close the welcome banner
        _homePage.ClickOnCloseWelcomeBannerButtonIfExists();

        // Close cookies popup
        _homePage.ClickOnDismissCookiesButtonIfExists();

        _homePage.ClickOnAccountMenu();
        _homePage.ClickOnLoginButton();
        _loginPage.ClickOnNewCustomerLink();
        var emailAndPassword = _registrationPage.RegisterTheUser();
        _loginPage.VerifyRegistrationSuccessMessageIsDisplayed();
        _loginPage.LoginUser(emailAndPassword.Item1, emailAndPassword.Item2);
        Thread.Sleep(2000);

        // Add five different products to the basket
        int counter = 0, tries = 0;
        do
        {
            _homePage.AddProductToBasket(tries);
            tries++;
            var success = _homePage.VerifySuccessPopupMessage();
            if (success)
            {
                counter++;
            }
        }
        while (counter != NumberOfProducts && tries <= 10);

        Thread.Sleep(2000);

        // Check the cart count
        _homePage.VerifyCartCount(NumberOfProducts);

        // Navigate to the basket
        _homePage.NavigateToBasket();
        Thread.Sleep(1000);

        // Get Total Price
        var oldTotalPrice = _basketPage.GetTotalPrices();

        // Increase the number of product
        _basketPage.IncreaseProductQuantity(0);

        // Delete a product from the basket
        _basketPage.DeleteProduct(0);

        // Get Total Price
        var newTotalPrice = _basketPage.GetTotalPrices();

        // Assert that the total price has changed
        AssertHandler.AssertTrue(oldTotalPrice > newTotalPrice, "Total price has not changed or is not as expected.");

        // Click on checkout
        _basketPage.ClickOnCheckout();

        // Add address
        _checkoutPage.AddANewAddress();

        // Select Added Address
        _checkoutPage.SelectAddedAddress();

        // Select delivery method
        _checkoutPage.SelectDeliveryMethod();

        // Assert that the wallet has no money
        _checkoutPage.VerifyWalletHasNoMoney();

        // Add credit card information
        _checkoutPage.AddCreditCardInformation();

        // Continue purchase
        _checkoutPage.ContinuePurchase();
    }
}
