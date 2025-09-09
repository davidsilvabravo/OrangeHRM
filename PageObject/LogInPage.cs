using OpenQA.Selenium;
using System;


namespace OrangeHRM.PageObject{

    public class LogInPage{

        // Driver
        protected IWebDriver Driver;


        // Locators
        protected By username = By.CssSelector("input[name='username']");
        protected By password = By.CssSelector("input[name='password']");
        protected By logInButton = By.CssSelector("button[type='submit']");
        protected By loginErrorMessage = By.CssSelector("p.oxd-text.oxd-text--p.oxd-alert-content-text");


        // Constructor
        public LogInPage(IWebDriver driver){
            Driver = driver;
        }


        public void FillLogInForm(string user, string pass)
        {

            try{

                Driver.FindElement(username).Clear();
                Driver.FindElement(username).SendKeys(user);
                Driver.FindElement(password).Clear();
                Driver.FindElement(password).SendKeys(pass);
                Driver.FindElement(logInButton).Click();

            }
            catch (Exception e){
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error when trying to complete LogIn form");
            }
        }

        public string GetErrorMessage()
        {

            try
            {
                return Driver.FindElement(loginErrorMessage).Text;

            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
