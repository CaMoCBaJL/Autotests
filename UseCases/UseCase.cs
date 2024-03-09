using Autotests.TestUnits.Web;

namespace UseCases
{

    public abstract class UseCase
    {
        protected WebPage Page { get; set; }

        public abstract void Initialize();

        public abstract bool Act();

        public abstract void SetupExpectations();
    }
}
