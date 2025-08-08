# BrowserDataScrapper.dll

**BrowserDataScrapper.dll** is a reusable .NET class library for C# and VBA that provides utility functions for browser manipulation and injecting javascripts directly into the browser to invoke scripts, set values or get values. 
Currently supports MS Edge browser.
DLL STILL UNDER DEVELOPMENT

---

##  Features

-Browser bar manipulation
-Injecting javascripts into the browser
-Retrieving data from a website
-Setting data into website fields

---

##  Methods

 string GetPageSourceAsString(string url, int browserTimeout = 4000); 
Retrieves website body as string

 string GetElementValueById(string url, string id, int browserTimeout = 4000);
Retrieves value of element id;

 string InvokeJavascript(string url, string command, int browserTimeout = 4000);
Runs custom javascript, limit of 2000 characters;

 void SetElementById(string url, string id, string setTo, int browserTimeout = 4000);
Sets element value to setTo;

 string GetElementWithCustomQuery(string url, string query, int browserTimeout = 4000);
Gets element based on custom query, such as document.getElementsByTagName('tag')[0].innerText or similar;

 void ClickOnElementById(string url, string id, int browserTimeout = 4000);
Simulates click on the element.

---

##  Example of use in C#

static void Main(string[] args)
{
    var obj = new ExposedActions();
    var res = obj.GetPageSourceAsString("https://www.google.com",6000);
    Console.WriteLine(res);

} 

public static void Main(string[] args)
{
   string url = "http://test";
   string command = "alert('hi');";
   obj.InvokeJavascript(url, command);
}

---

## Requirements

Requires MS Edge to be installed and having access to the control panel.

---

## Installation (C#)

1. Clone or download the repository.
2. Build the project using Visual Studio or `dotnet build`.
3. Reference `MyLibrary.dll` in your project:
   - In Visual Studio: Right-click your project > Add Reference > Browse > Select `MyLibrary.dll`

---

## Installation (VBA)

1. Download the dll file
2. Register application using regasm
3. Reference in the project.
4. Alternatively, just reference dll in the code
