
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace TestTemplates.Templates._3___EndToEnd.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement lnk_products
        {
            get
            {
                return this.driver.FindElement(By.XPath("")); //Add locator
            }
        }

        private IWebElement lbl_result
        {
            get
            {
                return this.driver.FindElement(By.XPath("")); //Add locator
            }
        }

        public string getProductText()
        {
            return lbl_result.Text;
        }

    }
}
