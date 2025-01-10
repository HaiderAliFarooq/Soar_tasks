using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Interface;
using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Pages;

public class LoginPage(IControlLocator locator, IPageActionWrapper wrapper) : BasePage(locator, wrapper)
{
    private By NewCustomerLink => By.Id("newCustomerLink");

    private By Email => By.Id("email");

    private By Password => By.Id("password");

    private By LoginButton => By.Id("loginButton");

    private By RegistrationSuccessMessage => By.XPath("//span[text()='Registration completed successfully. You can now log in.']");

    public void VerifyRegistrationSuccessMessageIsDisplayed()
    {
        AssertHandler.AssertTrue(Locator.FindElement(RegistrationSuccessMessage).Displayed, "Registration success message is not displayed");
    }

    public void ClickOnNewCustomerLink()
    {
        ClickAfterWaitingForElementToBeClickable(NewCustomerLink);
    }

    public void LoginUser(string email, string password)
    {
        Locator.FindElement(Email).SendKeys(email);
        Locator.FindElement(Password).SendKeys(password);

        ClickAfterWaitingForElementToBeClickable(LoginButton);
    }
}
