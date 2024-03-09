using Autotests.PlatformAdapter.Shared.Entities;

namespace Autotests.PlatformAdapter.Shared
{
    public static class PageElementExtentions
    {
        public static bool IsEmpty<TElement>(this PageElement<TElement> pageElement)
            where TElement : class
        {
            return pageElement.Element == null;
        }
    }
}
