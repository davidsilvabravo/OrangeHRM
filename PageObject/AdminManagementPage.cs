using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Handler;
using System;


namespace OrangeHRM.PageObject{

    public class AdminManagementPage{

        // Driver
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        // Locators
        // SystemUsersSearcher
        protected By userManagementHeader = By.CssSelector("h6.oxd-topbar-header-breadcrumb-level");
        protected By addButton = By.XPath("//button[normalize-space()='Add']");
        protected By resetButton = By.XPath("//button[normalize-space()='Reset']");
        protected By searchButton = By.XPath("//button[normalize-space()='Search']");
        protected By usernameInput = By.XPath("//label[text()='Username']/following::input[1]");
        protected By recordsFoundResult = By.XPath("//div[@class='oxd-table-card']");
        protected By deleteUserButton = By.CssSelector("[class='oxd-icon bi-trash']");
        protected By deletePopUpButton = By.XPath("//button[normalize-space()='Yes, Delete']");
        protected By cancelPopUpButton = By.XPath("//button[normalize-space()='No, Cancel']");
        protected By successMessage = By.XPath("//p[text()='Successfully Saved']");
        protected By deletedUserMessage = By.XPath("//p[text()='Successfully Deleted']");

        // AddUserForm
        protected By userRoleDropdown = By.XPath("//label[text()='User Role']/following::div[@class='oxd-select-text-input'][1]");
        protected By statusDropdown = By.XPath("//label[text()='Status']/following::div[@class='oxd-select-text-input'][1]");
        protected By EmployeeNameInput = By.XPath("//label[text()='Employee Name']/following::input[1]");
        protected By PasswordInput = By.XPath("//label[text()='Password']/following::input[1]");
        protected By ConfirmPasswordInput = By.XPath("//label[text()='Confirm Password']/following::input[1]");
        protected By saveButton = By.XPath("//button[normalize-space()='Save']");

        // generic Option (role="option")
        protected By OptionBy(string text) => By.XPath($"//div[@role='option' and normalize-space()='{text}']");



        // Constructor
        public AdminManagementPage(IWebDriver driver, int waitSeconds = 10)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));

        }

        public void WaitUntilPageIsLoaded()
        {
            WaitHandler.ElementAvailable(Driver, userManagementHeader);
        }

        public void SearchUser(String findUser)
        {

            try
            {

                Driver.FindElement(usernameInput).SendKeys(findUser);
                Driver.FindElement(searchButton).Click();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElements(recordsFoundResult).Count == 1);
                var rows = Driver.FindElements(recordsFoundResult);
                int rowCount = rows.Count;               
                Assert.That(rowCount, Is.EqualTo(1));

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error while trying to search the new user");
            }
        }

        private void SelectOption(string optionText)
        {
            Driver.FindElement(OptionBy(optionText)).Click();
        }


        public void FillAddUserForm(String employee, String username, String password)
        {

            try{

                Driver.FindElement(addButton).Click();
                Driver.FindElement(userRoleDropdown).Click();
                SelectOption("Admin");
                Driver.FindElement(statusDropdown).Click();
                SelectOption("Enabled");
                Driver.FindElement(EmployeeNameInput).Clear();
                Driver.FindElement(EmployeeNameInput).SendKeys(employee);
                SelectOption(employee);
                Driver.FindElement(usernameInput).Clear();
                Driver.FindElement(usernameInput).SendKeys(username);
                Driver.FindElement(PasswordInput).Clear();
                Driver.FindElement(PasswordInput).SendKeys(password);
                Driver.FindElement(ConfirmPasswordInput).Clear();
                Driver.FindElement(ConfirmPasswordInput).SendKeys(password);
                Driver.FindElement(saveButton).Click();

            }
            catch (Exception e){
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error while trying to create the new user");
            }
        }

        public string GetSuccessMessage()
        {
            WaitHandler.ElementAvailable(Driver, successMessage);
            return Driver.FindElement(successMessage).Text;
        }

        public void DeleteUser()
        {

            try
            {

                Driver.FindElement(deleteUserButton).Click();
                Driver.FindElement(deletePopUpButton).Click();
                WaitHandler.ElementAvailable(Driver, deletedUserMessage);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error while trying to delete the new user");
            }
        }
    }
}
