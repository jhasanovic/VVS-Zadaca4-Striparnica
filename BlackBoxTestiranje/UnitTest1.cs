using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BlackBoxTestiranje
{
    [TestClass]
    public class UnitTest1

    {
        static IWebDriver driver;
        [ClassInitialize]
        public static void OtvaranjeStranice(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44312/Grupa1/Create");
        }

        static IEnumerable<object[]> Podaci1CSV
        {
            get
            {
                return UčitajPodatkeCSV("Podaci1.csv");
            }
        }

        static IEnumerable<object[]> Podaci2CSV
        {
            get
            {
                return UčitajPodatkeCSV("Podaci2.csv");
            }
        }

        static IEnumerable<object[]> Podaci3CSV
        {
            get
            {
                return UčitajPodatkeCSV("Podaci3.csv");
            }
        }
        static IEnumerable<object[]> Podaci4CSV
        {
            get
            {
                return UčitajPodatkeCSV("Podaci4.csv");
            }
        }



        public static IEnumerable<object[]> UčitajPodatkeCSV(string filename)
        {
                using (var reader = new StreamReader(filename))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                   
                    //Edicija,Naslov,Datum,Opis,Ocjena
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1],
                        DateTime.Parse(elements[2]), elements[3], elements[4]};
                }
            }
        }

        [TestMethod]
        [DynamicData("Podaci1CSV")]
        public void Test1CSV(string e, string n, DateTime d, string o, string oc)//C1
        {
           
            //opis stripa nije naveden

            IWebElement edicija = driver.FindElement(By.Id("edicija"));
            SelectElement selectionEdicija = new SelectElement(edicija);
            selectionEdicija.SelectByText(e);
            Thread.Sleep(100);

            IWebElement naslov = driver.FindElement(By.Id("NazivStripa"));
            naslov.Clear();
            naslov.SendKeys(n);
            Thread.Sleep(100);

            IWebElement opis = driver.FindElement(By.Id("opis"));
            opis.Clear();
            opis.SendKeys(o);
            Thread.Sleep(100);

            IWebElement ocjena = driver.FindElement(By.Id("Ocjena"));
            ocjena.Clear();
            ocjena.SendKeys(oc);
            Thread.Sleep(100);

            IWebElement buttonProvjeri = driver.FindElements(By.ClassName("btn-primary"))[0];
            buttonProvjeri.Click();
            Thread.Sleep(100);

            var alert = driver.SwitchTo().Alert();

            Assert.AreEqual(alert.Text, "Niste unijeli opis - analiza ne može biti izvršena!");

            alert.Accept();

        }

        [TestMethod]
        [DynamicData("Podaci2CSV")]
        public void Test2CSV(string e, string n, DateTime d, string o, string oc)//C2
        {
          
            //edicija je Spider-man, opis ne sadrži ime Peter Parker

            IWebElement edicija = driver.FindElement(By.Id("edicija"));
            SelectElement selectionEdicija = new SelectElement(edicija);
            selectionEdicija.SelectByText(e);
            Thread.Sleep(100);

            IWebElement naslov = driver.FindElement(By.Id("NazivStripa"));
            naslov.Clear();
            naslov.SendKeys(n);
            Thread.Sleep(100);

            IWebElement opis = driver.FindElement(By.Id("opis"));
            opis.Clear();
            opis.SendKeys(o);
            Thread.Sleep(100);

            IWebElement ocjena = driver.FindElement(By.Id("Ocjena"));
            ocjena.Clear();
            ocjena.SendKeys(oc);
            Thread.Sleep(100);

            IWebElement buttonProvjeri = driver.FindElements(By.ClassName("btn-primary"))[0];
            buttonProvjeri.Click();
            Thread.Sleep(100);

            var alert = driver.SwitchTo().Alert();

            Assert.AreEqual(alert.Text, "Opis mora sadržavati pravo ime Spider-mana!");

            alert.Accept();

        }

        [TestMethod]
        [DynamicData("Podaci3CSV")]
        public void Test3CSV(string e, string n, DateTime d, string o, string oc)//C3
        {
          
            //edicija je X-Men, opis ne sadrži ime Xavier

            IWebElement edicija = driver.FindElement(By.Id("edicija"));
            SelectElement selectionEdicija = new SelectElement(edicija);
            selectionEdicija.SelectByText(e);
            Thread.Sleep(100);

            IWebElement naslov = driver.FindElement(By.Id("NazivStripa"));
            naslov.Clear();
            naslov.SendKeys(n);
            Thread.Sleep(100);

            IWebElement opis = driver.FindElement(By.Id("opis"));
            opis.Clear();
            opis.SendKeys(o);
            Thread.Sleep(100);

            IWebElement ocjena = driver.FindElement(By.Id("Ocjena"));
            ocjena.Clear();
            ocjena.SendKeys(oc);
            Thread.Sleep(100);

            IWebElement buttonProvjeri = driver.FindElements(By.ClassName("btn-primary"))[0];
            buttonProvjeri.Click();
            Thread.Sleep(100);

            var alert = driver.SwitchTo().Alert();

            Assert.AreEqual(alert.Text, "Zašto Professor X nije spomenut?");

            alert.Accept();


        }

        [TestMethod]
        [DynamicData("Podaci4CSV")]
        public void Test4CSV(string e, string n, DateTime d, string o, string oc)//C4
        {
          
            //sve ok

            IWebElement edicija = driver.FindElement(By.Id("edicija"));
            SelectElement selectionEdicija = new SelectElement(edicija);
            selectionEdicija.SelectByText(e);
            Thread.Sleep(100);

            IWebElement naslov = driver.FindElement(By.Id("NazivStripa"));
            naslov.Clear();
            naslov.SendKeys(n);
            Thread.Sleep(100);

            IWebElement opis = driver.FindElement(By.Id("opis"));
            opis.Clear();
            opis.SendKeys(o);
            Thread.Sleep(100);

            IWebElement ocjena = driver.FindElement(By.Id("Ocjena"));
            ocjena.Clear();
            ocjena.SendKeys(oc);
            Thread.Sleep(100);

            IWebElement buttonProvjeri = driver.FindElements(By.ClassName("btn-primary"))[0];
            buttonProvjeri.Click();
            Thread.Sleep(100);

            var alert = driver.SwitchTo().Alert();

            Assert.AreEqual(alert.Text, "Uneseni opis zadovoljava standarde!");

            alert.Accept();

        }
        [ClassCleanup]
        public static void zatvori()
        {
            driver.Quit();
        }
        
    }
}
