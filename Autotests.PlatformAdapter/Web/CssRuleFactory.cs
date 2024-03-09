using System.Text;

namespace Autotests.PlatformAdapter.Web
{
    public class CssRuleFactory
    {
        private StringBuilder _rule = new StringBuilder();

        public CssRuleFactory WithId(string id)
        {
            _rule.Append($"#{id}");

            return this;
        }

        public CssRuleFactory WithClass(string className)
        {
            _rule.Append($".{className}");

            return this;
        }

        public CssRuleFactory WithTag(string tag)
        {
            _rule.Append(tag);

            return this;
        }

        public CssRuleFactory WithAttribute(string attributeName, string attributeValue)
        {
            _rule.Append($"[{attributeName}=\"{attributeValue}\"]");

            return this;
        }

        public string CompileRule() => _rule.ToString();
    }
}
