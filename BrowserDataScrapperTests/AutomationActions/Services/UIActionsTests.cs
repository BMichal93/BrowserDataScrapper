using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace BrowserDataScrapper.AutomationActions.Services.Tests
{
    [TestClass()]
    public class UIActionsTests
    {
        [TestMethod()]
        public void GetBrowserUITest_CanFindBrowser()
        {
            //Arrange
            Process.Start("msedge");
            Thread.Sleep(5000);
            var uiActions = new UIActions();

            //Act
            var result = uiActions.GetBrowserUI();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0,"No elements in the list");
        }
    }
}