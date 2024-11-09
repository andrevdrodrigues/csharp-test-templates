using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestTemplates.Experimentation._3___EndToEnd.Util;
using TestTemplates.Templates._3___EndToEnd.Pages;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace TestTemplates.Experimentation._3___EndToEnd.Tests
{
    public class Tests : IDisposable
    {

        private IWebDriver driver;
        string hubUrl;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        public Tests()
        {
            vars = new Dictionary<string, object>();

            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Util.BrowserType.Chrome, hubUrl);
            js = (IJavaScriptExecutor)driver;
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void OpenSiteAndSearch()
        {
            //arrange
            var homePage = new HomePage(driver);
            var searchPage = new SearchPage(driver);
            var productPage = new ProductPage(driver);
            var text_products_page_current = "TEXT PRODUCTS";

            driver.Navigate().GoToUrl("https://www.uri.com");
            driver.Manage().Window.Maximize();

            //act
            homePage.clickSearchBar();
            searchPage.typeSearchBar("Products");
            searchPage.waitComponent(10);
            searchPage.clickProduct();

            //assert
            Assert.AreEqual(text_products_page_current, productPage.getProductText());

        }
    }

}
