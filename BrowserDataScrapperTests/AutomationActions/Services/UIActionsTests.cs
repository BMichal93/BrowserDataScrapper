using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BrowserDataScrapper.AutomationActions.Services.Tests
{
    [TestClass()]
    public class UIActionsTests
    {
        [TestMethod()]
        public void SetBrowserBarValueTest_BarFoundAndPopulated()
        {
            //Arrange
            Process.Start("msedge");
            var inputToBrowser = "javascript:alert('Hello World!');";
            var successMessage = "Browser was set and executed: " + inputToBrowser;
            UIActions uIActionsTests = new UIActions();

            //Act
            var result = uIActionsTests.SetBrowserBarValue(inputToBrowser);

            //Assert
            Assert.AreEqual(successMessage, result, "The browser bar value was not set correctly or the browser was not found.");

        }
    }
}