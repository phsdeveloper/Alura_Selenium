using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixtures:IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixtures()
        {
            Driver = new ChromeDriver(Helpers.TestHelper.PastaDoExecutavel);
        }

        //TearDown
        public void Dispose()
        {
            System.Threading.Thread.Sleep(3000);
            Driver.Quit();
        }
    }
}
