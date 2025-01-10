using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JuiceShopAutomation.Maps.Pages;

public class HomePage(IControlLocator locator, IPageActionWrapper wrapper) : BasePage(locator, wrapper)
{
    private By ItemsPerPageDropdown => By.XPath("//mat-select[@aria-label='Items per page:']");

    private By MaxItemsOption => By.XPath("//span[contains(text(),'100')]");

    private By PageSizes => By.XPath("//div[@aria-label='Items per page:']//mat-option//span");

    private By ItemsList => By.CssSelector(".mat-grid-tile");

    private By Footer => By.CssSelector("footer");

    private By WelcomeBannerCloseButton => By.XPath("//button[@aria-label='Close Welcome Banner']");

    private By DismissCookiesButton => By.XPath("//a[@aria-label='dismiss cookie message']");

    private By FirstProduct => By.XPath("(//mat-grid-tile//mat-card)[1]");

    private By ExpandReviewsButton => By.XPath("//mat-expansion-panel[@aria-label='Expand for Reviews']//mat-expansion-panel-header");

    private By CloseProductPopupButton => By.XPath("//button[@aria-label='Close Dialog']");

    private By ProductReviews => By.XPath("//div[contains(@class,'mat-expansion-panel-body')]//div[contains(@class,'comment')]");

    private By AccountMenu => By.Id("navbarAccount");

    private By LoginButton => By.Id("navbarLoginButton");
    private By SuccessPopupMessage => By.XPath("//span[contains(text(),'into basket.')]");

    private By AddToBasketButton(int productIndex) => By.XPath($"(//mat-card//button[@aria-label='Add to Basket'])[{productIndex + 1}]");

    private By CartNumber => By.XPath("//button[@aria-label='Show the shopping cart']//span[contains(@class,'warn-notification')]");


    public void NavigateToURL()
    {
        const string url = "https://juice-shop.herokuapp.com/#/";
        Locator.NavigateToUrl(url);
        WaitUntilDocumentIsReady();
    }

    public void ClickOnCloseWelcomeBannerButtonIfExists()
    {
        if (ElementExists(WelcomeBannerCloseButton, 10))
        {
            ClickAfterWaitingForElementToBeClickable(WelcomeBannerCloseButton);
        }
    }

    public void ClickOnDismissCookiesButtonIfExists()
    {
        if (ElementExists(DismissCookiesButton, 10))
        {
            ClickAfterWaitingForElementToBeClickable(DismissCookiesButton);
        }
    }

    // Method to scroll to the bottom of the page
    public void ScrollToBottom()
    {
        ScrollIntoView(Footer);
    }

    // Method to open the items per page dropdown and select maximum items (100)
    public void SelectMaxItemsPerPage()
    {
        ClickAfterWaitingForElementToBeClickable(ItemsPerPageDropdown);

        var allPageSizes = Locator.FindElements(PageSizes);
        allPageSizes[^1].Click();
    }

    // Method to get the count of items displayed on the page
    public int GetDisplayedItemsCount()
    {
        return GetCountOfElements(ItemsList);
    }

    // Method to wait for the footer to be loaded, ensuring page is fully loaded
    public void WaitForPageLoad()
    {
        ExplicitWaitByVisibility(Footer);
    }

    public void WaitForPopupToAppear()
    {
        // Wait for the product detail popup to be visible
        var wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.FindElement(By.CssSelector(".product-image")).Displayed);
    }

    public void ClickOnFirstProduct()
    {
        ClickAfterWaitingForElementToBeClickable(FirstProduct);
    }

    public void ExpandReviewsForOpenedProduct()
    {
        ClickAfterWaitingForElementToBeClickable(ExpandReviewsButton);
    }

    public void VerifyPopupTitleAndImageForOpenedProduct()
    {
        var popupExists = ElementExists(By.XPath("//app-product-details//mat-dialog-content"));
        AssertHandler.AssertTrue(popupExists, "Popup is not shown for opened product.");

        var imageExists = ElementExists(By.XPath("//img[@alt='Apple Juice (1000ml)']"));
        AssertHandler.AssertTrue(imageExists, "Product Image does not exist.");
    }

    public void CheckReviewsCount()
    {
        var reviewCount = GetCountOfElements(ProductReviews);
        AssertHandler.AssertTrue(reviewCount > 0, "Reviews are not showing on the opened product.");
    }

    public void CloseProductPopup()
    {
        ClickAfterWaitingForElementToBeClickable(CloseProductPopupButton);
    }

    public void ClickOnAccountMenu()
    {
        ClickAfterWaitingForElementToBeClickable(AccountMenu);
    }

    public void ClickOnLoginButton()
    {
        ClickAfterWaitingForElementToBeClickable(LoginButton);
    }

    public void AddProductToBasket(int productIndex)
    {
        Wrapper.Click(Locator.FindElement(AddToBasketButton(productIndex)));
    }

    public bool VerifySuccessPopupMessage()
    {
        var success = Locator.ElementDoesExist(SuccessPopupMessage, 8);
        if (success)
        {
            WaitForElementToBeInvisible(SuccessPopupMessage);
        }
        return success;
    }

    public void VerifyCartCount(int expectedCount)
    {
        var cartNumber = int.Parse(Locator.FindElement(CartNumber).Text);
        if (cartNumber != expectedCount)
        {
            throw new Exception($"Expected cart number to be {expectedCount}, but was {cartNumber}");
        }
    }

    public void NavigateToBasket()
    {
        Wrapper.Click(Locator.FindElement(CartNumber));
    }
}
