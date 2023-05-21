using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Aquality.Appium.Mobile.Template.Screens
{
    public class LoginAndRegistrationScreen : Screen
    {
        public IButton OtherWayButton => ElementFactory.GetButton(By.Id("login_phone_by_other_method_button"), "Другой способ");
        public ITextBox EmailTextBox => ElementFactory.GetTextBox(new ByChained(By.Id("login_edit_login"), By.Id("text_input_edit_text")), "Email или ID");
        public ITextBox PasswordTextBox => ElementFactory.GetTextBox(new ByChained(By.Id("login_edit_password"), By.Id("text_input_edit_text")), "Пароль");
        public IButton ConfirmButton => ElementFactory.GetButton(By.Id("login_email_login_button"), "Продолжить");

        public LoginAndRegistrationScreen() :
            base(By.XPath("//*[contains(@text,'Вход или регистрация')]"), "Экран 'Вход или регистрация'")
        { }
    }
}
