using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Automation.Wikipedia02.Base
{
    internal class MyFactory
    {
        internal static IWebDriver GetBrowserInstance(string driverName)
        {
            switch(driverName.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("--headless");
                    chromeOptions.AddArguments("disable-infobars");
                    return new ChromeDriver(chromeOptions);
                    
                case "firefox":
                    return new FirefoxDriver();
                    
                case "edge":
                    return new EdgeDriver();
                    
                default:
                    throw new Exception("Unknown driver Name: '" + driverName + "'.");
            } 

            
            //TODO: need add logic
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver = new EdgeDriver();
        }
    }
}