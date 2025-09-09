using OpenQA.Selenium;
using OrangeHRM.Handler;


namespace OrangeHRM.PageObject
{

    public class DashboardPage
    {

        // Driver
        protected IWebDriver Driver;


        // Locators
        protected By dashboardTitle = By.XPath("//h6[text()='Dashboard']");


        // Constructor
        public DashboardPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitUntilPageIsLoaded()
        {
            WaitHandler.ElementAvailable(Driver, dashboardTitle);
        }
    }
}
