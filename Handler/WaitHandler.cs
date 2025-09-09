using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace OrangeHRM.Handler
{
    public static class WaitHandler{

        //Method to wait (up to 10s) for an element to become available
        public static IWebElement ElementAvailable(IWebDriver driver, By locator){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = null;
            Func<IWebDriver, bool> condition =
                d =>
                {
                    webElement = d.FindElement(locator);
                    return webElement.Displayed && webElement.Enabled;
                };
            wait.Until(condition);
            return webElement;
        }
    }
}
