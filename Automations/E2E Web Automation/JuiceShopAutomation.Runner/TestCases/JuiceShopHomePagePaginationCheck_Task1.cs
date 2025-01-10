using JuiceShopAutomation.Maps.Pages;
using Xunit.Abstractions;

namespace JuiceShopAutomation.Runner.TestCases;

public class JuiceShopHomePagePaginationCheck_Task1 : TestBase, IClassFixture<AppFixture>
{
    private readonly HomePage _homePage;

    public JuiceShopHomePagePaginationCheck_Task1(AppFixture fixture, ITestOutputHelper testOutputHelper)
    : base(fixture, testOutputHelper)
    {
        _homePage = PageFactory.GetHomePage();
    }

    [Fact]
    public void JuiceShopHomePagePaginationCheck_Task1_Test()
    {
        _homePage.NavigateToURL();

        // Close the welcome banner
        _homePage.ClickOnCloseWelcomeBannerButtonIfExists();

        // Close cookies popup
        _homePage.ClickOnDismissCookiesButtonIfExists();

        // Select maximum items per page
        _homePage.SelectMaxItemsPerPage();

        // Get the count of items displayed on the page
        int displayedItemsCount = _homePage.GetDisplayedItemsCount();

        // Assert that the number of items displayed is 100
        Assert.True(displayedItemsCount == 37, $"Number of items are not as expected.Expected: 37 Actual: {displayedItemsCount}");
    }
}
