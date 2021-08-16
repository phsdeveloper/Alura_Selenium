using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;
namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixtures fixtures)
        {
            this.driver = fixtures.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            LoginPO loginPO = new LoginPO(this.driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("paulo.santos@teste.com.br", "123");

            //act
            loginPO.SubmeteFormulario();
            //Assert
            Assert.Contains("Dashboard", driver.Title);
        }
        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            //arrange
            LoginPO loginPO = new LoginPO(this.driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("paulo.santos@teste.com.br", "sdasd");

            //act
            loginPO.SubmeteFormulario();
            //Assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
