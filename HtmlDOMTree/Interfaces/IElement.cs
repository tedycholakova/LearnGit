namespace HtmlDOMTree.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        ReadOnlyCollection<TreeNode<IElement>> ChildElements { get; }
        void AddElement(IElement element);
    }
}
