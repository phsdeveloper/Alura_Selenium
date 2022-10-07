using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorIncial;
        private By byInputImagem;
        private By byInputInciioPregao;
        private By byInputTerminoPregao;
        /// <summary>
        /// div que encapsula todas as opções de categoria
        /// </summary>
        private By byInputCategoria_01_div;
        /// <summary>
        /// Itens do select que contém o texto para ser selecionado.
        /// </summary>
        private By byInputCategoria_02_li_itens;

        private By byBotaoSalvar;

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria));
             
                var teste = elementoCategoria.Options.Where(x=>x.Enabled).Select(x => x.Text).ToList();
               return elementoCategoria.Options.Select(x => x.Text).ToList();
            }
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo        = By.Id("Titulo");
            byInputDescricao     = By.Id("Descricao");
            byInputCategoria     = By.Id("Categoria");
            byInputValorIncial   = By.Id("ValorInicial");
            byInputImagem        = By.Id("ArquivoImagem");
            byInputInciioPregao  = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byInputCategoria_01_div = By.ClassName("select-wrapper");
            byInputCategoria_02_li_itens = By.TagName("li");
            byBotaoSalvar = By.CssSelector("button[type=submit]");
        }

        internal void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
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
            //MoverParaElemento();
           var teste =  driver.FindElement(byInputCategoria).GetAttribute($"option[value={CAtegoria}]");

            driver.FindElement(byInputCategoria_01_div).Click();
            foreach(var item in driver.FindElement(byInputCategoria_01_div).FindElements(byInputCategoria_02_li_itens))
            {
                string st_texto = item.Text;
                if (item.Text.Equals(CAtegoria))
                {
                    item.Click();
                    break;
                }
                   
            }
          

            

            driver.FindElement(byInputValorIncial   ).SendKeys(ValorIncial.ToString());
            driver.FindElement(byInputImagem        ).SendKeys(Imagem);
            driver.FindElement(byInputInciioPregao  ).SendKeys(InciioPregao.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao ).SendKeys(TerminoPregao.ToString("dd/MM/yyyy"));
        }

        private void MoverParaElemento()
        {
            bool continuar = true;
            var item = By.ClassName("select-dropdown");
            do
            {
                try
                {
                    

                    IAction acaoLogout = new Actions(driver)

                        .MoveToElement(driver.FindElement(item))
                        .Click()
                        .Build();
                    ;
                    acaoLogout.Perform();
                    continuar = false;
                }
                catch (Exception ex)
                {

                    continuar = true;
                }
            } while (continuar);

            var itens = driver.FindElements(By.ClassName("dropdown-content"));

            new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(byInputCategoria)).SelectByValue("Item de Colecionador");

        }
    }
}
