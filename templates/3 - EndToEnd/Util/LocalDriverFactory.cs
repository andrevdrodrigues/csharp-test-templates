﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTemplates.Experimentation._3___EndToEnd.Util
{
    public static class LocalDriverFactory
    {
        public static IWebDriver CreateInstance(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    var options = new EdgeOptions();
                    driver = new EdgeDriver(options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Opera:
                    break;
            }

            return driver;
        }

        public static IWebDriver CreateInstance(BrowserType browserType, string hubUrl)
        {
            IWebDriver driver = null;
            TimeSpan timeSpan = new TimeSpan(0, 3, 0);

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    driver = GetWebDriver(hubUrl, chromeOptions.ToCapabilities());
                    break;
                case BrowserType.Edge:
                    EdgeOptions options = new EdgeOptions();
                    driver = GetWebDriver(hubUrl, options.ToCapabilities());
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = GetWebDriver(hubUrl, firefoxOptions.ToCapabilities());
                    break;
                case BrowserType.Opera:
                    OperaOptions operaOptions = new OperaOptions();
                    driver = GetWebDriver(hubUrl, operaOptions.ToCapabilities());
                    break;
            }

            return driver;
        }

        private static IWebDriver GetWebDriver(string hubUrl, ICapabilities capabilities)
        {
            TimeSpan timeSpan = new TimeSpan(0, 1, 0);
            return new RemoteWebDriver(
                        new Uri(hubUrl),
                        capabilities,
                        timeSpan
                    );
        }
    }

}
