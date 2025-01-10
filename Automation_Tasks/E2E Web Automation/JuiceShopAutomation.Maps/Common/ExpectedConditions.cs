using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace JuiceShopAutomation.Maps.Common;

//
// Summary:
//     Supplies a set of common conditions that can be waited for using OpenQA.Selenium.Support.UI.WebDriverWait.
public static class ExpectedConditions
{
    //
    // Summary:
    //     An expectation for checking the AlterIsPresent.
    //
    // Returns:
    //     Alert.
    public static Func<IWebDriver, IAlert> AlertIsPresent()
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking the Alert State.
    //
    // Parameters:
    //   state:
    //     A value indicating whether or not an alert should be displayed in order to meet
    //     this condition.
    //
    // Returns:
    //     true alert is in correct state present or not present; otherwise, false.
    public static Func<IWebDriver, bool> AlertState(bool state)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                driver.SwitchTo().Alert();
                return state;
            }
            catch (NoAlertPresentException)
            {
                return !state;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that an element is present on the DOM of a page.
    //     This does not necessarily mean that the element is visible.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     The OpenQA.Selenium.IWebElement once it is located.
    public static Func<IWebDriver, IWebElement> ElementExists(By locator)
    {
        return (IWebDriver driver) => driver.FindElement(locator);
    }

    //
    // Summary:
    //     An expectation for checking that an element is present on the DOM of a page and
    //     visible. Visibility means that the element is not only displayed but also has
    //     a height and width that is greater than 0.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     The OpenQA.Selenium.IWebElement once it is located and visible.
    public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return ElementIfVisible(driver.FindElement(locator));
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given element is in correct state.
    //
    // Parameters:
    //   element:
    //     The element.
    //
    //   selected:
    //     selected or not selected.
    //
    // Returns:
    //     true given element is in correct state.; otherwise, false.
    public static Func<IWebDriver, bool> ElementSelectionStateToBe(IWebElement element, bool selected)
    {
        return (IWebDriver driver) => element.Selected == selected;
    }

    //
    // Summary:
    //     An expectation for checking if the given element is in correct state.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    //   selected:
    //     selected or not selected.
    //
    // Returns:
    //     true given element is in correct state.; otherwise, false.
    public static Func<IWebDriver, bool> ElementSelectionStateToBe(By locator, bool selected)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return driver.FindElement(locator).Selected == selected;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking an element is visible and enabled such that you can
    //     click it.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     The OpenQA.Selenium.IWebElement once it is located and clickable (visible and
    //     enabled).
    public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
    {
        return (IWebDriver driver) =>
        {
            IWebElement webElement = ElementIfVisible(driver.FindElement(locator));
            try
            {
                if (webElement != null && webElement.Enabled)
                {
                    return webElement;
                }

                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking an element is visible and enabled such that you can
    //     click it.
    //
    // Parameters:
    //   element:
    //     The element.
    //
    // Returns:
    //     The OpenQA.Selenium.IWebElement once it is clickable (visible and enabled).
    public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
    {
        return delegate
        {
            try
            {
                if (element != null && element.Displayed && element.Enabled)
                {
                    return element;
                }

                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given element is selected.
    //
    // Parameters:
    //   element:
    //     The element.
    //
    // Returns:
    //     true given element is selected.; otherwise, false.
    public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element)
    {
        return ElementSelectionStateToBe(element, selected: true);
    }

    //
    // Summary:
    //     An expectation for checking if the given element is in correct state.
    //
    // Parameters:
    //   element:
    //     The element.
    //
    //   selected:
    //     selected or not selected.
    //
    // Returns:
    //     true given element is in correct state.; otherwise, false.
    public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element, bool selected)
    {
        return (IWebDriver driver) => element.Selected == selected;
    }

    //
    // Summary:
    //     An expectation for checking if the given element is selected.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     true given element is selected.; otherwise, false.
    public static Func<IWebDriver, bool> ElementToBeSelected(By locator)
    {
        return ElementSelectionStateToBe(locator, selected: true);
    }

    //
    // Summary:
    //     An expectation for checking whether the given frame is available to switch to.
    //     If the frame is available it switches the given driver to the specified frame.
    //
    //
    // Parameters:
    //   frameLocator:
    //     Used to find the frame (id or name).
    public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(string frameLocator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return driver.SwitchTo().Frame(frameLocator);
            }
            catch (NoSuchFrameException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking whether the given frame is available to switch to.
    //     If the frame is available it switches the given driver to the specified frame.
    //
    //
    // Parameters:
    //   locator:
    //     Locator for the Frame.
    public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By locator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                IWebElement frameElement = driver.FindElement(locator);
                return driver.SwitchTo().Frame(frameElement);
            }
            catch (NoSuchFrameException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that an element is either invisible or not present
    //     on the DOM.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     true if the element is not displayed; otherwise, false.
    public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return !driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that an element with text is either invisible or
    //     not present on the DOM.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    //   text:
    //     Text of the element.
    //
    // Returns:
    //     true if the element is not displayed; otherwise, false.
    public static Func<IWebDriver, bool> InvisibilityOfElementWithText(By locator, string text)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                string text2 = driver.FindElement(locator).Text;
                if (string.IsNullOrEmpty(text2))
                {
                    return true;
                }

                return !text2.Equals(text);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that all elements present on the web page that match
    //     the locator.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     The list of OpenQA.Selenium.IWebElement once it is located.
    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
                return readOnlyCollection.Any() ? readOnlyCollection : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     Wait until an element is no longer attached to the DOM.
    //
    // Parameters:
    //   element:
    //     The element.
    //
    // Returns:
    //     false is the element is still attached to the DOM; otherwise, true.
    public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
    {
        return delegate
        {
            try
            {
                return element == null || !element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given text is present in the specified collection
    //     of elements.
    //
    // Parameters:
    //   elements:
    //     The WebElement list.
    //
    //   text:
    //     Text to be present in the element.
    public static Func<IWebDriver, bool> TextIsDisplayedInCollection(IEnumerable<IWebElement> elements, string text)
    {
        return delegate
        {
            try
            {
                return elements.Any((IWebElement element) => element.Text.Contains(text));
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given text is present in the specified element.
    //
    //
    // Parameters:
    //   element:
    //     The WebElement.
    //
    //   text:
    //     Text to be present in the element.
    //
    // Returns:
    //     true once the element contains the given text; otherwise, false.
    public static Func<IWebDriver, bool> TextToBePresentInElement(IWebElement element, string text)
    {
        return delegate
        {
            try
            {
                return element.Text.Contains(text);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given text is present in the element that
    //     matches the given locator.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    //   text:
    //     Text to be present in the element.
    //
    // Returns:
    //     true once the element contains the given text; otherwise, false.
    public static Func<IWebDriver, bool> TextToBePresentInElementLocated(By locator, string text)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return driver.FindElement(locator).Text.Contains(text);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given text is present in the specified elements
    //     value attribute.
    //
    // Parameters:
    //   element:
    //     The WebElement.
    //
    //   text:
    //     Text to be present in the element.
    //
    // Returns:
    //     true once the element contains the given text; otherwise, false.
    public static Func<IWebDriver, bool> TextToBePresentInElementValue(IWebElement element, string text)
    {
        return delegate
        {
            try
            {
                return element.GetAttribute("value")?.Contains(text) ?? false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking if the given text is present in the specified elements
    //     value attribute.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    //   text:
    //     Text to be present in the element.
    //
    // Returns:
    //     true once the element contains the given text; otherwise, false.
    public static Func<IWebDriver, bool> TextToBePresentInElementValue(By locator, string text)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                return driver.FindElement(locator).GetAttribute("value")?.Contains(text) ?? false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that the title of a page contains a case-sensitive
    //     substring.
    //
    // Parameters:
    //   title:
    //     The fragment of title expected.
    //
    // Returns:
    //     true when the title matches; otherwise, false.
    public static Func<IWebDriver, bool> TitleContains(string title)
    {
        return (IWebDriver driver) => driver.Title.Contains(title);
    }

    //
    // Summary:
    //     An expectation for checking the title of a page.
    //
    // Parameters:
    //   title:
    //     The expected title, which must be an exact match.
    //
    // Returns:
    //     true when the title matches; otherwise, false.
    public static Func<IWebDriver, bool> TitleIs(string title)
    {
        return (IWebDriver driver) => title == driver.Title;
    }

    //
    // Summary:
    //     An expectation for the URL of the current page to be a specific URL.
    //
    // Parameters:
    //   fraction:
    //     The fraction of the url that the page should be on.
    //
    // Returns:
    //     true when the URL contains the text; otherwise, false.
    public static Func<IWebDriver, bool> UrlContains(string fraction)
    {
        return (IWebDriver driver) => driver.Url.ToLowerInvariant().Contains(fraction.ToLowerInvariant());
    }

    //
    // Summary:
    //     An expectation for the URL of the current page to be a specific URL.
    //
    // Parameters:
    //   regex:
    //     The regular expression that the URL should match.
    //
    // Returns:
    //     true if the URL matches the specified regular expression; otherwise, false.
    public static Func<IWebDriver, bool> UrlMatches(string regex)
    {
        return (IWebDriver driver) =>
        {
            string url = driver.Url;
            return new Regex(regex, RegexOptions.IgnoreCase).Match(url).Success;
        };
    }

    //
    // Summary:
    //     An expectation for the URL of the current page to be a specific URL.
    //
    // Parameters:
    //   url:
    //     The URL that the page should be on.
    //
    // Returns:
    //     true when the URL is what it should be; otherwise, false.
    public static Func<IWebDriver, bool> UrlToBe(string url)
    {
        return (IWebDriver driver) => driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant());
    }

    //
    // Summary:
    //     An expectation for checking that all elements present on the web page that match
    //     the locator are visible. Visibility means that the elements are not only displayed
    //     but also have a height and width that is greater than 0.
    //
    // Parameters:
    //   locator:
    //     The locator used to find the element.
    //
    // Returns:
    //     The list of OpenQA.Selenium.IWebElement once it is located and visible.
    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
    {
        return (IWebDriver driver) =>
        {
            try
            {
                ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
                if (readOnlyCollection.Any((IWebElement element) => !element.Displayed))
                {
                    return null;
                }

                return readOnlyCollection.Any() ? readOnlyCollection : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    //
    // Summary:
    //     An expectation for checking that all elements present on the web page that match
    //     the locator are visible. Visibility means that the elements are not only displayed
    //     but also have a height and width that is greater than 0.
    //
    // Parameters:
    //   elements:
    //     list of WebElements.
    //
    // Returns:
    //     The list of OpenQA.Selenium.IWebElement once it is located and visible.
    public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
    {
        return delegate
        {
            try
            {
                if (elements.Any((IWebElement element) => !element.Displayed))
                {
                    return null;
                }

                return elements.Any() ? elements : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }

    private static IWebElement ElementIfVisible(IWebElement element)
    {
        if (!element.Displayed)
        {
            return null;
        }

        return element;
    }
}
