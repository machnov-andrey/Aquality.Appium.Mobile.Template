using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class OfferScreen : Screen
    {
        public ILabel OwnerIndicator => ElementFactory.GetLabel(By.XPath("//android.widget.TextView[contains(@text,'Собственник')]"), "От собственника");
        public ILabel HouseType => ElementFactory.GetLabel(By.Id("fact_value"), "Тип апартаментов");
        public ILabel HouseSize => ElementFactory.GetLabel(By.Id("fact_title"), "Размер апартаментов");
        public ILabel Price => ElementFactory.GetLabel(By.Id("price_text_view"), "Цена");
        public IButton CallPhone => ElementFactory.GetButton(By.Id("call_view_phone_button"), "Позвонить");

        public OfferScreen() : base(By.Id("offer_gallery_recycler"), "Объявление") { }
    }
}
