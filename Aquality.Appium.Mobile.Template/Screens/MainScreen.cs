using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class MainScreen : Screen
    {
        public IButton RentButton => ElementFactory.GetButton(new ByChained(By.Id("dashboard_recycler"), By.XPath("//android.widget.FrameLayout[2]")), "Аренда");
        public IButton OtherAccount => ElementFactory.GetButton(By.Id("enter_other_account_button"), "Войти в другой аккаунт");

        public MainScreen() : base(By.Id("dashboard_recycler"), "Меню кнопок") { }

        
    }
}
