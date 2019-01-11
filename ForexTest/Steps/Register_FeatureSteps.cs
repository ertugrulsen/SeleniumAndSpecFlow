using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;


namespace ForexTest.Steps
{
    [Binding]
    public class Register_FeatureSteps
    {

        private RegisterPage _RegisterPage;
        //private IWebDriver _driver;


        
        

        [Given(@"User is at home page")]
        public void GivenUserİsAtHomePage()
        {

            Driver.Initialize();

            //_driver = new ChromeDriver();
            // Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //_driver.Manage().Window.Maximize();
            _RegisterPage = RegisterPage.NavigateTo(Driver.Instance);


        }

        [Given(@"user click signup button")]
        public void GivenUserClickSignupButton()
        {
            _RegisterPage.SignUp();
            
        }

        [When(@"user enter email'(.*)' and password '(.*)'")]
        public void WhenUserEnterEmailAndPassword(string email, string password)
        {

            Driver.Instance.SwitchTo().ActiveElement();
            Thread.Sleep(3000);
            _RegisterPage.Email = email;
            _RegisterPage.Password = password;

        }

        [When(@"Click on the checkbox button")]
        public void WhenClickOnTheCheckboxButton()
        {
            _RegisterPage.Checkbox();
        }
        

        [When(@"Click on the register button")]
        public void WhenClickOnTheRegisterButton()
        {
            _RegisterPage.RegisterButton();
            Driver.Instance.SwitchTo().DefaultContent();

        }

        [Then(@"Succesful register message should display")]
        public void ThenSuccesfulRegisterMessageShouldDisplay()
        {
            Driver.Instance.SwitchTo().ActiveElement();
            Assert.Equal("Welcome to Libertex!", _RegisterPage.SuccessMsg);
        }

        [Then(@"user should see an error message")]
        public void ThenUserShouldSeeAnErrorMessage()
        {
            Driver.Instance.SwitchTo().ActiveElement();
            Assert.Equal("This email address is already registered. Please specify another one.", _RegisterPage.ErrorMsg);


        }

        [AfterScenario]
        public void Close()
        {
            _RegisterPage.Close();
        }
    }
}
