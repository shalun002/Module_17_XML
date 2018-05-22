using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/*
1.	Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/  Создать класс Item со свойствами: Title, Link, Description, PubDate.
Создать коллекцию типа List<Item> и записать в нее данные из файла.
2.	На основании задания 1, сериализовать лист полученных объектов в XML и записать в файл.

 */
namespace Module_17_XML
{
    class Program
    {
        public class HabrNews
        {
            public string  Title { get; set; }
            public string Link { get; set; }
            public string Description { get; set; }
            public DateTime PubDate { get; set; }
        }
        static void Main(string[] args)
        {
            #region XML
            //XmlDocument doc = new XmlDocument();
            //XmlElement root = doc.CreateElement("User");
            //XmlElement name = doc.CreateElement("Name");

            //name.InnerText = "Sergey";

            ////1
            //XmlAttribute atr = doc.CreateAttribute("IIN");
            //atr.InnerText = "868888888888";
            //name.Attributes.Append(atr);

            ////2
            ////name.SetAttribute("IIN", "868888888888");

            //root.AppendChild(name);
            //doc.AppendChild(root);
            //doc.Save("UserSergey.xml");
            #endregion

            List<HabrNews> habrNews = new List<HabrNews>();


            XmlDocument doc = new XmlDocument();
            doc.Load("https://habrahabr.ru/rss/interesting/");

            var rootElement = doc.DocumentElement;
            foreach (XmlNode item in rootElement.ChildNodes)
            {
                Console.WriteLine(item.Name);

                foreach (XmlNode ch in item.ChildNodes )
                {
                    Console.WriteLine(ch.Name);
                    if (ch.Name == "item")
                    {
                        HabrNews hNews = new HabrNews();

                        foreach (XmlNode x in item.ChildNodes)
                        {
                            if(x.Name == "title")
                            {
                                hNews.Title = x.InnerText;
                            }
                            else if(x.Name == "Link")
                            {
                                hNews.Link = x.InnerText;
                            }
                            else if (x.Name == "Description")
                            {
                                hNews.Description = x.InnerText;
                            }
                            else if (x.Name == "PubDate")
                            {
                                hNews.PubDate = Int32.Parse(;
                            }
                            Console.WriteLine("-->" + x.Name);
                            Console.WriteLine("-->" + x.InnerText);
                        }
                        habrNews.Add(hNews);
                    }
                }
            }

            foreach (var item in habrNews)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Link);
                Console.WriteLine("");
            }
        }
    }
}