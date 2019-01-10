namespace HtmlDOMTree.Classes
{
    using System.Collections.ObjectModel;
    using Interfaces;

    public class HtmlElement : IElement
    {
        private readonly TreeNode<IElement> node;

        public HtmlElement(string name)
        {
            Name = name;
            node = new TreeNode<IElement>(this);
        }

        public HtmlElement(string name, string textContent)
            : this(name)
        {
            TextContent = textContent;
        }

        public string Name { get; }

        public virtual string TextContent { get; set; }

        public ReadOnlyCollection<TreeNode<IElement>> ChildElements => node.Children;

        public void AddElement(IElement element)
        {
            node.AddChild(element);
        }
    }
}