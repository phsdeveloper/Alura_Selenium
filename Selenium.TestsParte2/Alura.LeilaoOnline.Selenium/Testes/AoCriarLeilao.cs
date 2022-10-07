using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;


        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                Titulo:"Leilão de Coleção 01",
                Descricao: "descrição dessa parada Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi libero ipsum",
                CAtegoria: "Teste",
                ValorIncial:4000,
                Imagem: @"C:\Users\Paulo Henrique\Pictures\Teste Selenium Update01.jpg",
                InciioPregao: DateTime.Now.AddDays(20),
                TerminoPregao: DateTime.Now.AddDays(40)
                );

            Thread.Sleep(5000);


            //act
            novoLeilaoPO.SubmeteFormulario();

            Thread.Sleep(2000);
            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
