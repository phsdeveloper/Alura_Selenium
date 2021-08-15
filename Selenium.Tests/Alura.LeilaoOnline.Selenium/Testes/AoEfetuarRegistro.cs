using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixtures fixtures)
        {
            driver = fixtures.Driver;
        }

        [Fact]
        public void Teste()
        {
            /*************************************************************************
             * Arrange - Dado chorme aberto, pagina incial do sistam de leilões      *
             * Dados de registro validos ingormados                                  *
            **************************************************************************/
            driver.Navigate().GoToUrl("http://localhost:5000");


            IWebElement inputNome = driver.FindElement(By.Id("Nome"));
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            IWebElement inputSenha = driver.FindElement(By.Id("Password"));
            IWebElement inputConfirmaSenha = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement BotaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Paulo Santos");
            System.Threading.Thread.Sleep(300);
            inputEmail.SendKeys("paulo.santos@teste.com.br");
            System.Threading.Thread.Sleep(300);
            inputSenha.SendKeys("123");
            System.Threading.Thread.Sleep(300);
            inputConfirmaSenha.SendKeys("123");
            System.Threading.Thread.Sleep(300);


            //act - efetuo o registro

            BotaoRegistro.Click();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }
    }
}
