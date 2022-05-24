using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry.PageObjects
{
    public class AddNewStudentPage : BasePage
    {
        public AddNewStudentPage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldStudentName => driver.FindElement(By.Id("name"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.Id("email"));
        public IWebElement ButtonAdd => driver.FindElement(By.CssSelector("body > form > button"));

        public IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));

        public IWebElement StudentName => driver.FindElement(By.CssSelector("body > form > div:nth-child(1) > label"));

        public IWebElement Email => driver.FindElement(By.CssSelector("body > form > div:nth-child(2) > label"));

        

        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.Click();
            this.FieldStudentName.SendKeys(name);

            this.FieldStudentEmail.Click();
            this.FieldStudentEmail.SendKeys(email);

            this.ButtonAdd.Click();
        }

        public string GetErrorMessage()
        {
            return this.ElementErrorMsg.Text;
        }

        
        public void StudentRandomLongName(int nameLenght, string email)
        {
            this.FieldStudentName.Click();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            longStudentName = new string(Enumerable.Repeat(chars, nameLenght)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            this.FieldStudentName.SendKeys(longStudentName);

            this.FieldStudentEmail.Click();
            this.FieldStudentEmail.SendKeys(email);

            this.ButtonAdd.Click();
        }
    }
}
