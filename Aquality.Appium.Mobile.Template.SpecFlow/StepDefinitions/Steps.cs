using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Template.Screens;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace Aquality.Appium.Mobile.Template.SpecFlow.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private static MainScreen MainScreen = new();
        private static FiltersScreen FiltersScreen = new();
        private static ResultsScreen ResultsScreen = new();
        private static OfferScreen OfferScreen = new();

        [When(@"I log in in Cian with email '(.*)' and password '(.*)'")]
        public void ILoginCian(string email, string password)
        {
            MainScreen = new MainScreen();
            MainScreen.OtherAccount.Click();

            var loginScren = new LoginAndRegistrationScreen();

            loginScren.OtherWayButton.Click();

            loginScren.EmailTextBox.SendKeys(email);
            loginScren.PasswordTextBox.SendKeys(password);

            loginScren.ConfirmButton.Click();

            var adsScreen = new AdsScreen();
            adsScreen.CloseButton.Click();
        }

        [When(@"I choose rent")]
        public void IChooseRent()
        {
            MainScreen.RentButton.Click();
        }

        [When(@"I fill in filters: house type - '(.*)', house size - '(.*)'")]
        public void IFillInFilters(string houseType, string houseSize)
        {
            FiltersScreen.ClickButton(houseType);
            Thread.Sleep(2000);

            if (houseType != "Квартира")
            {
                FiltersScreen.ChooseHouseType("Квартира").Click();
            }

            FiltersScreen.ClickButton(houseSize);
        }

        [When(@"I scroll down")]
        public void IScrollDown()
        {
            var pressX = AqualityServices.Application.Driver.Manage().Window.Size.Width / 2.0;
            var bottomY = AqualityServices.Application.Driver.Manage().Window.Size.Height * 4 / 5.0;
            var topY = AqualityServices.Application.Driver.Manage().Window.Size.Height / 8.0;

            new TouchAction(AqualityServices.Application.Driver).LongPress(pressX, bottomY).MoveTo(pressX, topY).Release().Perform();
        }

        [When(@"I set price from '(.*)' to '(.*)' and set true owner check box")]
        public void IFillInPrice(string priceFrom, string priceTo)
        {
            FiltersScreen.RangeFrom.SendKeys(priceFrom);
            FiltersScreen.RangeTo.SendKeys(priceTo);
            FiltersScreen.OwnerCheckBox.Check();
            FiltersScreen.Show.Click();
            FiltersScreen.List.Click();
        }

        [Then(@"Expected owner indicator, house type '(.*)' and price range '(.*)'-'(.*)'")]
        public void CheckFilters(string houseType, string priceFrom, string priceTo)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(ResultsScreen.OwnerIndicator.State.WaitForDisplayed(), "Наличие индикатора собственника");
                Assert.IsTrue(ResultsScreen.HouseType.Text.Contains(houseType), "Тип апартаментов");
                var price = int.Parse(Regex.Replace(ResultsScreen.Price.Text.Replace("₽/мес.", string.Empty), "[^.0-9]", ""));
                Assert.GreaterOrEqual(price, int.Parse(priceFrom), "Цена от");
                Assert.LessOrEqual(price, int.Parse(priceTo), "Цена до");
            });
        }

        [When(@"I choose first offer")]
        public void IClickOffer()
        {
            ResultsScreen.Apartment.Click();
        }

        [Then(@"Expected owner indicator, house type '(.*)', price range '(.*)'-'(.*)' and house size '(.*)'")]
        public void CheckFilters(string houseType, string priceFrom, string priceTo, string houseSize)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(OfferScreen.OwnerIndicator.State.WaitForDisplayed(), "Наличие индикатора собственника");
                Assert.IsTrue(OfferScreen.HouseType.Text.Contains(houseType), "Тип апартаментов");
                Assert.IsTrue(OfferScreen.HouseSize.Text.Contains(houseSize), "Размер апартаментов");
                var price = int.Parse(Regex.Replace(OfferScreen.Price.Text.Replace("₽/мес. x", string.Empty), "[^.0-9]", ""));
                Assert.GreaterOrEqual(price, int.Parse(priceFrom), "Цена от");
                Assert.LessOrEqual(price, int.Parse(priceTo), "Цена до");
            });
        }

        [When(@"I click to show phone")]
        public void ShowPhone()
        {
            OfferScreen.CallPhone.Click();
        }

        [When(@"I close Cian")]
        public void CloseCian()
        {
            Thread.Sleep(3000);
            AqualityServices.Application.Quit();
        }
    }
}
