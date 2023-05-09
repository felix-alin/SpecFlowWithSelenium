using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.CommonModels;
using AngleSharp.Dom;

namespace IDNAutomaticTesting.StepDefinitions
{
    [Binding]
    public class LoginOnWebsiteStepDefinitions
    {

        private readonly ChromeDriver driver;
        public LoginOnWebsiteStepDefinitions() => driver = new ChromeDriver();

//Step 1
        [Given(@"I have navigated to the website")]
        public void GivenIHaveNavigatedToTheWebsite()
        {
            driver.Navigate().GoToUrl("yourIdentityNowPage");
        }

        [When(@"I input my username and password")]
        public void WhenIInputMyUsernameAndPassword()
        {
            driver.FindElement(By.Id("username")).SendKeys("inputUsername");
            driver.FindElement(By.Id("password")).SendKeys("inputPassword");
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("btn-label")).Click();
        }

        [Then(@"I end up on the IdentityNow dashboard")]
        public void ThenIEndUpOnTheIdentityNowDashboard()
        {
            Thread.Sleep(5000);

            //driver.Dispose();
            Console.WriteLine("Done");

            Thread.Sleep(3000);
        }
//Step 2
        [Given(@"I am logged in on the website")]
        public void GivenIAmLoggedInOnTheWebsite()
        {
            Thread.Sleep(4000);
            driver.Navigate().GoToUrl("yourIdentityNowPage");
            driver.FindElement(By.Id("username")).SendKeys("inputUsername");
            driver.FindElement(By.Id("password")).SendKeys("inputPassword");
            driver.FindElement(By.ClassName("btn-label")).Click();
        }

        [When(@"I press request center")]
        public void WhenIPressRequestCenter()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement requestCenter = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("slpt-nav-request-center")));
            requestCenter.Click();
        }


        [Then(@"I can request accesses")]
        public void ThenICanRequestAccesses()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement activeDirectory = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("app-request-card-Active Directory")));
            activeDirectory.Click();

            Thread.Sleep(5000);

            driver.Dispose();
        }
//Step 3
        [Given(@"User is logged in and on the request center")]
        public void GivenUserIsLoggedInAndOnTheRequestCenter()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("yourIdentityNowPage");
            driver.FindElement(By.Id("username")).SendKeys("inputUsername");
            driver.FindElement(By.Id("password")).SendKeys("inputPassword");
            driver.FindElement(By.ClassName("btn-label")).Click();

            IWebElement requestCenter = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("slpt-nav-request-center")));
            requestCenter.Click();

            Thread.Sleep(4000);

            IWebElement activeDirectory = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("app-request-card-Active Directory")));
            activeDirectory.Click();
        }

        [When(@"User request the VPN Consultant access profile")]
        public void WhenUserRequestTheVPNConsultantAccessProfile()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(2000);

            IWebElement requestAd = Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("slpt-btn-label")));
            requestAd.Click();
        }

        [Then(@"User sends request to manager")]
        public void ThenUserSendsRequestToManager()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(2000);

            IWebElement requestVPN = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("742d1f6a09bd4125b768ffaa6f4ca99e-option-742d1f6a09bd4125b768ffaa6f4ca99e")));
            requestVPN.Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("app-request-overlay-footer-Active Directory_submit")).Click();

            Thread.Sleep(4000);

            //driver.Dispose();

            //Thread.Sleep(4000);
        }
//Step 4
        [Given(@"Manager is logged in")]
        public void GivenManagerIsLoggedIn()
        {

            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("yourIdentityNowPage");
            driver.FindElement(By.Id("username")).SendKeys("inputUsername2");
            driver.FindElement(By.Id("password")).SendKeys("inputPassword2");
            driver.FindElement(By.ClassName("btn-label")).Click();
        }

        [When(@"Manager sees that user has requested access")]
        public void WhenManagerSeesThatUserHasRequestedAccess()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(6000);
            IWebElement approval = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("app-approvals-widget")));
            approval.Click();
        }

        [Then(@"Manager approves the access request")]
        public void ThenManagerApprovesTheAccessRequest()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //try
            /*{
                IWebElement applicationCard = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("requested-item-card-VPN Consultants")));
                applicationCard.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Thread.Sleep(4000);
                driver.Navigate().Refresh();
                driver.FindElement(By.Id("requested-item-card-VPN Consultants")).Click();
            }

            */
            IWebElement applicationCard = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("requested-item-card-VPN Consultants")));
            applicationCard.Click();

            Thread.Sleep(4000);

            IWebElement acceptRequest = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("requested-item-decision-overlay-footer-VPN Consultants_approve")));
            acceptRequest.Click();


            Thread.Sleep(2000);

            driver.Dispose();

            Thread.Sleep(4000);
        }
//Step 5

        [Given(@"Admin is logged in")]
        public void GivenAdminIsLoggedIn()
        {

            driver.Navigate().GoToUrl("yourIdentityNowPage");
            driver.FindElement(By.Id("username")).SendKeys("inputUsername3");
            driver.FindElement(By.Id("password")).SendKeys("inputPassword3");
            driver.FindElement(By.ClassName("btn-label")).Click();

            Thread.Sleep(10000);
        }

        [Then(@"Admin approves the access request")]
        public void ThenAdminApprovesTheAccessRequest()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //driver.Navigate().Refresh();
            //driver.Navigate().Refresh();

            IWebElement approval = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("app-approvals-widget")));
            approval.Click();
            driver.Navigate().Refresh();

            Thread.Sleep(10000);

            IWebElement approveRequest = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("requested-item-card-footer-VPN Consultants_approve")));
            approveRequest.Click();

            Thread.Sleep(5000);

            driver.Dispose();
        }

//Step 6
//reuses the "Manager is logged in" from Step 4


        [When(@"Manager access her team")]
        public void WhenManagerAccessHerTeam()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement myTeam = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("app-team-widget")));
            myTeam.Click();
        }

        [When(@"Manager goes to user")]
        public void WhenManagerGoesToUser()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement accessProfile = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("tab3")));
                accessProfile.Click();

                //driver.FindElement(By.Id("access-revoke_submit")).Click();
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(2000);
                //driver.Navigate().Refresh();

                //driver.FindElement(By.Id("tab3")).Click();
                IWebElement accessProfilee = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("tab3")));
                accessProfilee.Click();
            };
        }
        [Then(@"Manager request the removal of VPN Consultant from user")]
        public void ThenManagerRequestTheRemovalOfVPNConsultantFromUser()
        {
            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement requestRemoveAccessProfile = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("access-grid-revoke-button-742d1f6a09bd4125b768ffaa6f4ca99e")));
            requestRemoveAccessProfile.Click();

            try
            {
                IWebElement sendRequest = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.slpt-form-input-container textarea")));
                sendRequest.SendKeys("No need for access");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timeout error");
            }

            IWebElement submitRequest = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("access-revoke_submit")));
            submitRequest.Click();

        }
    }
}
