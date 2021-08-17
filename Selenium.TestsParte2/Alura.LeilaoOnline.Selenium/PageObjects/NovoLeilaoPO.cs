using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCAtegoria;
        private By byInputValorIncial;
        private By byInputImagem;
        private By byInputInciioPregao;
        private By byInputTerminoPregao;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo        = By.Id("Titulo");
            byInputDescricao     = By.Id("Descricao");
            byInputCAtegoria     = By.Id("Categoria");
            byInputValorIncial   = By.Id("ValorInicial");
            byInputImagem        = By.Id("Imagem");
            byInputInciioPregao  = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");

        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
             string   Titulo
            ,string   Descricao
            ,string   CAtegoria
            ,double   ValorIncial
            ,string   Imagem
            ,DateTime InciioPregao
            ,DateTime TerminoPregao
            )
        {
            driver.FindElement(byInputTitulo        ).SendKeys(Titulo);
            driver.FindElement(byInputDescricao     ).SendKeys(Descricao);
            driver.FindElement(byInputCAtegoria     ).SendKeys(CAtegoria);
            driver.FindElement(byInputValorIncial   ).SendKeys(ValorIncial.ToString());
            driver.FindElement(byInputImagem        ).SendKeys(Imagem);
            driver.FindElement(byInputInciioPregao  ).SendKeys(InciioPregao.ToString());
            driver.FindElement(byInputTerminoPregao ).SendKeys(TerminoPregao.ToString());
        }
    }
}
