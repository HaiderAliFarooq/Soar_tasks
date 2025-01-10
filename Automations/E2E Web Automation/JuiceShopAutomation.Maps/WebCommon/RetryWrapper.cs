using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using JuiceShopAutomation.Maps.Interface;

namespace JuiceShopAutomation.Maps.Runner;

public class RetryWrapper : RetryLocator, IPageActionWrapper
{
    public RetryWrapper(IWebDriver driver)
        : base(driver)
    {
    }

    public void Click(IWebElement element)
    {
        bool flag = true;
        for (int i = 0; i < 6; i++)
        {
            flag = HandleClick(element);
            if (flag)
            {
                break;
            }

            Thread.Sleep(1000);
        }

        if (!flag)
        {
            throw new Exception("Could not click on Web element: " + element.GetAttribute("outerHTML"));
        }
    }

    public void DropdownSelect(IWebElement element, string option, string selectBy = "text")
    {
        if (option.ToLower() == "#skip")
        {
            return;
        }

        bool flag = true;
        for (int i = 0; i < 6; i++)
        {
            Click(element);
            flag = HandleDropdownSelect(element, option, selectBy);
            if (flag)
            {
                break;
            }

            Thread.Sleep(1000);
        }

        if (flag)
        {
            return;
        }

        throw new Exception("Could not select the value drop dropdown list on Web element: " + element.GetAttribute("outerHTML"));
    }

    public void CheckboxSelect(IWebElement element, string markAsChecked)
    {
        if (markAsChecked.ToLower() == "#skip")
        {
            return;
        }

        bool flag = true;
        for (int i = 0; i < 6; i++)
        {
            flag = HandleCheckboxSelect(element, markAsChecked.ToLower());
            if (flag)
            {
                break;
            }

            Thread.Sleep(500);
        }

        if (flag)
        {
            return;
        }

        throw new Exception("Could not checked the value from checkbox element: " + element.GetAttribute("outerHTML"));
    }

    public void EnterText(IWebElement element, string value, bool clearText = false)
    {
        if (value.ToLower() == "#skip")
        {
            return;
        }

        bool flag = true;
        for (int i = 0; i < 6; i++)
        {
            flag = HandleEnteringText(element, value, clearText);
            if (flag)
            {
                break;
            }

            Thread.Sleep(1000);
        }

        if (flag)
        {
            return;
        }

        throw new Exception("Could not enter text " + value + " to Web element: " + element.GetAttribute("outerHTML"));
    }

    public string GetAttributeValue(IWebElement element, string attributeName, string expectedValue = "#skip")
    {
        bool flag = true;
        string text = null;
        for (int i = 0; i < 3; i++)
        {
            text = HandleGetAttributeValue(element, attributeName);
            if (text != null && (text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase) || expectedValue.Equals("#skip", StringComparison.OrdinalIgnoreCase)))
            {
                flag = true;
                break;
            }

            Thread.Sleep(500);
            flag = false;
        }

        if (!flag)
        {
            throw new Exception("Could not retrieve attribute value " + attributeName + " from Web element: " + element.GetAttribute("outerHTML"));
        }

