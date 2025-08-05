using BrowserDataScrapper.WebActions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserDataScrapper.AutomationActions;
using BrowserDataScrapper.AutomationActions.Services;

namespace BrowserDataScrapper.WebActions.Services.Tests
{
    [TestClass()]
    public class BrowserGetActionsTests
    {

        [TestMethod()]
        public void GetPageSourceTest_WebpageFound()
        {
            //Arrange
            var url = "https://www.google.com";
            var expectedPartOfResult = "HTML";
            BrowserGeneralActions browserGeneralActions = new BrowserGeneralActions();
            var browserGetActions = new BrowserGetActions();

            //Act
            var result = browserGetActions.GetPageSourceAsString(url);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(expectedPartOfResult), "The result does not contain the expected part of HTML content.");
        }
    }
}