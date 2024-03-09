namespace Autotests.Tests.Validation.Constants
{
    public class ErrorMessages
    {
        public const string InitializerForElementNotFound = "Функция-инициализатор не задана для элемента {0}";

        public const string ElementsAreEmpty = "Страница не содержит элементов";

        public const string MultiStepInitializationNotAllowed = "Для элемента {0} страницы {1} нельзя совершать несколько вызовов для инциализации элементов";

        public const string UnableToCreateAbstractPage = "Невозможно создать страницу {0}, т.к. она использует базовую релаизацию метода создания страницы";
    }
}
