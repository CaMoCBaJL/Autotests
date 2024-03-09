using OpenQA.Selenium;

namespace Autotests.PlatformAdapter.Shared.Entities
{
    public class DomElement: PageElement<IWebElement>
    {
        public virtual Func<IWebDriver, IWebElement> InitializerFunction { get; init; }

        public static new DomElement Empty
        {
            get => PageElement<IWebElement>.Empty as DomElement;
        }

        public virtual void Reinitialize(IWebDriver driver)
        {
            Element = InitializerFunction?.Invoke(driver);
        }
    }
}
