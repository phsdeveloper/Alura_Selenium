using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TesteSelenium
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange - Dado que um navegador está aberto
            //IWebDriver driver = new FirefoxDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            /********************************************************************************************************
             * Nesse ponto gerou um erro 
             ********************************************************************************************************/
            IWebDriver driver = new ChromeDriver(@"E:\GIT_Paulo\Alura_Selenium");
            //act - Quando navego para a url https://www.caelum.com.br
            driver.Navigate().GoToUrl("https://www.caelum.com.br");

            //assert - então espero que a pagina apresentada seja da Caelum
            Assert.Contains("Caelum", driver.Title);
        }
    }
}
