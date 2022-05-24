using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry.PageObjects

{
    public class BasePage
    {
        public virtual string PageUrl { get; }

        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public IWebElement LinkHomePage => driver.FindElement(By.CssSelector("body > a:nth-child(1)"));
        public IWebElement LinkViewStudentsPage => driver.FindElement(By.CssSelector("body > a:nth-child(3)"));
        public IWebElement LinkAddStudentsPage => driver.FindElement(By.CssSelector("body > a:nth-child(5)"));
        public IWebElement ElementTextHeading => driver.FindElement(By.CssSelector("body > h1"));
        
        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsOpen()
        {
            return this.driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeading()
        {
            return ElementTextHeading.Text;
        }

        public string GetPageURL()
        {
            return this.driver.Url;
        }
    }
}
