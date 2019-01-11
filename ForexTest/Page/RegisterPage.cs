using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexTest
{
    public class RegisterPage
    {
        //private readonly IWebDriver _driver;
        private const string PageUrl = "https://libertex.fxclub.org/";

        public RegisterPage(IWebDriver driver)
        {
            Driver.Instance = driver;

        }

        public static RegisterPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrl);
            return new RegisterPage(driver);
        }
        public void SignUp()
        {
           
                WebDriverWait wait = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='region-login']/div/p/span"))).Click();

            
        }

        public string Email
        {
            set
            {
                IWebElement Email;
                Email = Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/div[2]/form/div[1]/dl[1]/dd/input"));
                Email.SendKeys(value);
            }
        }
        public string Password
        {
            set
            {
                IWebElement Password;
                Password = Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/div[2]/form/div[1]/dl[2]/dd/input"));
                Password.SendKeys(value);
            }
        }
        public void Checkbox()
        {
        
                IWebElement checkbox;
                checkbox = Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/div[2]/form/div[1]/div/label[1]"));
                checkbox.Click();
            
        }

        public string SuccessMsg => Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/h2")).Text;
        public string ErrorMsg => Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/div[1]/div/div")).Text;

        public void RegisterButton()
        {

            IWebElement RegisterButton;
            RegisterButton = Driver.Instance.FindElement(By.XPath("//*[@id='modal']/div/div[2]/form/div[2]/input"));
            RegisterButton.Click();

        }
        public void Close()
        {
            Driver.Instance.Close();

        }

    }


}
