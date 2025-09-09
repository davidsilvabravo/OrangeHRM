using OpenQA.Selenium;
using OrangeHRM.Handler;
using System;


namespace OrangeHRM.PageObject{

    public class AddEmployeePage{

        // Driver
        protected IWebDriver Driver;

        // Locators
        protected By addButton = By.XPath("//button[normalize-space()='Add']"); 
        protected By firstName = By.CssSelector("input[name='firstName']");
        protected By lastName = By.CssSelector("input[name='lastName']");
        protected By employeeId = By.XPath("//label[text()='Employee Id']/following::input[1]");
        protected By cancelButton = By.XPath("//button[normalize-space()='Cancel']");
        protected By saveButton = By.XPath("//button[normalize-space()='Save']");
        protected By addEmployeeForm = By.CssSelector("[class='orangehrm-card-container']");
        protected By successMessage = By.XPath("//p[text()='Successfully Saved']");

        // Constructor
        public AddEmployeePage(IWebDriver driver){
            Driver = driver;
        }

        // Complete the form to create a new user
        public void AddEmployeeForm(String firstname, String lastname){

            try {
                Driver.FindElement(addButton).Click();
                Driver.FindElement(firstName).Clear();
                Driver.FindElement(firstName).SendKeys(firstname);
                Driver.FindElement(lastName).Clear();
                Driver.FindElement(lastName).SendKeys(lastname);
                Driver.FindElement(saveButton).Click();
                WaitHandler.ElementAvailable(Driver, successMessage);

            }
            catch (Exception e){
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error while trying to complete 'Add employee' form");
            }
        }

        public string GetSuccessMessage()
        {
            return Driver.FindElement(successMessage).Text;
        }

    }
}