        return text;
    }

    public string GetPropertyValue(IWebElement element, string propertyName, string expectedValue = "#skip")
    {
        bool flag = true;
        string text = null;
        for (int i = 0; i < 3; i++)
        {
            text = HandleGetPropertyValue(element, propertyName);
            if (text != null && (text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase) || expectedValue.Equals("#skip", StringComparison.OrdinalIgnoreCase)))
            {
                flag = true;
                break;
            }

            Thread.Sleep(500);
            flag = false;
        }

        if (!flag)
        {
            throw new Exception("Could not retrieve property value " + propertyName + " from Web element: " + element.GetAttribute("outerHTML"));
        }

        return text;
    }

    public string GetCssValue(IWebElement element, string attributeName, string expectedValue = "#skip")
    {
        bool flag = true;
        string text = null;
        for (int i = 0; i < 3; i++)
        {
            text = HandleGetCssValue(element, attributeName);
            if (text != null && (text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase) || expectedValue.Equals("#skip", StringComparison.OrdinalIgnoreCase)))
            {
                flag = true;
                break;
            }

            Thread.Sleep(500);
            flag = false;
        }

        if (!flag)
        {
            throw new Exception("Could not retrieve css value " + attributeName + " from Web element: " + element.GetAttribute("outerHTML"));
        }

        return text;
    }

    public bool GetState(IWebElement element, string state)
    {
        bool flag = true;
        string text = null;
        for (int i = 0; i < 3; i++)
        {
            text = HandleGetState(element, state);
            if (text != null)
            {
                flag = true;
                break;
            }

            Thread.Sleep(500);
            flag = false;
        }

        if (!flag)
        {
            throw new Exception("Could not retrieve state " + state + " value from Web element: " + element.GetAttribute("outerHTML"));
        }

        return bool.Parse(text);
    }

    public string GetText(IWebElement element, string expectedValue = "#skip")
    {
        bool flag = true;
        string text = null;
        for (int i = 0; i < 3; i++)
        {
            text = HandleGetText(element);
            if (text != null && (text.Equals(expectedValue, StringComparison.OrdinalIgnoreCase) || expectedValue.Equals("#skip", StringComparison.OrdinalIgnoreCase)))
            {
                flag = true;
                break;
            }

            Thread.Sleep(500);
            flag = false;
        }

        if (!flag)
        {
            throw new Exception("Could not retrieve text from Web element: " + element.GetAttribute("outerHTML"));
        }

        return text;
    }

    public void MouseHover(IWebElement element)
    {
        bool flag = true;
        for (int i = 0; i < 3; i++)
        {
            flag = HandleMouseHoverAction(element, GetAction());
            if (flag)
            {
                break;
            }

            Thread.Sleep(1000);
        }

        if (!flag)
        {
            throw new Exception("Could not perform mouse hover on Web element: " + element.GetAttribute("outerHTML"));
        }
    }

    public void HoverAndClick(IWebElement element, string option, string selectBy = "text")
    {
        if (option.ToLower() == "#skip")
        {
            return;
        }

        bool flag = false;
        for (int i = 0; i < 3; i++)
        {
            HandleMouseHoverAction(element, GetAction());
            flag = HandleDropdownSelect(element, option, selectBy);
            if (flag)
            {
                break;
            }

            Thread.Sleep(1000);
        }

        if (flag)
        {
            return;
        }

        throw new Exception("Could not perform mouse hover or select from dropdown list on Web element: " + element.GetAttribute("outerHTML"));
    }

    public void ClosePopup()
    {
        GetJsExecutor().ExecuteScript("window.confirm = function(msg) { return true; }");
    }

    private bool HandleClick(IWebElement element)
    {
        try
        {
            element.Click();
            return true;
        }
        catch (Exception value)
        {
            return false;
        }
    }

    private string HandleGetState(IWebElement element, string state)
    {
        string result;
        try
        {
            result = state.ToLower().Trim() switch
            {
                "enabled" => element.Enabled.ToString(),
                "selected" => element.Selected.ToString(),
                "displayed" => element.Displayed.ToString(),
                _ => null,
            };
        }
        catch (Exception ex)
        {
            result = null;
        }

        return result;
    }

    private bool HandleDropdownSelect(IWebElement element, string option, string selectBy)
    {
        bool result;
        try
        {
            switch (selectBy.ToLower().Trim())
            {
                case "xpath":
                    Click(FindElement(By.XPath(option)));
                    result = true;
                    break;
                case "relativexpath":
                    Click(FindElement(By.XPath("//*[contains(text(),  '" + option + "')]")));
                    result = true;
                    break;
                case "text":
                    {
                        string value = GenerateXpath(element);
                        Click(FindElement(By.XPath($"({value})/..//*[contains(text(), '{option}')]")));
                        result = true;
                        break;
                    }
                case "value":
                    {
                        string value = GenerateXpath(element);
                        Click(FindElement(By.XPath($"({value})/..//*[contains(@value,  '{option}')]")));
                        result = true;
                        break;
                    }
                default:
                    Click(FindElement(By.XPath($"//*[contains(@{selectBy},  '{option}')]")));
                    result = true;
                    break;
            }
        }
        catch (Exception ex)
        {
            result = false;
        }

        return result;
    }

    private string GenerateXpath(IWebElement childElement, string current = "")
    {
        string tagName = childElement.TagName;
        if (tagName.Equals("html"))
        {
            return "/html[1]" + current;
        }

        IWebElement webElement = childElement.FindElement(By.XPath(".."));
        ReadOnlyCollection<IWebElement> readOnlyCollection = webElement.FindElements(By.XPath("*"));
        int num = 0;
        for (int i = 0; i < readOnlyCollection.Count; i++)
        {
            IWebElement webElement2 = readOnlyCollection[i];
            string tagName2 = webElement2.TagName;
            if (tagName.Equals(tagName2))
            {
                num++;
            }

            if (childElement.Equals(webElement2))
            {
                return GenerateXpath(webElement, "/" + tagName + "[" + num + "]" + current);
            }
        }

        return null;
    }

    private bool HandleCheckboxSelect(IWebElement element, string select)
    {
        bool result = true;
        try
        {
            bool selected = element.Selected;
            string text = select.ToLower().Trim();
            if (!(text == "true"))
            {
                if (text == "false")
                {
                    if (selected)
                    {
                        Click(element);
                    }
                }
                else
                {
                    result = false;
                }
            }
            else if (!selected)
            {
                Click(element);
            }
        }
        catch (Exception ex)
        {
            result = false;
        }

        return result;
    }

    private bool HandleEnteringText(IWebElement element, string value, bool clearText)
    {
        try
        {
            if (clearText)
            {
                element.Clear();
            }

            element.SendKeys(value);
            return true;
        }
        catch (Exception value2)
        {
            return false;
        }
    }

    private string HandleGetAttributeValue(IWebElement element, string attributeName)
    {
        string result = null;
        try
        {
            result = element.GetAttribute(attributeName);
        }
        catch (Exception value)
        {
        }

        return result;
    }

    private string HandleGetPropertyValue(IWebElement element, string propertyName)
    {
        string result = null;
        try
        {
            result = element.GetDomProperty(propertyName);
        }
        catch (Exception value)
        {
        }

        return result;
    }

    private string HandleGetCssValue(IWebElement element, string attributeName)
    {
        string result = null;
        try
        {
            result = element.GetCssValue(attributeName);
        }
        catch (Exception value)
        {
        }

        return result;
    }

    private string HandleGetText(IWebElement element)
    {
        string result = null;
        try
        {
            result = element.Text;
        }
        catch (Exception value)
        {
        }

        return result;
    }

    private bool HandleMouseHoverAction(IWebElement element, Actions action)
    {
        try
        {
            action.MoveToElement(element).Perform();
            return true;
        }
        catch (Exception value)
        {
            return false;
        }
    }
}