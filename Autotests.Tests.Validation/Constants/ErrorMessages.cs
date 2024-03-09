namespace Autotests.Tests.Validation.Constants
{
    public class ErrorMessages
    {
        public const string ElementAndInitializerFunctionCountNotEqual = "Не совпадает число объявленных элементов на странице и функций-инициализаторов";

        public const string InitializerForElementNotFound = "Функция-инициализатор для элемента {0} не найдена";

        public const string TooManyInitializersForElementFound = "Для элемента {0} не может существовать более 1 функции инициализатора";
    }
}
