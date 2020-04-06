using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterPlayground.DesignPatterns.Creational.Builder
{
    public static class Builder
    {
        public static void Run()
        {
            // Example - Simple
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append("Hello ");
            sb.Append("World");
            sb.Append("</p>");
            Console.WriteLine(sb); // output: <p>Hello World</p>

            // Example - Involved
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello").AddChild("li", "World");
            Console.WriteLine(builder.ToString()); // output: <ul><li>Hello</li><li>World</li></ul>
        }
    }

    public class HtmlBuilder
    {
        private readonly string _parentTag;

        HtmlElement parentElement { get; set; } = new HtmlElement();

        public HtmlBuilder(string parentTag)
        {
            _parentTag = parentTag;
            parentElement.Tag = parentTag;
        }

        public HtmlBuilder AddChild(string tag, string text)
        {
            var childHtmlElement = new HtmlElement(tag, text);
            parentElement.ChildHtmlElements.Add(childHtmlElement);
            return this;
        }

        public void Clear()
        {
            parentElement = new HtmlElement() { Tag = _parentTag };
        }

        public override string ToString()
        {
            return parentElement.ToString();
        }
    }

    public class HtmlElement
    {
        private const int indentSize = 2;

        public string Tag { get; set; }
        public string Text { get; set; }
        public IList<HtmlElement> ChildHtmlElements { get; set; } = new List<HtmlElement>();

        public HtmlElement() { }

        public HtmlElement(string tag, string text)
        {
            Tag = tag;
            Text = text;
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        // Builds a formal html parent/child element with proper line breaks & indentation.
        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{this.Tag}>");

            if (!string.IsNullOrEmpty(this.Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(this.Text);
            }

            foreach (var element in ChildHtmlElements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{this.Tag}>");
            return sb.ToString();
        }
    }
}
