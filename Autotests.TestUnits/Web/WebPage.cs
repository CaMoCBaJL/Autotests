using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.Tests.Validation;
using Autotests.Tests.Validation.Constants;
using Autotests.TestUnits.Base;
using OpenQA.Selenium;

namespace Autotests.TestUnits.Web
{
    public abstract class WebPage : TestUnit
    {
        protected Dictionary<string, DomElement> _pageElements;

        protected WebPage()
        {

        }

        protected virtual void ValidatePageContent()
        {
            new WebPageValidator<WebPage>(this).ValidatePageContent();
        }

        protected virtual void CreatePageContent()
        {
            _pageElements = new Dictionary<string, DomElement>();
        }

        protected virtual void InitializePageContent(IWebDriver webDriver)
        {
            foreach (var element in _pageElements)
            {
                element.Value.Element = element.Value.InitializerFunction(webDriver);
            }
        }

        public static WebPage Create(IWebDriver webDriver)
        {
            throw new MemberAccessException(string.Format(ErrorMessages.UnableToCreateAbstractPage, typeof(WebPage)));
        }

        public string Url { get; set; }

        public Dictionary<string, DomElement> GetPageElements() => new Dictionary<string, DomElement>(_pageElements);

        public bool AllowMultiStepInitializaton { get; } = false;
    }
}
