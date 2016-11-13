using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
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

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("HhRefresher");
            bool is_unique = processes.Length > 1 ? false : true;   // if > 1 than it means that current process is not unique       

           if (is_unique)
            {          
                Console.WriteLine("Launching HH resume refresher"); // if no such process running already, we launch
                Launch();
            }
            else
            {
                SystemSounds.Hand.Play(); // else we play error sound
                Console.WriteLine("Same process is already running");
            }  
        }

        static void Launch()
        {
            while (true)
            {
                switch (DateTime.Now.Hour)
                {
                    case 3:  // add the hours you want to refresh at as cases (minutes not supported)
                    case 9:
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
            string user = Environment.MachineName == "DESKTOP - O952AHJ" ? "LUFT" : "Eldopes"; // detecting active system user
            IWebDriver driver = new EdgeDriver(String.Format(@"C:\Users\{0}\OneDrive\Selenium", user)); // assigning the path to Selenium according to the current user 
            driver.Navigate().GoToUrl("https://hh.ru/resume/bc2a467eff030b39fc0039ed1f33626a567741");
            Thread.Sleep(500);

            try
            {
                IWebElement searchBtn = driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div/div[4]/div[2]/div/div[2]/div/div/div/div[2]/div[3]/div[2]/button"));  // finding button to click
                searchBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
            }            
            
            Thread.Sleep(200);
            driver.Close();

            foreach (Process p in Process.GetProcessesByName("MicrosoftWebDriver"))
            {
                p.Kill(); // closing Selenium console host after program has exited 
            }
            
        }
    }
}

