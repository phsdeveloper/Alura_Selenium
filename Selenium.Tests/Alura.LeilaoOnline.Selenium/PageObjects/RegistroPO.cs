using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
   public class RegistroPO
    {
        private IWebDriver driver;
        private By _byFormRegistro;
        private By _byImputNome;
        private By _byImputEmail;
        private By _byImputSenha;
        private By _byImputConfirmaSenha;
        private By _byBotaoRegistro;
        private By _bySpanErroEmail;
        private By _bySpanErroNome;

        public string EmailMensagemErro => driver.FindElement(_bySpanErroEmail).Text;
        public string EmailMensagemNome => driver.FindElement(_bySpanErroNome).Text;
        public RegistroPO(IWebDriver _driver)
        {
            driver = _driver;

            _byFormRegistro = By.TagName("Form");
            _byImputNome = By.Id("Nome");
            _byImputEmail = By.Id("Email");
            _byImputSenha = By.Id("Password");
            _byImputConfirmaSenha = By.Id("ConfirmPassword");
            _byBotaoRegistro = By.Id("BotaoRegistro");
            _bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
            _bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteFormulario()
        {
            Pausa(2000);
            driver.FindElement(_byBotaoRegistro).Click();
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmaSenha)
        {
            driver.FindElement(_byImputNome).SendKeys(nome);
            Pausa();
            driver.FindElement(_byImputEmail).SendKeys(email);
            Pausa();
            driver.FindElement(_byImputSenha).SendKeys(senha);
            Pausa();
            driver.FindElement(_byImputConfirmaSenha).SendKeys(confirmaSenha);
        }

        private void Pausa(int pPausa = 300)
        {
            System.Threading.Thread.Sleep(pPausa);
        }
    }
}
