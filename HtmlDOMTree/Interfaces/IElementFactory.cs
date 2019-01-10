namespace HtmlDOMTree.Interfaces
{
    using System;
    interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }
}
