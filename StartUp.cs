namespace DOMTree
{
    using System;
    class StartUp
    {
        public static void Main()
        {
            var document = new TreeNode<string>("!DOCTYPE html");
            {
                var html = document.AddChild("html");
                {
                    var head = html.AddChild("head");
                    {
                        var meta = head.AddChild("meta");
                        var title = head.AddChild("title");
                        var link = head.AddChild("link");
                    }
                    var body = html.AddChild("body");

                    {
                        var nav = body.AddChild("nav");
                        {
                            var ol = nav.AddChild("ol");
                            {
                                var li1 = ol.AddChild("li");
                                var li2 = ol.AddChild("li");
                                var li3 = ol.AddChild("li");
                            }
                        }
                        var div = body.AddChild("div");
                        {
                            var img = div.AddChild("img");
                        }
                        var h1 = body.AddChild("h1");
                        var p1 = body.AddChild("p");
                        {
                            var div1 = p1.AddChild("div");
                        }
                        var table = body.AddChild("table");
                        {
                            var tr1 = table.AddChild("tr");
                            {
                                var th1 = tr1.AddChild("th");
                                var th2 = tr1.AddChild("th");
                                var th3 = tr1.AddChild("th");
                            }
                            var tr2 = table.AddChild("tr");
                            {
                                var td1 = tr2.AddChild("td");
                                var td2 = tr2.AddChild("td");

                                var td3 = tr2.AddChild("td");
                            }
                        }
                        var article = body.AddChild("article");
                        {
                            var figure = article.AddChild("figure");
                            {
                                var img = figure.AddChild("img");
                            }
                        }
                        var footer = body.AddChild("footer");
                        {
                            var p2 = footer.AddChild("p");
                        }
                    }
                }
            }


            var traverser = new Traverser();
            var str = traverser.Traverse(document);
            Console.WriteLine(str);



        }
    }
}
