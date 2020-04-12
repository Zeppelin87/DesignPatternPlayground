using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.StrategyPattern.StaticStrategyExample
{
    public static class StaticStrategy
    {
        public static void Run()
        {

            var markdownTextProcessor = new TextProcessor<MarkdownListStrategy>();
            markdownTextProcessor.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(markdownTextProcessor);

            var htmlTextProcessor = new TextProcessor<HtmlListStrategy>();
            htmlTextProcessor.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(htmlTextProcessor);
        }
    }

    // This generic approach is used instead of D.I.
    // Note: D.I. would be used here in the real world.
    public class TextProcessor<T> where T: IListStrategy, new ()
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy = new T();

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
                listStrategy.End(sb);
            }
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"   <li>{item}</li>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }

        public void End(StringBuilder sb)
        {

        }

        public void Start(StringBuilder sb)
        {
            // markdown doesn't require a list preamble
        }
    }

    public enum OutputFormat
    {
        Unknown = 0,
        Markdown = 1,
        Html = 2
    }
}
