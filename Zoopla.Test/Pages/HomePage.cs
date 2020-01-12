using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Test.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "search-input-location")]
        private IWebElement searchField;
        [FindsBy(How = How.Id, Using = "forsale_price_min")]
        private IWebElement minPrice;
        [FindsBy(How = How.Name, Using = "price_max")]
        private IWebElement maxPrice;
        [FindsBy(How = How.Id, Using = "property_type")]
        private IWebElement propertyType;
        [FindsBy(How = How.Id, Using = "beds_min")]
        private IWebElement noOfBeds;
        [FindsBy(How = How.CssSelector, Using = ".button.button--primary")]
        private IWebElement submitButton;


        public void EnterLocation(string location)
        {
            searchField.Clear();
            searchField.SendKeys(location);
        }

        public void SelectMinimumPrice(string miniPrice)
        {
            SelectByText(minPrice, miniPrice);
        }

        public void SelectMaximumPrice(string maxiPrice)
        {
            SelectByText(maxPrice, maxiPrice);
        }
        public void SelectPropertyType(string property)
        {
            SelectByText(propertyType, property);
        }

        public void selectNoOfBeds(string beds)
        {
            SelectByText(noOfBeds, beds);
        }

        public SearchResultPage ClickOnSubmitButton()
        {
            submitButton.Click();
            return new SearchResultPage(_driver);
        }
    }
}
