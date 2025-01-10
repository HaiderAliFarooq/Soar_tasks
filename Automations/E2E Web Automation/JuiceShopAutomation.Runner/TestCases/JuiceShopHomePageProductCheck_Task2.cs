using JuiceShopAutomation.Maps.Pages;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner.TestCases;

public class JuiceShopHomePageProductCheck_Task2 : TestBase, IClassFixture<AppFixture>
{
    private readonly HomePage _homePage;

    public JuiceShopHomePageProductCheck_Task2(AppFixture fixture, ITestOutputHelper testOutputHelper)
    : base(fixture, testOutputHelper)
    {
        _homePage = PageFactory.GetHomePage();
    }

    [Fact]
    public void JuiceShopHomePageProductCheck_Task2_Test()
    {
        _homePage.NavigateToURL();

        // Close the welcome banner
        _homePage.ClickOnCloseWelcomeBannerButtonIfExists();

        // Close cookies popup
        _homePage.ClickOnDismissCookiesButtonIfExists();

        // Click on First Product
        _homePage.ClickOnFirstProduct();

        // Verify image and popup are shown for opened product
        _homePage.VerifyPopupTitleAndImageForOpenedProduct();

        // Expand Reviewss for the opened product
        _homePage.ExpandReviewsForOpenedProduct();

       // Check there is atleast 1 review
        _homePage.CheckReviewsCount();

        Thread.Sleep(2000);

        // Close product popup
        _homePage.CloseProductPopup();
    }
}
