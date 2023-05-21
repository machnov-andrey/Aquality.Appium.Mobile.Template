using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class AdsScreen : Screen
    {
        private static By CloseButtonLocator => MobileBy.AccessibilityId("Закрыть");

        public IButton CloseButton => ElementFactory.GetButton(CloseButtonLocator, "Закрыть");

        public AdsScreen() : base(CloseButtonLocator, "Реклама")
        { }
    }
}
