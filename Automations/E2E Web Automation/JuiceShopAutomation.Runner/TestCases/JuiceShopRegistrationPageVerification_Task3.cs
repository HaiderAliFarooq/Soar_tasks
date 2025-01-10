using JuiceShopAutomation.Maps.Pages;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner.TestCases;

public class JuiceShopRegistrationPageVerification_Task3 : TestBase, IClassFixture<AppFixture>
{
    private readonly HomePage _homePage;
    private readonly LoginPage _loginPage;
    private readonly RegistrationPage _registrationPage;

    public JuiceShopRegistrationPageVerification_Task3(AppFixture fixture, ITestOutputHelper testOutputHelper)
    : base(fixture, testOutputHelper)
    {
        _homePage = PageFactory.GetHomePage();
        _loginPage = PageFactory.GetLoginPage();
        _registrationPage = PageFactory.GetRegistrationPage();
    }

    [Fact]
    public void JuiceShopRegistrationPageVerification_Task3_Test()
    {
        _homePage.NavigateToURL();

        // Close the welcome banner
        _homePage.ClickOnCloseWelcomeBannerButtonIfExists();

        // Close cookies popup
        _homePage.ClickOnDismissCookiesButtonIfExists();

        _homePage.ClickOnAccountMenu();
        _homePage.ClickOnLoginButton();
        _loginPage.ClickOnNewCustomerLink();

        _registrationPage.FocusInAndOutOfEmailFieldAndVerifyValidationMessageIsShown();
        _registrationPage.FocusInAndOutOfPasswordFieldAndVerifyValidationMessageIsShown();
        _registrationPage.FocusInAndOutOfRepeatPasswordFieldAndVerifyValidationMessageIsShown();
        _registrationPage.FocusInAndOutOfSecurityQuestionFieldAndVerifyValidationMessageIsShown();
        _registrationPage.FocusInAndOutOfSecurityAnswerFieldAndVerifyValidationMessageIsShown();
        _registrationPage.VerifyRegistrationButtonState(false);

        var emailAndPassword = _registrationPage.RegisterTheUser();

        _loginPage.VerifyRegistrationSuccessMessageIsDisplayed();
        string email = emailAndPassword.Item1;
        string password = emailAndPassword.Item2;

        _loginPage.LoginUser(email, password);
    }
}