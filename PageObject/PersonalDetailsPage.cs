using OpenQA.Selenium;
using OrangeHRM.Handler;


namespace OrangeHRM.PageObject
{

    public class PersonalDetailsPage
    {

        // Driver
        protected IWebDriver Driver;


        // Locators
        protected By personalDetailsTitle = By.XPath("//h6[text()='Personal Details']");


        // Constructor
        public PersonalDetailsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitUntilPageIsLoaded()
        {
            WaitHandler.ElementAvailable(Driver, personalDetailsTitle);
        }
    }
}
