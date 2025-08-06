using BrowserDataScrapper.WebActions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserDataScrapper.AutomationActions;
using BrowserDataScrapper.AutomationActions.Services;
using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using Moq;
using System.Reflection;
using System;
using System.Windows.Forms;

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

        private Mock<IUIActions> _uiActionsMock;
        private Mock<IBrowserGeneralActions> _browserGeneralActionsMock;
        private TestableBrowserGetActions _getActions;

        [TestInitialize]
        public void SetUp()
        {
            _uiActionsMock = new Mock<IUIActions>();
            _browserGeneralActionsMock = new Mock<IBrowserGeneralActions>();
            _getActions = new TestableBrowserGetActions();

            // Inject mocks into private fields using reflection
            typeof(BrowserGetActions)
                .GetField("_uiActions", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(_getActions, _uiActionsMock.Object);
            typeof(BrowserGetActions)
                .GetField("_browserGeneralActions", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(_getActions, _browserGeneralActionsMock.Object);
        }

        [TestMethod]
        public void GetPageSourceAsString_ReturnsClipboardText()
        {
            string url = "https://www.google.com/";
            string expected = "<html>";
            Clipboard.SetText(expected);

            _uiActionsMock.Setup(x => x.SetBrowserBarValue(It.IsAny<string>(), It.IsAny<string>())).Returns(string.Empty);

            var result = _getActions.GetPageSourceAsString(url);

            _browserGeneralActionsMock.Verify(x => x.PrepareBrowserInstance(url, 4000), Times.Once);
            _uiActionsMock.Verify(x => x.SetBrowserBarValue(It.IsAny<string>(), "Chrome_WidgetWin_1"), Times.Once);
            Assert.IsTrue(result.Contains(expected));
        }


        [TestMethod]
        public void GetQuery_WhenException_ReturnsErrorMessage()
        {
            string url = "https://www.google.com/";
            string query = "bad query";
            _browserGeneralActionsMock.Setup(x => x.PrepareBrowserInstance(url, 4000)).Throws(new Exception("fail"));

            // Use reflection to invoke private GetQuery
            var method = typeof(BrowserGetActions).GetMethod("GetQuery", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = (string)method.Invoke(_getActions, new object[] { url, query, 4000 });

            StringAssert.StartsWith(result, "Exception occured when downloading page source: ");
        }

        // Helper subclass to allow instantiation
        private class TestableBrowserGetActions : BrowserGetActions { }
    }
}