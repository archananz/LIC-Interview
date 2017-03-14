using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;
using Subscribe_Form_Project.Global;
using Subscribe_Form_Project.Pages;

namespace Subscribe_Form_Project
{
    [Binding]
    public class SubscribeFormSteps : IDisposable
    {
        IWebDriver driver;
        HomePage HmP;
        SubscribePage sf;
        Reporting report;
        
        public SubscribeFormSteps() {
            
            driver = DriverFactory.getBrowser("chrome");
            report = new Reporting("SubscribeFormPositiveTCReports");
            
        }

        [Given(@"I am on Subscriber page")]
        public void GivenIAmOnSubscriberPage()
        {
            sf = new SubscribePage(driver);
            HmP = new HomePage(driver);
            HmP.NavigateToHomePage(driver);
            HmP.SubscribeFormLink.Click();
          
        }

       [When(@"I enter name with value (.*) , email with value (.*)")]
        public void WhenIEnterNameWithValueTestEmailWithValueTestTest_Com(string name, string email)
        {
            
            sf.name.SendKeys(name);
            sf.email.SendKeys(email);
            Thread.Sleep(2000);
        }
        
        [When(@"I click on Subcribe Button")]
        public void WhenIClickOnSubcribeButton()
        {

            sf.subscribe.Click();
            Thread.Sleep(2000);
        }
        
        [Then(@"user should be subscribed and see the message ""(.*)""")]
        public void ThenUserShouldBeSubscribedAndSeeTheMessage(string message)
        {
            String Result = sf.Successmessage.Text;
            Assert.Equal(message,Result);
           report.addLog("SubscribeFormReports - Chrome browser", message.Equals(Result));        
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
