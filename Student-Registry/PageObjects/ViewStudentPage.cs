using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace Student_Registry.PageObjects
{
    public class ViewStudentPage : BasePage
    {
        public ViewStudentPage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";


       

        
    }
}
