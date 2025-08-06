using BrowserDataScrapper.WebActions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserDataScrapper.AutomationActions.Services;
using BrowserDataScrapper.AutomationActions;
using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using Moq;

namespace BrowserDataScrapper.WebActions.Services.Tests
{

        [TestClass]
        public class BrowserSetActionsTests
        {
            private Mock<IUIActions> _uiActionsMock;
            private Mock<IBrowserGeneralActions> _browserGeneralActionsMock;
            private TestableBrowserSetActions _setActions;

            [TestInitialize]
            public void SetUp()
            {
                _uiActionsMock = new Mock<IUIActions>();
                _browserGeneralActionsMock = new Mock<IBrowserGeneralActions>();
                _setActions = new TestableBrowserSetActions(_uiActionsMock.Object, _browserGeneralActionsMock.Object);
            }

            [TestMethod]
            public void InvokeJavascript_CorrectFormat_CallsDependenciesAndReturnsSuccess()
            {
                string url = "http://test";
                string command = "alert('hi');";
                _uiActionsMock.Setup(x => x.SetBrowserBarValue(It.IsAny<string>(), It.IsAny<string>())).Returns(string.Empty);

                var result = _setActions.InvokeJavascript(url, command);

                _browserGeneralActionsMock.Verify(x => x.PrepareBrowserInstance(url, 4000), Times.Once);
                _uiActionsMock.Verify(x => x.SetBrowserBarValue("javascript:" + command, "Chrome_WidgetWin_1"), Times.Once);
                Assert.AreEqual("Action has been successfully performed on the website.", result);
            }

            [TestMethod]
            public void InvokeJavascript_IncorrectFormat_ReturnsIncorrectJS()
            {
                string url = "http://test";
                string command = "alert('hi')"; // missing semicolon

                var result = _setActions.InvokeJavascript(url, command);

                Assert.AreEqual("Javascript is incorrect", result);
                _uiActionsMock.Verify(x => x.SetBrowserBarValue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            }

            [TestMethod]
            public void SetElementById_CallsPrepareAndSetBrowserBarValue()
            {
                string url = "http://test";
                string id = "input1";
                string value = "testValue";
                string expectedJs = $"javascript:(function(){{document.getElementById('{id}').value = '{value}';}})();";

                _setActions.SetElementById(url, id, value);

                _browserGeneralActionsMock.Verify(x => x.PrepareBrowserInstance(url, 4000), Times.Once);
                _uiActionsMock.Verify(x => x.SetBrowserBarValue(expectedJs, "Chrome_WidgetWin_1"), Times.Once);
            }

            [TestMethod]
            public void ClickOnElementById_CallsPrepareAndSetBrowserBarValue()
            {
                string url = "http://test";
                string id = "btn1";
                string expectedJs = $"javascript:(function(){{document.getElementById('{id}').click();}})();";

                _setActions.ClickOnElementById(url, id);

                _browserGeneralActionsMock.Verify(x => x.PrepareBrowserInstance(url, 4000), Times.Once);
                _uiActionsMock.Verify(x => x.SetBrowserBarValue(expectedJs, "Chrome_WidgetWin_1"), Times.Once);
            }

            // Helper subclass to inject mocks into the private fields
            private class TestableBrowserSetActions : BrowserSetActions
            {
                public TestableBrowserSetActions(IUIActions uiActions, IBrowserGeneralActions browserGeneralActions)
                {
                    typeof(BrowserSetActions)
                        .GetField("_uiActions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(this, uiActions);
                    typeof(BrowserSetActions)
                        .GetField("_browserGeneralActions", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(this, browserGeneralActions);
                }
            }
        }

    }