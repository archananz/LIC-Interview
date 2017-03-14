using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Subscribe_Form_Project.Global;
using Subscribe_Form_Project.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace Subscribe_Form_Project
{
    [Binding]
    public class SubscribeFormStepsNegativeTC : IDisposable
    {
        IWebDriver driver;
        HomePage HmP;
        SubscribePage sf;
        Reporting report;
        
        public SubscribeFormStepsNegativeTC() 
        {
            
            driver = DriverFactory.getBrowser("chrome");
            report = new Reporting("SubscribeFormNegativeTCReports");

        }
        [Given(@"Go to Subscriber Page")]
        public void GivenGoToSubscriberPage()
        {
            sf = new SubscribePage(driver);
            HmP = new HomePage(driver);
            HmP.NavigateToHomePage(driver);
            HmP.SubscribeFormLink.Click();
          
        }
        
        [When(@"I leave the name and email fields blank ,")]
        public void WhenILeaveTheNameAndEmailFieldsBlank()
        {
            sf.name.SendKeys("");
            sf.email.SendKeys("");

        }
        
        [When(@"I Click on Subscribe Button")]
        public void WhenIClickOnSubscribeButton()
        {
            sf.subscribe.Click();
        }
        
        [Then(@"user should not be able to subscribe and see the message ""(.*)""")]
        public void ThenUserShouldNotBeAbleToSubscribeAndSeeTheMessage(string message)
        {
            Thread.Sleep(2000);
            string Result = sf.NameFieldError.Text;

            Assert.Equal(message, Result);
            report.addLog("SubscribeFormReports - Chrome browser", message.Equals(Result));
           // Assert.Equal("Please Fill This Field", sf.EmailfieldError.Text);
        }
        public void Dispose()
        {
            try
            {
                DriverFactory.closeBrowsers();
                report.closeReport(report.tests);
            }
            catch (Exception e)
            {
            }
        }
    }
}
