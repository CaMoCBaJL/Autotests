using OpenQA.Selenium;

namespace Autotests.PlatformAdapter.Shared.Entities
{
    public class DomElementCollection: PageElement<IWebElement[]>
    {
        public virtual Func<IWebDriver, IWebElement[]> InitializerFunction { get; init; }

        public static new DomElementCollection Empty
        {
            get => PageElement<IWebElement[]>.Empty as DomElementCollection;
        }
    }
}
