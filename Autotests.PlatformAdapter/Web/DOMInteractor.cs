using OpenQA.Selenium;

namespace Autotests.PlatformAdapter.Web
{
    public class DOMInteractor
    {
        private readonly IWebDriver _driver;

        public DOMInteractor(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public List<IWebElement> FindByClassName(string className)
        {
            return _driver.FindElements(By.ClassName(className)).ToList();
        }

        public List<IWebElement> FindByCssSelector(string css)
        {
            return _driver.FindElements(By.CssSelector(css)).ToList();
        }
    }
}
