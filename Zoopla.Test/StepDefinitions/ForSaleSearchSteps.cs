using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Zoopla.Test.Driver;
using Zoopla.Test.Pages;

namespace Zoopla.Test.StepDefinitions
{
    [Binding]
    public sealed class ForSaleSearchSteps : BasePage
    {
        HomePage homePage = new HomePage(_driver);
        SearchResultPage searchResultPage = new SearchResultPage(_driver);
        ProductDetailsPage productDetailsPage = new ProductDetailsPage(_driver);
        
        [Given(@"I navigate to zoopla homepage")]
        public void GivenINavigateToZooplaHomepage()
        {
            homePage.LaunchUrl();
        }

        [When(@"I enter a ""(.*)"" in the search text box")]
        public void WhenIEnterAInTheSearchTextBox(string search)
        {
            homePage.EnterLocation(search);
        }

        [When(@"I select ""(.*)"" from Min price dropdown")]
        public void WhenISelectFromMinPriceDropdown(string minPrice)
        {
            homePage.SelectMinimumPrice(minPrice);
        }

        [When(@"I select ""(.*)"" from Max price dropdown")]
        public void WhenISelectFromMaxPriceDropdown(string maxPrice)
        {
            homePage.SelectMaximumPrice(maxPrice);
        }

        [When(@"I select ""(.*)"" from Property type dropdown")]
        public void WhenISelectFromPropertyTypeDropdown(string PropertyType)
        {
            homePage.SelectPropertyType(PropertyType);
        }

        [When(@"I select ""(.*)"" from Bedrooms dropdown")]
        public void WhenISelectFromBedroomsDropdown(string beds)
        {
            homePage.selectNoOfBeds(beds);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            searchResultPage = homePage.ClickOnSubmitButton();
        }

        [Then(@"a list of ""(.*)"" in ""(.*)"" are displayed")]
        public void ThenAListOfInAreDisplayed(string property, string location)
        {
            searchResultPage.IsResultListDisplayed();
            searchResultPage.IsSearchResultDisplayed(property, location);
        }

        [Then(@"I click on any of the results")]
        public void ThenIClickOnAnyOfTheResults()
        {
            productDetailsPage = searchResultPage.ClickOnAnyResultsLink();
        }

    }
}
