using Autotests.Tests.Validation.Constants;
using Autotests.TestUnits.Web;

namespace Autotests.Tests.Validation
{
    public class WebPageValidator<TWebPage>
        where TWebPage: WebPage
    {
        protected TWebPage _webPage;

        public WebPageValidator(TWebPage webPage)
        {
            _webPage = webPage;
        }

        public virtual void ValidatePageContent()
        {
            var elements = _webPage.GetPageElements();
            if(elements.Count == 0) 
            {
                throw new InvalidDataException(ErrorMessages.ElementsAreEmpty);
            }

            foreach (var element in elements)
            {
                if (element.Value.InitializerFunction == null)
                {
                    throw new InvalidDataException(string.Format(ErrorMessages.InitializerForElementNotFound, element.Key));
                }

                if (!_webPage.AllowMultiStepInitializaton && element.Value.InitializerFunction.GetInvocationList().Length > 1)
                {
                    throw new InvalidDataException(string.Format(ErrorMessages.MultiStepInitializationNotAllowed, element.Key, _webPage.GetType()));
                }
            }
        }
    }
}
