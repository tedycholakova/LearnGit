namespace HtmlDOMTree.Classes
{
    using HtmlDOMTree.Interfaces;
    using System.Text;

    public class Renderer
    {
        public string Render(StringBuilder output,IElement node, int nestedLevel)
        {
            var tabs = new string(' ', nestedLevel);

            if (!string.IsNullOrEmpty(node.Name))
            {
                output.Append(tabs);
                output.Append($"<{node.Name}>");
            }

            if (!string.IsNullOrEmpty(node.TextContent))
            {
                this.Encode(node.TextContent, output);
            }

            foreach (var child in node.ChildElements)
            {
                output.AppendLine();
                output.Append(' ', nestedLevel);

                Render(output, child.Value, nestedLevel + 1);
            }

            output.AppendLine();
            output.Append(tabs);

            if (!string.IsNullOrEmpty(node.Name))
            {
                output.AppendFormat($"</{node.Name}>");
            }



            return output.ToString();
        }

        //TODO: Switch cases
        private void Encode(string textContent, StringBuilder outputString)
        {
            foreach (var symbol in textContent)
            {
                switch (symbol)
                {
                    case '<':
                        outputString.Append("%lt;");
                        break;
                    case '>':
                        outputString.Append("%gt;");
                        break;
                    case '&':
                        outputString.Append("%amp;");
                        break;
                    default:
                        outputString.Append(symbol);
                        break;
                }
            }
        }

        public string Render(IElement node)
        {
            return Render(new StringBuilder(), node, 0);
        }
    }
}
