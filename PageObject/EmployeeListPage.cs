using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Handler;
using System;


namespace OrangeHRM.PageObject
{
    public class EmployeeListPage
    {

        // Driver
        protected IWebDriver Driver;

        // Locators
        protected By employeeName = By.XPath("//label[text()='Employee Name']/following::input[1]");
        protected By recordsFoundResult = By.XPath("//div[@class='oxd-table-card']");
        protected By searchButton = By.XPath("//button[normalize-space()='Search']");
        protected By deleteButton = By.CssSelector("[class='oxd-icon bi-trash']");
        protected By deletePopUpButton = By.XPath("//button[normalize-space()='Yes, Delete']");
        protected By pageTitle = By.XPath("//h5[text()='Employee Information']");
        protected By deletedEmployeeMessage = By.XPath("//p[text()='Successfully Deleted']");

        // generic Option (role="option")
        protected By OptionBy(string text) => By.XPath($"//div[@role='option' and normalize-space()='{text}']");

        // Constructor
        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitUntilPageIsLoaded()
        {
            WaitHandler.ElementAvailable(Driver, pageTitle);
        }

        private void SelectOption(string optionText)
        {
            Driver.FindElement(OptionBy(optionText)).Click();
        }

        public void DeleteEmployeeByName(string employee)
        {

            try
            {

                Driver.FindElement(employeeName).SendKeys(employee);
                SelectOption(employee);
                Driver.FindElement(searchButton).Click();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElements(recordsFoundResult).Count == 1);
                var rows = Driver.FindElements(recordsFoundResult);
                int rowCount = rows.Count;
                Assert.That(rowCount, Is.EqualTo(1));
                Driver.FindElement(deleteButton).Click();
                Driver.FindElement(deletePopUpButton).Click();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error while trying to delete Employe by Name");
            }
        }

        public string GetSuccessDeletedEmployeeMessage()
        {
            return Driver.FindElement(deletedEmployeeMessage).Text;
        }
    }
}
