using JuiceShopAutomation.Maps.Common;
using JuiceShopAutomation.Maps.Interface;
using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Pages
{
    public class CheckoutPage : BasePage
    {
        private By AddAddressButton => By.XPath("//button[@aria-label='Add a new address']");

        private By ContinueButton => By.XPath("//button[@aria-label='Proceed to review']");

        private By SaveAddressButton => By.Id("submitButton");

        public By AddressFields(string fieldInfo)=> By.XPath($"//input[@placeholder='Please provide a {fieldInfo}.']");

        public By GridSelectionColumn => By.XPath("//mat-row//mat-cell[contains(@class,'column-Selection')]");

        public CheckoutPage(IControlLocator locator, IPageActionWrapper wrapper) : base(locator, wrapper) { }

        public void AddANewAddress()
        {
            ClickAfterWaitingForElementToBeClickable(AddAddressButton);

            Locator.FindElement(AddressFields("country")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));
            Locator.FindElement(AddressFields("name")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));
            Locator.FindElement(AddressFields("mobile number")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Numerics, 8));
            Locator.FindElement(AddressFields("ZIP code")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Numerics, 5));
            Locator.FindElement(By.Id("address")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));
            Locator.FindElement(AddressFields("city")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));

            ClickAfterWaitingForElementToBeClickable(SaveAddressButton);
        }

        public void SelectAddedAddress()
        {
            Locator.FindElement(GridSelectionColumn).Click();
            Locator.FindElement(By.XPath("//button[@aria-label='Proceed to payment selection']")).Click();
        }

        public void SelectDeliveryMethod()
        {
            Locator.FindElement(GridSelectionColumn).Click();
            Locator.FindElement(By.XPath("//button[@aria-label='Proceed to delivery method selection']")).Click();
        }

        public void VerifyWalletHasNoMoney()
        {
            ExplicitWaitByVisibility(By.XPath("//span[@class='confirmation card-title']"));
            Thread.Sleep(1000);
            var balance = decimal.Parse(Locator.FindElement(By.XPath("//span[contains(@class,'confirmation card-title')]")).Text);
            AssertHandler.AssertTrue(balance == 0, "Wallet balance is not as expected.");
        }

        public void AddCreditCardInformation()
        {
            Locator.FindElement(By.XPath("//mat-panel-title[contains(text(),'Add new card')]")).Click();
            Thread.Sleep(1000);

            Locator.FindElement(By.XPath("//mat-label[text()='Name']//parent::label//parent::span//preceding-sibling::input")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Alphabets, 5));
            Locator.FindElement(By.XPath("//mat-label[text()='Card Number']//parent::label//parent::span//preceding-sibling::input")).SendKeys(ExtensionMethods.GenerateRandomString(StringType.Numerics, 16));
            SelectRandomValueFromDropdown(By.XPath("//mat-label[text()='Expiry Month']//parent::label//parent::span//preceding-sibling::select"));
            SelectRandomValueFromDropdown(By.XPath("//mat-label[text()='Expiry Year']//parent::label//parent::span//preceding-sibling::select"));
            Locator.FindElement(By.Id("submitButton")).Click();
            Locator.FindElement(GridSelectionColumn).Click();
        }

        public void ContinuePurchase()
        {
            Wrapper.Click(Locator.FindElement(ContinueButton));
        }
    }

}
