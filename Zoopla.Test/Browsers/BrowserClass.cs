using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using Zoopla.Test.Driver;

namespace Zoopla.Test.Browsers
{
    public class BrowserClass : Commons
    {
        private IWebDriver InitChromeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        private IWebDriver InitHeadless()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-gpu", "--headless");
            return new ChromeDriver(options);
        }

        private IWebDriver InitFireFox()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public void LaunchBrowser(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    _driver = InitChromeDriver();
                    break;
                case "Headless":
                    _driver = InitHeadless();
                    break;
                case "Firefox":
                    _driver = InitFireFox();
                    break;
                default:
                    _driver = InitHeadless();
                    break;
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        public void CloseBrowser()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Quit();
        }
    }

    
}
