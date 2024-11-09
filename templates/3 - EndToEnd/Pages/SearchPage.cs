using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace TestTemplates.Templates._3___EndToEnd.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement txt_search
        {
            get
            {
                return this.driver.FindElement(By.XPath("")); //Add locator
            }
        }

        private IWebElement lnk_product
        {
            get
            {
                return this.driver.FindElement(By.XPath("")); //Add locator
            }
        }

        public void waitComponent(int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(""))); //Add locator
        }

        public void clickProduct()
        {
            lnk_product.Click();
        }

        public void typeSearchBar(string text)
        {
            txt_search.SendKeys(text);
        }
    }
}
