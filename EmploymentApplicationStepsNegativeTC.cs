using EmploymentApplication_Form_Project.Pages;
using OpenQA.Selenium;
using Subscribe_Form_Project.Global;
using Subscribe_Form_Project.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace Subscribe_Form_Project
{
    [Binding]
    public class EmploymentApplicationStepsNegativeTC : IDisposable
    {
        IWebDriver driver;
        EmploymentApplicationForm Emp1;
        HomePage HmP;
        Reporting report;
         
        public EmploymentApplicationStepsNegativeTC()
        {
            driver = DriverFactory.getBrowser("chrome");
            report = new Reporting("EmploymentApplicationNegativeTCReports");
        }
        [Given(@"Go to Employment Application Form")]
        public void GivenGoToEmploymentApplicationForm()
        {
            Emp1 = new EmploymentApplicationForm(driver);
            HmP = new HomePage(driver);
            HmP.NavigateToHomePage(driver);
            HmP.EmpAppLink.Click();
            Thread.Sleep(2000);
        }
        
        [When(@"I enter values only in non-mandatory fields  (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIEnterValuesOnlyInNon_MandatoryFieldsGrantRoadHttpsWww_Linkedin_ComMasterNo(string firstname, string lastname, string email, string address, string website, string Position, string education, string relocation, string salary, string AttachResume)
        {
            Emp1.submitForm(firstname, lastname, email, address, website, Position, education, relocation, salary, AttachResume);
        }
        
        [When(@"click on Submit Button")]
        public void WhenClickOnSubmitButton()
        {
            Thread.Sleep(3000);
            Emp1.SubmitButton.Click(); 
        }
        
        [Then(@"display message ""(.*)""")]
        public void ThenDisplayMessage(string p0)
        {
            Thread.Sleep(3000);
            Assert.Equal("Please Fill This Field", Emp1.FirstNameBlank.Text);
        }

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }
    }
}
