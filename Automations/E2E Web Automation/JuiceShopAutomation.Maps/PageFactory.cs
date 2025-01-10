using JuiceShopAutomation.Maps.Interface;
using JuiceShopAutomation.Maps.Pages;

namespace JuiceShopAutomation.Maps;

public class PageFactory(IControlLocator locator, IPageActionWrapper wrapper)
{
    private readonly IControlLocator _locator = locator;
    private readonly IPageActionWrapper _wrapper = wrapper;
    private HomePage? _homePage;
    private RegistrationPage? _registrationPage;
    private LoginPage? _loginPage;
    private BasketPage? _basketPage;
    private CheckoutPage? _checkoutPage;

    public HomePage GetHomePage()
    {
        return _homePage ??= new HomePage(_locator, _wrapper);
    }

    public RegistrationPage GetRegistrationPage()
    {
        return _registrationPage ??= new RegistrationPage(_locator, _wrapper);
    }

    public LoginPage GetLoginPage()
    {
        return _loginPage ??= new LoginPage(_locator, _wrapper);
    }

    public BasketPage GetBasketPage()
    {
        return _basketPage ??= new BasketPage(_locator, _wrapper);
    }

    public CheckoutPage GetCheckoutPage()
    {
        return _checkoutPage ??= new CheckoutPage(_locator, _wrapper);
    }
}
