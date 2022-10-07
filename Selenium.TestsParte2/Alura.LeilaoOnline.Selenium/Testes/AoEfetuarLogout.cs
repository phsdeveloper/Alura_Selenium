﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }
        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("paulo.santos@teste.com.br", "123");
            loginPO.SubmeteFormulario();


            //act - Efetuar logout
            var DashboardPO = new DashboardInteressadaPO(driver);
            DashboardPO.EfetuarLogout();
            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
