
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAntamento;
        private By byBotaoPesquisar;


        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byLogoutLink = By.Id("logout");
            this.byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("");
            byInputAntamento = By.Id("");
            byBotaoPesquisar = By.Id("");
        }
        public void PesquisarLeiloes(List<string> categorias)
        {
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();
            opcoes.ForEach(x => { x.Click(); Thread.Sleep(1000); });
            categorias.ForEach(x => 
            {
                opcoes.Where(y => y.Text.Contains(x))
                .ToList()
                .ForEach(o => { o.Click(); Thread.Sleep(1000); });
            });

            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);

            Thread.Sleep(2000);
                
        }

        public void EfetuarLogout()
        {
            var linkLogout = driver.FindElement(byLogoutLink);
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);

            /*
             * Para utilizar essa parada é necessário instalar o pacote
             * Selenium.WebDriver
             */


            IAction acaoLogout = new Actions(driver)
                //Mover para o elemento pai
                .MoveToElement(linkMeuPerfil)
                //Mover para o link de logout
                .MoveToElement(linkLogout)
                //Clicar no link de logout
                .Click()
                .Build();
            acaoLogout.Perform();

        }
    }
}
