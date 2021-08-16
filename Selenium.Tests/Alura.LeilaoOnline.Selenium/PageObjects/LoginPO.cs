using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;

        //Login
        //Password
        //btnLogin

        private By byInputLogin ;
        private By byInputSenha ;
        private By byBotaotLogin;



        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin  = By.Id("Login");
            byInputSenha  = By.Id("Password");
            byBotaotLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string pLogin, string pSenha)
        {
            driver.FindElement(byInputLogin).SendKeys(pLogin);
            driver.FindElement(byInputSenha).SendKeys(pSenha);
        }

        public void SubmeteFormulario()
        {
            //driver.FindElement(byBotaotLogin).Click();
            driver.FindElement(byBotaotLogin).Submit();
        }
    }
}
