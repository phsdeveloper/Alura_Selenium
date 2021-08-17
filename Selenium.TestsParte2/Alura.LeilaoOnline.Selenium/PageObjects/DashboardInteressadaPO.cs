
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            this.byLogoutLink = By.Id("logout");
            this.byMeuPerfilLink = By.Id("meu-perfil");
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
