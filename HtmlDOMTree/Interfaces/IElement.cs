namespace HtmlDOMTree.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        string ToString();

    }
}
