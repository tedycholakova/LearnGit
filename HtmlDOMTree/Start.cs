namespace HtmlDOMTree
{
    using HtmlDOMTree.Classes;
    using HtmlDOMTree.Interfaces;
    using System;

    class Start
    {
        static void Main()
        {

            IElementFactory htmlFactory = new HTMLElementFactory();

            IElement html = htmlFactory.CreateElement("html");

            IElement title = htmlFactory.CreateElement("title");
            IElement body = htmlFactory.CreateElement("body");
            //body.AddElement(new HtmlElement("h1", "Welcome"));
            //body.AddElement(new HtmlElement("div"));

            //html.AddElement(title);
            //html.AddElement(body);

            //Console.WriteLine(html);

            html.AddElement(title);
            html.AddElement(body);

            var renderer = new Renderer();

            var htmlString = renderer.Render(html);

            Console.WriteLine(htmlString);
           // tree.AddChild(html);


        }
    }
}
