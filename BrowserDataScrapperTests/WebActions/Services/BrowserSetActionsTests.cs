using BrowserDataScrapper.WebActions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserDataScrapper.AutomationActions.Services;
using BrowserDataScrapper.AutomationActions;

namespace BrowserDataScrapper.WebActions.Services.Tests
{
    [TestClass()]
    public class BrowserSetActionsTests
    {

        [TestMethod()]
        public void InvokeJavascriptTest_SimpleJSCommand()
        {
            //Arrange
            string url = "https://www.google.com";
            var expectedResult = "Action has been successfully performed on the website.";
            var jsToRun = "javascript:alert('Hello World');";
            BrowserGeneralActions browserGeneralActions = new BrowserGeneralActions();
            BrowserSetActions browserSetActions = new BrowserSetActions();

            //Act
            var result = browserSetActions.InvokeJavascript(url, jsToRun);

            //Assert
            Assert.IsTrue(result.Contains(expectedResult), "The result does not contain the expected success message.");
        }

        
    }
}