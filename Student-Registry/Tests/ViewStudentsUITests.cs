using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student_Registry.Tests
{
    public class ViewStudentsUITests : BaseTests
    {
        [Test]
        public void Test_View_Students_Page_Content()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();

            //Assert the page URL
            Assert.IsTrue(browser.IsOpen());

            //Assert page heading
            Assert.AreEqual("Registered Students", browser.GetPageHeading());

            //Assert page title
            Assert.AreEqual("Students", browser.GetPageTitle());

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
        public void Test_Is_View_Students_Link_Correct()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();


            browser.LinkViewStudentsPage.Click();
            Assert.IsTrue(browser.IsOpen());
        }

        [Test]
        public void Test_Is_Home_Page_Link_Correct()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();


            browser.LinkViewStudentsPage.Click();

            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/students", browser.GetPageURL());

        }

        [Test]
        public void Test_Is_Add_Student_Link_Correct()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();


            browser.LinkAddStudentsPage.Click();
            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/add-student", browser.GetPageURL());
        }

        [Test]
        public void Test_Current_Registered_Users_Num()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();
            var students = browser.GetRegisteredStudents();

            var studentTotalNumber = 0;

            for (int i = 0; i < students.Length; i++)
            {
                studentTotalNumber++;
            }

            Assert.AreEqual(studentTotalNumber, students.Length);
            
        }

        [Test]
        public void Test_Are_Current_Registered_Users_Displayed_Correctly()
        {
            var browser = new ViewStudentPage(driver);
            browser.Open();


            var students = browser.GetRegisteredStudents();
            foreach (var st in students)
            {
                Assert.IsTrue(st.Contains("("));
                Assert.IsTrue(st.Contains(")"));
                Assert.IsTrue(st.Contains("@"));
                Assert.IsTrue(st.Contains("."));
                Assert.That(st, Is.Not.Empty);
                
            }
        }

    }
}
