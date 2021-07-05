using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class testeQualquer
    {
        private IWebDriver driver;

        //Setup
        public testeQualquer(Fixtures.TestFixtures _driver)
        {
            driver = _driver.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
