// 04. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.

namespace ExpensiveAlbumsDeleting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class Demo
    {
        static void Main()
        {
            DeleteAlbumsByCost(20.00M);
        }

        private static void DeleteAlbumsByCost(decimal limitPrice)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            foreach (XmlNode node in doc.SelectNodes("//album"))
            {
                if (decimal.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }

            doc.Save("../../../modified.xml");
        }
    }
}
