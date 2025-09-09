using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM.PageObject;
using OrangeHRM.Utils;
using System;


namespace OrangeHRM.Testcases{

    [TestFixture]
    public class Task1{

        protected IWebDriver Driver;

        [SetUp]
        public void BeforeTest() {
            //Open the page using the URL provided
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            Driver.Manage().Window.Maximize();
        }

      

        [Test]

        public void validLogin() {
            String username = "Admin";
            String password = "admin123";

            //LogIn 
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.FillLogInForm(username, password);
            DashboardPage dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitUntilPageIsLoaded();
            Assert.That(Driver.Url, Does.Contain("dashboard/index"));
        }

        [Test]
        public void invalidUserLogin() {
            String username = DataGenerator.RandomString(10); // invalid
            String password = "admin123";
            //LogIn 
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.FillLogInForm(username, password);
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo("Invalid credentials"));
        }

        [Test]
        public void invalidPasswordLogin() {
            String username = "Admin";
            String password = DataGenerator.RandomString(10); // invalid
            //LogIn 
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.FillLogInForm(username, password);
            Assert.That(logInPage.GetErrorMessage(), Is.EqualTo("Invalid credentials"));
        }
        
        [Test]
        public void createNewEmployee() {
            String username = "Admin";
            String password = "admin123";

            //LogIn 
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.FillLogInForm(username, password);


            //Create new employeee
            MenuComponent menuComponent = new MenuComponent(Driver);
            menuComponent.GoToPIM();
            AddEmployeePage addEmployeePage = new AddEmployeePage(Driver);
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            employeeListPage.WaitUntilPageIsLoaded();
            addEmployeePage.AddEmployeeForm(DataGenerator.RandomString(6), DataGenerator.RandomString(6));
            PersonalDetailsPage personalDetailsPage = new PersonalDetailsPage(Driver);
            personalDetailsPage.WaitUntilPageIsLoaded();
            Assert.That(Driver.Url, Does.Contain("pim/viewPersonalDetails"));
        }


        [Test]
        public void createNewUser() {
             String username = "Admin";
             String password = "admin123"; 
             String createdUsername = DataGenerator.RandomString(6); //it should have at least 5 characters
             String createdPassword = DataGenerator.RandomPassword(7); //it should have at least 1 number and at least 7 characters
             String lastname = DataGenerator.RandomString(6);
             String firstName = DataGenerator.RandomString(6);

            //LogIn 
             LogInPage logInPage = new LogInPage(Driver);
             logInPage.FillLogInForm(username, password);

             //Create new employeee
             MenuComponent menuComponent = new MenuComponent(Driver);
             menuComponent.GoToPIM();
             AddEmployeePage addEmployeePage = new AddEmployeePage(Driver);
             EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
             employeeListPage.WaitUntilPageIsLoaded();
             addEmployeePage.AddEmployeeForm(firstName, lastname);


            //Create new user for the created employee
             menuComponent.GoToAdmin();
             AdminManagementPage myAdminPage = new AdminManagementPage(Driver);
             myAdminPage.FillAddUserForm(firstName + " " + lastname, createdUsername, createdPassword);
             Assert.That(myAdminPage.GetSuccessMessage(), Is.EqualTo("Successfully Saved"));
        }
         
        [Test]
        public void deleteUser() {
             String username = "Admin";
             String password = "admin123";
             String createdUsername = DataGenerator.RandomString(6); //it should have at least 5 characters
             String firstName = DataGenerator.RandomString(6);
             String lastname = DataGenerator.RandomString(6);
             String createdPassword = DataGenerator.RandomPassword(7); //it should have at least 1 number and at least 7 characters

             //LogIn 
             LogInPage logInPage = new LogInPage(Driver);
             logInPage.FillLogInForm(username, password);

             //Create new employeee
             MenuComponent menuComponent = new MenuComponent(Driver);
             menuComponent.GoToPIM();
             AddEmployeePage addEmployeePage = new AddEmployeePage(Driver);
             EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
             employeeListPage.WaitUntilPageIsLoaded();
             addEmployeePage.AddEmployeeForm(firstName, lastname);

             //Create new user for the created employee
             menuComponent.GoToAdmin();
             AdminManagementPage myAdminPage = new AdminManagementPage(Driver);
             myAdminPage.WaitUntilPageIsLoaded();
             myAdminPage.FillAddUserForm(firstName + " " + lastname, createdUsername, createdPassword);

             //delete created user
             myAdminPage.WaitUntilPageIsLoaded();
             myAdminPage.SearchUser(createdUsername);
             myAdminPage.DeleteUser();
        }

        [Test]
        public void deleteEmployee() {
             String username = "Admin";
             String password = "admin123";
             String firstName = DataGenerator.RandomString(6);
             String lastname = DataGenerator.RandomString(6);

             //LogIn 
             LogInPage logInPage = new LogInPage(Driver);
             logInPage.FillLogInForm(username, password);

             //Create new employeee
             MenuComponent menuComponent = new MenuComponent(Driver);
             menuComponent.GoToPIM();
             EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
             employeeListPage.WaitUntilPageIsLoaded();
             AddEmployeePage addEmployeePage = new AddEmployeePage(Driver);
             addEmployeePage.AddEmployeeForm(firstName, lastname);


             //delete created employee
             menuComponent.GoToPIM();
             employeeListPage.WaitUntilPageIsLoaded();
             employeeListPage.DeleteEmployeeByName(firstName + " " + lastname);
             Assert.That(employeeListPage.GetSuccessDeletedEmployeeMessage(), Is.EqualTo("Successfully Deleted"));
        }

        [TearDown]
        public void AfterTest() {
             if (Driver != null)
                 Driver.Quit();
        }       
    }
}
