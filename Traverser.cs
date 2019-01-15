namespace DOMTree
{
    using System.Text;
    public class Traverser 
    {
        public string Traverse(StringBuilder output, TreeNode<string> node, int nestedLevel)
        {
            var tabs = new string(' ', nestedLevel);

            if (node != null)
            {
                output.Append(tabs);
                output.Append($"<{node.Value}>");
            }

            foreach (var child in node.Children)
            {
                output.AppendLine();

                Traverse(output, child, nestedLevel + 1);
            }

            output.AppendLine();
            output.Append(tabs);

            if (node != null)
            {
                output.AppendFormat($"</{node.Value}>");
            }
            return output.ToString();
        }

        public string Traverse(TreeNode<string> node)
        {
            return Traverse(new StringBuilder(), node, 0);
        }
    }
}
