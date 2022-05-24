using NUnit.Framework;
using OpenQA.Selenium;
using Student_Registry.PageObjects;
using Student_Registry.Tests;
using System.Threading;

namespace Student_Registry
{
    public class HomePageUITests : BaseTests
    {
       

       [Test]
       public void Test_Home_Page_Content()
        {
            var browser = new HomePage(driver);
            browser.Open();

            //Assert page URL
            Assert.IsTrue(browser.IsOpen());
            

            //Assert page heading
            Assert.AreEqual("Students Registry", browser.GetPageHeading());

            //Assert page title
            Assert.AreEqual("MVC Example", browser.GetPageTitle());

            //Assert Home, View Students and Add Students buttons are visible
            Assert.That(browser.LinkHomePage.Displayed);

            Assert.That(browser.LinkAddStudentsPage.Displayed);

            Assert.That(browser.LinkViewStudentsPage.Displayed);

            //Assert Home, View Students and Add Students buttons contains the right text
            Assert.That(browser.LinkHomePage.Text, Is.EqualTo("Home"));

            Assert.That(browser.LinkAddStudentsPage.Text, Is.EqualTo("Add Student"));

            Assert.That(browser.LinkViewStudentsPage.Text, Is.EqualTo("View Students"));
        }

        [Test]
        public void Test_Is_Home_Page_Link_Correct()
        {
            var browser = new HomePage(driver);
            browser.Open();

            
            browser.LinkHomePage.Click();
            Assert.IsTrue(browser.IsOpen());
        }

        [Test]
        public void Test_Is_View_Students_Link_Correct()
        {
            var browser = new HomePage(driver);
            browser.Open();


            browser.LinkViewStudentsPage.Click();
            
            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/students", browser.GetPageURL());
           
        }

        [Test]
        public void Test_Is_Add_Student_Link_Correct()
        {
            var browser = new HomePage(driver);
            browser.Open();


            browser.LinkAddStudentsPage.Click();
            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/add-student", browser.GetPageURL());
        }
    }
}