using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
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
        public void DadoInfoValidasDeveIrParaPaginaAgradecimento()
        {
            /*************************************************************************
             * Arrange - Dado chorme aberto, pagina incial do sistam de leilões      *
             * Dados de registro validos ingormados                                  *
            **************************************************************************/
            RegistroPO registroPO = new RegistroPO(driver);

            registroPO.PreencheFormulario($"Paulo Santos {DateTime.Now:dd/MM/yyyy HH:mm:ss}", "paulo.santos@teste.com.br", "123", "123");



            //act - efetuo o registro

            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }


        [Theory]
        [InlineData("","","","")]
        [InlineData("Paulo Santos","","","")]
        [InlineData("Paulo Santos","teste.teste","","")]
        [InlineData("Paulo Santos","teste.teste@teste.com.br","","")]
        [InlineData("Paulo Santos","teste.teste@teste.com.br","123","")]
        [InlineData("Paulo Santos","teste.teste@teste.com.br","123","1234")]
        public void DadoInfoInvalidaDeveContinuarNaHome(string nome,string email,string senha,string confirmarSenha)
        {
            /*************************************************************************
             * Arrange - Dado chorme aberto, pagina incial do sistam de leilões      *
             * Dados de registro validos ingormados                                  *
            **************************************************************************/
            RegistroPO registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome,email,senha,confirmarSenha);

            //act - efetuo o registro

            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            RegistroPO registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            //act - efetuo o registro

            registroPO.SubmeteFormulario();
          

            //assert - devo ser direcionado para uma pagina de agradecimento
            
            Assert.Equal("The Nome field is required.", registroPO.EmailMensagemNome);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrange
            RegistroPO registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome:"",email:"Paulo",senha:"",confirmaSenha:"");

            //act 
            registroPO.SubmeteFormulario();

            //assert 
            
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }


    }
}
