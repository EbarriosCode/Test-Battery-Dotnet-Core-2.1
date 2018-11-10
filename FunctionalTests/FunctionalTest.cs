using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FunctionalTests
{
    [TestClass]
    public class FunctionalTest
    {
        
        [TestMethod]
        public void CreateProduct_Test()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Ebarrios\Documents\Visual Studio 2017\Projects\WebTesting\FunctionalTests\bin\Debug\netcoreapp2.1");

            driver.Navigate().GoToUrl("https://sitetesting.azurewebsites.net/Products/Create");

            //Aceptar política de privacidad
            driver.FindElement(By.ClassName("btn-default")).Click();
            
            //Llenar los campos del formulario Create
            driver.FindElement(By.Name("Name")).SendKeys("Usb");
            driver.FindElement(By.Name("Price")).SendKeys("50");
            driver.FindElement(By.Name("Description")).SendKeys("Memoria USB Kingstong");

            driver.FindElement(By.ClassName("btn-success")).Click();

            Console.WriteLine("Test Completed");
        }
   
    }
}
