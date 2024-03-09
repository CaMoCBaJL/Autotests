namespace Autotests.PlatformAdapter.Shared.Entities
{
    public class PageElement<TElement>
        where TElement : class
    {
        public TElement Element { get; set; }

        public static PageElement<TElement> Empty
        {
            get
            {
                return new PageElement<TElement>()
                {
                    Element = null
                };
            }
        }
    }
}
