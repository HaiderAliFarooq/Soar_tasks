using JuiceShopAutomation.Maps.Interface;
using OpenQA.Selenium;

namespace JuiceShopAutomation.Maps.Pages
{
    public class BasketPage(IControlLocator locator, IPageActionWrapper wrapper) : BasePage(locator, wrapper)
    {
        private By ProductIncrease(int productIndex) => By.XPath($"(//*[contains(@class,'fa-plus')]//..)[{productIndex + 1}]");
        private By DeleteProductButton(int productIndex) => By.XPath($"(//*[contains(@class,'fa-trash')]//..)[{productIndex + 1}]");
        private By CheckoutButton => By.Id("checkoutButton");
        private By TotalPrice => By.Id("price");

        public void IncreaseProductQuantity(int productIndex)
        {
            ClickAfterWaitingForElementToBeClickable(ProductIncrease(productIndex));
        }

        public void DeleteProduct(int productIndex)
        {
            ClickAfterWaitingForElementToBeClickable(DeleteProductButton(productIndex));
            Thread.Sleep(1000);
        }

        public void VerifyTotalPriceChanged()
        {
            // Implement logic to verify that the total price has changed
        }

        public void ClickOnCheckout()
        {
            Wrapper.Click(Locator.FindElement(CheckoutButton));
        }

        public decimal GetTotalPrices()
        {
            ExplicitWaitByVisibility(TotalPrice);

            var totalPriceLabel = Locator.FindElement(TotalPrice).Text;
            return Convert.ToDecimal(totalPriceLabel.Trim().Split(":")[1].Replace("¤", ""));
        }
    }

}
