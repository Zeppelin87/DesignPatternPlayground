using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.StrategyPattern
{
    public static class DynamicStrategy
    {
        public static void Run()
        {
            var tp = new TextProcessor1();
            tp.SetOutputFormat(OutputFormat1.Markdown);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutputFormat(OutputFormat1.Html);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);
        }
    }

    public class TextProcessor1
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy1 listStrategy;

        public void SetOutputFormat(OutputFormat1 format)
        {
            switch (format)
            {
                case OutputFormat1.Markdown:
                    listStrategy = new MarkdownListStrategy1();
                    break;
                case OutputFormat1.Html:
                    listStrategy = new HtmlListStrategy1();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
                listStrategy.End(sb);
            }
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public interface IListStrategy1
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class HtmlListStrategy1 : IListStrategy1
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

    public class MarkdownListStrategy1 : IListStrategy1
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

    public enum OutputFormat1
    {
        Unknown = 0,
        Markdown = 1,
        Html = 2
    }
}
