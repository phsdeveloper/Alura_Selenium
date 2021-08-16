using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome : IClassFixture<Fixtures.TestFixtures>
    {
        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(Fixtures.TestFixtures _driver)
        {
            driver = _driver.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveNaoDeveMostrarMostrarMensagensDeErro()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            var Form = driver.FindElement(By.TagName("form"));
            var spans = Form.FindElements(By.TagName("span"));

            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }

            //assert
           
        }

    }
}
