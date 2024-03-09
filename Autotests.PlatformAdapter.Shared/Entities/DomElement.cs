using OpenQA.Selenium;

namespace Autotests.PlatformAdapter.Shared.Entities
{
    public class DomElement: PageElement<IWebElement>
    {
        public Func<IWebDriver, IWebElement> InitializerFunction { get; init; }

        public static new DomElement Empty
        {
            get => PageElement<IWebElement>.Empty as DomElement;
        }
    }
}
