using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserDataScrapper.AutomationActions;
using BrowserDataScrapper.AutomationActions.Services;

namespace BrowserDataScrapper.WebActions.Services.Tests
{
    [TestClass()]
    public class BrowserGetActionsTests
    {
        EngineActions engineActions = new EngineActions();
        UIActions uiActions = new UIActions();

        [TestMethod()]
        public void GetPageSourceTest_WebpageFound()
        {
            //Arrange
            var url = "https://www.google.com";
            var expectedPartOfResult = "HTML";
            var browserGetActions = new BrowserGetActions(uiActions, engineActions);

            //Act
            var result = browserGetActions.GetPageSourceAsString(url);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(expectedPartOfResult), "The result does not contain the expected part of HTML content.");
        }
    }
}