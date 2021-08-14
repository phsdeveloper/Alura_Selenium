using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
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
            //Arrange - Dado chorme aberto, pagina incial do sistam de leilões
            //Dados de registro validos ingormados
            driver.Navigate().GoToUrl("http://localhost:5000");
            //act - efetuo o registro

            //assert - devo ser direcionado para uma pagina de agradecimento
        }
    }
}
