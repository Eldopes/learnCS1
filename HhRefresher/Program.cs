using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

/*
 * Refreshes resume on hh.ru using MS Edge web browser + Selenium QA Driver
 *
 * */

namespace HhRefresher
{
    class Program
    {
        private static Mutex mutex = null; // creating mutex object for single instance tracking

        static void Main(string[] args)
        {
            const string appName = "HhRefresher";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew) // if createdNew = false (e.g. there's already same app running)
            {
                Console.WriteLine(appName + " is already running! Exiting the application.");                
                return;
            }

            Console.WriteLine("Launching HH resume refresher");
            Launch(); // else if single instance, we launch
        }

        static void Launch()
        {
            while (true)
            {
                switch (DateTime.Now.Hour)
                {
                    case 9:  // add the hours you want to refresh at as cases (minutes not supportedgz)
                    case 12:
                    case 14:
                    case 19:
                    case 23:
                        Click();
                        Thread.Sleep(60500 * 60); // sleep about 1 hour
                        break;
                    default:
                        break;
                }
                Thread.Sleep(3000);
            }
        }

        static void Click()
        {
            IWebDriver driver = new EdgeDriver(@"C:\Users\Eugene\OneDrive\Selenium");
            driver.Navigate().GoToUrl("https://hh.ru/resume/bc2a467eff030b39fc0039ed1f33626a567741");
            Thread.Sleep(500);
            IWebElement searchBtn = driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div/div[4]/div[2]/div/div[2]/div/div/div/div[2]/div[3]/div[2]/button"));  // finding button to click
            searchBtn.Click();
            Thread.Sleep(200);
            driver.Close();
        }
    }
}


