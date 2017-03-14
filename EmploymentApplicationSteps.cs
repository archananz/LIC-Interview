using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using EmploymentApplication_Form_Project.Pages;
using Subscribe_Form_Project.Pages;
using Subscribe_Form_Project.Global;
using RelevantCodes.ExtentReports;

namespace Subscribe_Form_Project
{
    [Binding]
    public class EmploymentApplicationSteps : IDisposable
    {
        IWebDriver driver;
        EmploymentApplicationForm Emp;
        HomePage HmP;
        Reporting report;
      
        public EmploymentApplicationSteps()
        {
            driver = DriverFactory.getBrowser("chrome");
            report = new Reporting("EmploymentApplicationReportsPositiveTC");
        }

        [Given(@"I am on Employment Application Page")]
        public void GivenIAmOnEmploymentApplicationPage()
        {
            Emp = new EmploymentApplicationForm(driver);
            HmP = new HomePage(driver);
            HmP.NavigateToHomePage(driver);
            HmP.EmpAppLink.Click();
        }
        
        [When(@"I enter details with values (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIEnterDetailsWithValues(string firstname, string lastname, string email, string address, string website, 
                                                string Position, string education, string relocation, string salary, string AttachResume)
        {
          Emp.submitForm( firstname,  lastname,  email,  address,  website,  Position,  education,  relocation,  salary,  AttachResume);
        }
        
        [When(@"I click on Submit Button")]
        public void WhenIClickOnSubmitButton()
        {
            Emp.SubmitButton.Click();
        }
        
        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string message)
        {
            Thread.Sleep(3000);
            string Result = Emp.SuccessMessage.Text;
            Assert.Equal(message, Result);
           report.addLog("Employment Application Form - Chrome Browser", message.Equals(Result));       
        }

        public void Dispose()
        {
            try
            {
                DriverFactory.closeBrowsers();
                report.closeReport(report.tests);
            }
            catch (Exception)
            {
            }
        }
    }
}
