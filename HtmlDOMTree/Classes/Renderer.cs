namespace HtmlDOMTree.Classes
{
    using HtmlDOMTree.Interfaces;
    using System;
    using System.Text;

    public class Renderer
    {
        public IElement Element { get; set; }
        public virtual void Render(StringBuilder output, int nestedLevel)
        {
            var tabs = new string(' ', nestedLevel);

            if (!string.IsNullOrEmpty(this.Element.Name))
            {
                output.Append(tabs);
                output.Append($"<{this.Element.Name}>");
            }

            if (!string.IsNullOrEmpty(this.Element.TextContent))
            {
                string encodedContest = this.Encode(this.Element.TextContent, output.ToString());
                output.Append(encodedContest);
            }

            foreach (var child in this.Element.ChildElements)
            {
                output.AppendLine();
                output.Append(' ', nestedLevel);

                Render(output, nestedLevel + 1);
            }

            output.AppendLine();
            output.Append(tabs);

            if (!string.IsNullOrEmpty(this.Element.Name))
            {
                output.AppendFormat($"</{this.Element.Name}>");
            }



            
        }

        //TODO: Switch cases
        private string Encode(string textContent, string outputString)
        {
            var output = new StringBuilder();
            for (int i = 0; i < this.Element.TextContent.Length; i++)
            {
                var symbol = this.Element.TextContent[i];

                switch (symbol)
                {
                    case '<':
                        output.Append("%lt;");
                        break;
                    case '>':
                        output.Append("%gt;");
                        break;
                    case '&':
                        output.Append("%amp;");
                        break;
                    default:
                        output.Append(symbol);
                        break;
                }
            }

            return output.ToString();
        }



        public override string ToString()
        {
            var output = new StringBuilder();
            this.Render(output, 0);

            return output.ToString();
        }
    }
}
