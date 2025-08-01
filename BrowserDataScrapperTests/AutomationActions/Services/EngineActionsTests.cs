using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrowserDataScrapper.AutomationActions.Tests
{
    [TestClass()]
    public class EngineActionsTests
    {
        [TestMethod()]
        public void InvokeBrowserTest_BrowserInvoked()
        {
            //Arrange
            var url = "https://www.google.com";
            var engineActions = new EngineActions();

            //Act
            var result = engineActions.InvokeBrowser(url);

            //Assert
            Assert.IsTrue(result.Contains("Browser has been invoked successfully"));
        }
    }
}