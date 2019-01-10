namespace HtmlDOMTree.Classes
{
    using System;

    using HtmlDOMTree.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HtmlElement : TreeNode<IElement>, IElement
    {
        // ICollection use because of Add method
        private readonly ICollection<IElement> _childElements;
        public HtmlElement(string name)
                : base()
        {
            this.Name = name;
            this._childElements = new List<IElement>();
        }

        public HtmlElement(string name, string textContent)
                            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get
            {
                return this._childElements;
            }

            set
            {
                this.ChildElements = value;
            }
        }

        public virtual void AddElement(IElement element)
        {
            this._childElements.Add(element);
        }

       
    }
}
