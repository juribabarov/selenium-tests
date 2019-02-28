using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Threading;

namespace SeleniumTest
{
  class Program
  {
    static void Main(string[] args)
    {
      string url = "";
      Console.WriteLine("Enter url to open:");
      url = Console.ReadLine();

      if (url != null)
      {
        if (!url.StartsWith("https://"))
        {
          url = "https://" + url;
        }

        Console.WriteLine("Open url: " + url);
        Console.WriteLine("Password (leave blank to continue without password):");
        string password = Console.ReadLine();

        if (password != null)
        {
          Program p = new Program();

          //p.RouterBrowserFirefox(url);
          p.RouterBrowserChrome(url, password);
        }
      }
    }

    public void RouterBrowserFirefox(string url)
    {
      FirefoxOptions options = new FirefoxOptions();
      options.AcceptInsecureCertificates = true;

      using (IWebDriver driver = new FirefoxDriver(options))
      {
        driver.Navigate().GoToUrl(url);

        IWebElement user = driver.FindElement(By.Name("user"));

        user.SendKeys("admin");
      }
    }

    public void RouterBrowserChrome(string _url, string _password = "")
    {
      //ChromeOptions options = new ChromeOptions();
      //options.AcceptInsecureCertificates = true;

      IWebDriver driver = new ChromeDriver();
      
      driver.Navigate().GoToUrl(_url);

      IWebElement user = driver.FindElement(By.Id("username"));
      user.SendKeys("admin");

      if (_password != "")
      {
        IWebElement password = driver.FindElement(By.Id("userpasswd"));
        password.SendKeys(_password);

        IWebElement submit = driver.FindElement(By.Name("login"));
        submit.Click();
      }
    }
  }
}
