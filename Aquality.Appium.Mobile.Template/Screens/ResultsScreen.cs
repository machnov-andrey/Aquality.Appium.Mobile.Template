using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class ResultsScreen : Screen
    {
        public ILabel OwnerIndicator => ElementFactory.GetLabel(By.Id("inner_item_commercial_owner_indicator"), "От собственника");
        public ILabel Price => ElementFactory.GetLabel(By.Id("inner_item_price_text_view"), "Цена");
        public ILabel HouseType => ElementFactory.GetLabel(By.Id("inner_item_house_type_text_view"), "Тип жилья");
        public IButton Apartment => ElementFactory.GetButton(By.Id("inner_item_card_view"), "Объявление");

        public ResultsScreen() : base(By.Id("sort_view_title"), "Результаты") { }


    }
}
