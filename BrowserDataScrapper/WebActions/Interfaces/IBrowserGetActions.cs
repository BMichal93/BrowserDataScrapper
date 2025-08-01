using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserDataScrapper.WebActions.Interfaces
{
    public interface IBrowserGetActions
    {
        string GetPageSourceAsString(string url);
    }
}
