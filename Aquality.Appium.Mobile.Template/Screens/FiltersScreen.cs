using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class FiltersScreen : Screen
    {
        private static By CommonLocator(string text) => By.XPath($"//*[contains(@text,'{text}')]");

        public ITextBox RangeFrom => ElementFactory.GetTextBox(By.Id("filter_range_from"), "Цена от");
        public ITextBox RangeTo => ElementFactory.GetTextBox(By.Id("filter_range_to"), "Цена до");
        public ICheckBox OwnerCheckBox => ElementFactory.GetCheckBox(By.Id("base_checkbox"), "Только от собственника");
        public IButton Show => ElementFactory.GetButton(By.Id("search_text"), "Показать объявления");
        public IButton List => ElementFactory.GetButton(By.Id("button_map_list"), "Список");
        public IButton ChooseHouseType(string text) => ElementFactory.GetButton(By.XPath($"//android.widget.Button[contains(@text,'{text}')]"), "Тип апартаментов");

        public FiltersScreen() : base(CommonLocator("Фильтры"), "Фильтры") { }

        public void ClickButton(string text)
        {
            ElementFactory.GetButton(CommonLocator(text), text).Click();
        }
    }
}
