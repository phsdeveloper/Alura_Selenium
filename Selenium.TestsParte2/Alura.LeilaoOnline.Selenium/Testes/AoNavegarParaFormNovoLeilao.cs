using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;
namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;
        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }


        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);

            //act
            novoLeilaoPO.Visitar();

            Assert.Equal(4, novoLeilaoPO.Categorias.Count());


        }
    }
}
