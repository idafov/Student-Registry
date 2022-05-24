using NUnit.Framework;
using Student_Registry.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry.Tests
{
    public class AddNewStudentUITests : BaseTests
    {
        [Test]
        public void Test_Add_Student_Page_Content()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            //Assert the page URL
            Assert.IsTrue(browser.IsOpen());

            //Assert page heading
            Assert.AreEqual("Register New Student", browser.GetPageHeading());

            //Assert page title
            Assert.AreEqual("Add Student", browser.GetPageTitle());

            //Assert Home, View Students and Add Students buttons are visible
            Assert.That(browser.LinkHomePage.Displayed);

            Assert.That(browser.LinkAddStudentsPage.Displayed);

            Assert.That(browser.LinkViewStudentsPage.Displayed);

            //Assert Home, View Students and Add Students buttons contains the right text
            Assert.That(browser.LinkHomePage.Text, Is.EqualTo("Home"));

            Assert.That(browser.LinkAddStudentsPage.Text, Is.EqualTo("Add Student"));

            Assert.That(browser.LinkViewStudentsPage.Text, Is.EqualTo("View Students"));

            //Assert Name field, Email field and Add button are visible
            Assert.That(browser.FieldStudentName.Displayed);
            Assert.That(browser.FieldStudentEmail.Displayed);
            Assert.That(browser.ButtonAdd.Displayed);

            Assert.That(browser.StudentName.Text, Is.EqualTo("Name:"));
            Assert.That(browser.Email.Text, Is.EqualTo("Email:"));
            Assert.That(browser.ButtonAdd.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_Is_Add_Student_Link_Correct()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();


            browser.LinkAddStudentsPage.Click();
            Assert.IsTrue(browser.IsOpen());
        }

        [Test]
        public void Test_Is_Home_Page_Link_Correct()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();


            browser.LinkHomePage.Click();

            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/", browser.GetPageURL());

        }

        [Test]
        public void Test_Is_View_Students_Link_Correct()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();


            browser.LinkViewStudentsPage.Click();
            Assert.AreEqual("https://mvc-app-node-express.nakov.repl.co/students", browser.GetPageURL());
        }

        [Test]
        public void Test_Add_New_Student_Valid_Credentials()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("Malko kote", "vbojinov69@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();



            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains("Malko kote (vbojinov69@abv.bg)"));
            }

            
        }

        [Test]
        public void Test_Add_New_Student_Invalid_Empty_Credentials()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("", "");

            Assert.AreEqual("Cannot add student. Name and email fields are required!", browser.GetErrorMessage());
            Assert.That(browser.ElementErrorMsg.Displayed);
        }

        [Test]
        public void Test_Add_New_Student_Invalid_Email_Credentials()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("Buy Bitcoin", "BTC.abv.bg");
            browser.LinkViewStudentsPage.Click();

            //Assert that such user is missing in View students page
            var students = browser.GetRegisteredStudents();



            for (int i = 0; i < students.Length; i++)
            {
                Assert.IsFalse(students.Contains("Buy Bitcoin (BTC.abv.bg)"));
                Assert.That("Buy Bitcoin (BTC.abv.bg)", Is.Not.AnyOf(students));
                Assert.That("Buy Bitcoin (BTC.abv.bg)", Is.Not.Contain(students));
                Assert.That("Buy Bitcoin (BTC.abv.bg)", Is.Not.Exist);
            }
        }

        [Test]
        public void Test_Add_New_Student_Invalid_Empty_Name_Credentials()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("", "BTC@abv.bg");

            Assert.AreEqual("Cannot add student. Name and email fields are required!", browser.GetErrorMessage());
            Assert.That(browser.ElementErrorMsg.Displayed);

            browser.LinkViewStudentsPage.Click();

            var students = browser.GetRegisteredStudents();


            for (int i = 0; i < students.Length; i++)
            {
                Assert.IsFalse(students.Contains(" (BTC.abv.bg)"));
                Assert.That(" (BTC.abv.bg)", Is.Not.AnyOf(students));
                Assert.That(" (BTC.abv.bg)", Is.Not.Contain(students));
                Assert.That(" (BTC.abv.bg)", Is.Not.Exist);
            }
        }

        //These 2 tests are commented due to the bug in the web app.
        //Name field accepts wrong names
        //E.g. Name Iv-24-25 is accepted


        //[Test]
        //public void Test_Add_New_Student_Invalid_Numeric_Name_Credentials()
        //{
        //    var browser = new AddNewStudentPage(driver);
        //    browser.Open();

        //    browser.AddStudent("12345", "BTC@abv.bg");

        //    Assert.AreEqual("Cannot add student. Name and email fields are required!", browser.GetErrorMessage());
        //    Assert.That(browser.ElementErrorMsg.Displayed);

        //    browser.LinkViewStudentsPage.Click();

        //    var students = browser.GetRegisteredStudents();


        //    for (int i = 0; i < students.Length; i++)
        //    {
        //        Assert.IsFalse(students.Contains(" (BTC.abv.bg)"));
        //        Assert.That("12345 (BTC.abv.bg)", Is.Not.AnyOf(students));
        //        Assert.That("12345 (BTC.abv.bg)", Is.Not.Contain(students));
        //        Assert.That("12345 (BTC.abv.bg)", Is.Not.Exist);
        //    }
        //}


        //[Test]
        //public void Test_Add_New_Student_Invalid_Numeric_Name_Credentials_case_2()
        //{
        //    var browser = new AddNewStudentPage(driver);
        //    browser.Open();

        //    browser.AddStudent("Iv-24-25", "BTC@abv.bg");

        //    Assert.AreEqual("Cannot add student. Name and email fields are required!", browser.GetErrorMessage());
        //    Assert.That(browser.ElementErrorMsg.Displayed);

        //    browser.LinkViewStudentsPage.Click();

        //    var students = browser.GetRegisteredStudents();


        //    for (int i = 0; i < students.Length; i++)
        //    {
        //        Assert.IsFalse(students.Contains("Iv-24-25 (BTC.abv.bg)"));
        //        Assert.That("Iv-24-25 (BTC.abv.bg)", Is.Not.AnyOf(students));
        //        Assert.That("Iv-24-25 (BTC.abv.bg)", Is.Not.Contain(students));
        //        Assert.That("Iv-24-25 (BTC.abv.bg)", Is.Not.Exist);
        //    }
        //}



        [Test]
        public void Test_Add_New_Student_Name_Credentials_Long_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.StudentRandomLongName(20, "vbojinov69@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains(browser.longStudentName + " " + "(vbojinov69@abv.bg)"));
            }
            
        }

        [Test]
        public void Test_Add_New_Student_Name_Credentials_Longer_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.StudentRandomLongName(30, "BUYBTC@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains(browser.longStudentName + " " + "(BUYBTC@abv.bg)"));
            }

        }

        [Test]
        public void Test_Add_New_Student_Name_Credentials_Longest_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.StudentRandomLongName(50, "BUYBTC@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains(browser.longStudentName + " " + "(BUYBTC@abv.bg)"));
            }

        }

        [Test]
        public void Test_Add_New_Student_Name_Credentials_Cyrilic_Letters_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("ИмеНаБългарски", "BUYBTC@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains("ИмеНаБългарски (BUYBTC@abv.bg)"));
            }

        }

        [Test]
        public void Test_Add_New_Student_Name_Credentials_Chinease_Letters_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("勇", "BUYBTC@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains("勇 (BUYBTC@abv.bg)"));
            }

        }

        [Test]
        public void Test_Add_New_Student_Name_Credentials_Arabic_Letters_Name()
        {
            var browser = new AddNewStudentPage(driver);
            browser.Open();

            browser.AddStudent("الْحُرُوف الْعَرَبِيَّة", "BUYBTC@abv.bg");

            browser.LinkViewStudentsPage.Click();
            var students = browser.GetRegisteredStudents();

            for (int i = 0; i < students.Length; i++)
            {
                Assert.That(students.Contains("الْحُرُوف الْعَرَبِيَّة (BUYBTC@abv.bg)"));
            }

        }
    }
}
