

using OpenQA.Selenium;

namespace TestTemplates.Templates._3___EndToEnd.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
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

        public void clickSearchBar()
        {
            txt_search.Click();
        }

    }
}
