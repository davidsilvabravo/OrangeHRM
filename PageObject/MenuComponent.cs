using OpenQA.Selenium;


namespace OrangeHRM.PageObject
{

    public class MenuComponent
    {

        // Driver
        protected IWebDriver Driver;


        // Locators
        protected By menuAdmin = By.LinkText("Admin");
        protected By menuPIM = By.LinkText("PIM");
        protected By menuLeave = By.LinkText("Leave");
        protected By menuTime = By.LinkText("Time");
        protected By menuRecruitment = By.LinkText("Recruitment");
        protected By menuMyInfo = By.LinkText("My Info");
        protected By menuPerformance = By.LinkText("Performance");
        protected By menuDashboard = By.LinkText("Dashboard");
        protected By menuDirectory = By.LinkText("Directory");
        protected By menuMaintenance = By.LinkText("Maintenance");
        protected By menuClaim = By.LinkText("Claim");
        protected By menuBuzz = By.LinkText("Buzz");


        // Constructor
        public MenuComponent(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToAdmin()
        {
            Driver.FindElement(menuAdmin).Click();
        }

        public void GoToPIM()
        {
            Driver.FindElement(menuPIM).Click();
        }

    }
}
