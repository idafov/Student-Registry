using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void OneTimeShutDown()
        {
            driver.Quit();
        }
    }
}
