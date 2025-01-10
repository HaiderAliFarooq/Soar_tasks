using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Interface;
using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Pages;

public class RegistrationPage(IControlLocator locator, IPageActionWrapper wrapper) : BasePage(locator, wrapper)
{
    private By RegistrationPageTitle => By.XPath("//h1[text()='User Registration']/..");

    private By emailControl => By.Id("emailControl");

    private By passwordControl => By.Id("passwordControl");

    private By repeatPasswordControl => By.Id("repeatPasswordControl");

    private By securityQuestion => By.Name("securityQuestion");

    private By securityAnswerControl => By.Id("securityAnswerControl");

    private By registerButton => By.Id("registerButton");

    private By showPasswordAdviceToggle => By.XPath("//span[text()='Show password advice']");

    public void NavigateToURL()
    {
        const string url = "https://juice-shop.herokuapp.com/#/";
        Locator.NavigateToUrl(url);
        WaitUntilDocumentIsReady();
    }

    public void FocusInAndOutOfEmailFieldAndVerifyValidationMessageIsShown()
    {
        ClickAfterWaitingForElementToBeClickable(emailControl);
        Locator.FindElement(RegistrationPageTitle).Click();
        Thread.Sleep(300);
        AssertHandler.AssertTrue(Locator.FindElement(By.XPath("//mat-error[text()='Please provide an email address.']")).Displayed, "Email field validation message is not shown");
    }

    public void FocusInAndOutOfPasswordFieldAndVerifyValidationMessageIsShown()
    {
        ClickAfterWaitingForElementToBeClickable(passwordControl);
        Locator.FindElement(RegistrationPageTitle).Click();
        Thread.Sleep(300);
        AssertHandler.AssertTrue(Locator.FindElement(By.XPath("//mat-error[text()='Please provide a password. ']")).Displayed, "Password field validation message is not shown");
    }

    public void FocusInAndOutOfRepeatPasswordFieldAndVerifyValidationMessageIsShown()
    {
        ClickAfterWaitingForElementToBeClickable(repeatPasswordControl);
        Locator.FindElement(RegistrationPageTitle).Click();
        Thread.Sleep(300);
        AssertHandler.AssertTrue(Locator.FindElement(By.XPath("//mat-error[text()=' Please repeat your password. ']")).Displayed, "Repeat Password field validation message is not shown");
    }

    public void FocusInAndOutOfSecurityQuestionFieldAndVerifyValidationMessageIsShown()
    {
        ClickAfterWaitingForElementToBeClickable(securityQuestion);
        Locator.FindElement(securityQuestion).SendKeys(Keys.Escape);
        Thread.Sleep(1000);
        AssertHandler.AssertTrue(Locator.FindElement(By.XPath("//mat-error[text()=' Please select a security question. ']")).Displayed, "Security Question field validation message is not shown");
    }

    public void FocusInAndOutOfSecurityAnswerFieldAndVerifyValidationMessageIsShown()
    {
        ClickAfterWaitingForElementToBeClickable(securityAnswerControl);
        Locator.FindElement(RegistrationPageTitle).Click();
        Thread.Sleep(300);
        AssertHandler.AssertTrue(Locator.FindElement(By.XPath("//mat-error[text()=' Please provide an answer to your security question. ']")).Displayed, "Security Answer field validation message is not shown");
    }

    public void VerifyRegistrationButtonState(bool isEnabled)
    {
        AssertHandler.AssertTrue(Locator.FindElement(registerButton).Enabled == isEnabled, "Registration button state is not as expected.");
    }

    public Tuple<string, string> RegisterTheUser()
    {
        var email = ExtensionMethods.GenerateRandomEmail();
        Locator.FindElement(emailControl).SendKeys(email);
        var password = ExtensionMethods.GenerateSecurePassword(8);
        Locator.FindElement(passwordControl).SendKeys(password);
        Locator.FindElement(repeatPasswordControl).SendKeys(password);

        Locator.FindElement(showPasswordAdviceToggle).Click();
        Thread.Sleep(2000);

        ScrollToElement(securityQuestion);
        Locator.FindElement(securityQuestion).Click();
        Locator.FindElement(securityQuestion).SendKeys(Keys.Tab);

        Locator.FindElement(securityAnswerControl).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));

        VerifyRegistrationButtonState(true);

        Locator.FindElement(registerButton).Click();

        return new Tuple<string, string>(email, password);
    }
}
