namespace HtmlDOMTree.Classes
{
    using HtmlDOMTree.Interfaces;
    using System;
    public class HTMLElementFactory : IElementFactory
    {
        //TODO: Implement IElementFactory
        public IElement CreateElement(string name)
        {
            return new HtmlElement(name);
        }
        public IElement CreateElement(string name, string textContent)
        {
            return new HtmlElement(name, textContent);
        }

        // Is there a need of this method ?
        //public IElement CreateFactory(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public ITable CreateTable(int rows, int cols)
        {
            return new HtmlTable(rows, cols);
        }
    }
}
