using BrowserDataScrapper.AutomationActions.Interfraces;
using BrowserDataScrapper.WebActions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserDataScrapper.WebActions.Services
{
    public class BrowserGetActions : IBrowserGetActions
    {
        private IUIActions _uiActions;
        private IEngineActions _engineActions;
        private const string _getPageCommand = "javascript:(function(){setTimeout(function(){try{navigator.clipboard.writeText(document.getElementsByTagName('body')[0].innerHTML).then(()=>console.log(' Full HTML copied to clipboard!')).catch(e=>console.log('❌ Copy failed: '+e));}catch(e){console.log('❌ Error: '+e);}},300);})();";
        public BrowserGetActions(IUIActions uiActions, IEngineActions engineActions)
        {
            _uiActions = uiActions;
            _engineActions = engineActions;
        }



        private bool IsCorrectJSFormat(string command)
        {
            if(command.StartsWith("javascript:") && command.EndsWith(";"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
