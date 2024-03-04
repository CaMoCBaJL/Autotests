namespace Autotests.ComponentTree.Entities.Web
{
    public class HtmlElement
    {

        public string Tag { get; set; }

        public string[] Attributes { get; set; }

        public string[] Classes { get; set; }

        public static HtmlElement Root
        {
            get => new HtmlElement
            {
                Tag = "html",
                Attributes = [],
                Classes = [],
            };
        }
    }
}
