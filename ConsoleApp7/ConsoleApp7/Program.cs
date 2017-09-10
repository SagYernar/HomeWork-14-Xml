using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
        }

        static void First()
        {
            List<Item> items = new List<Item>();
            XmlDocument document = new XmlDocument();
            document.Load("https://habrahabr.ru/rss/interesting/");
            XmlNode rss = document.DocumentElement;
            XmlNode channel = rss.FirstChild;
            //Console.WriteLine(channel.Name);
            //Console.ReadLine();

            if (channel.HasChildNodes)
            {
                foreach (XmlNode child in channel.ChildNodes)
                {
                    if (child.Name == "item")
                    {
                        Item item = new Item();
                        item.Description = child["description"].InnerText;
                        item.Link = child["link"].InnerText;
                        item.Title = child["title"].InnerText;
                        item.PubDate = child["pubDate"].InnerText;
                        items.Add(item);
                    }
                }
            }

            int count = 1;
            foreach (Item item in items)
            {
                Console.WriteLine("item # " + count);
                Console.WriteLine("title: " + item.Title);
                Console.WriteLine("link: " + item.Link);
                Console.WriteLine("description: " + item.Description);
                Console.WriteLine("pubDate: " + item.PubDate + "\n\n");
                count++;
            }

            Console.WriteLine("Нажмите ENTER для запуска второй задачи...");
            Console.ReadLine();
        }

        static void Second()
        {
            XmlDocument document = new XmlDocument();

            document.Load("Student.xml");

            XmlNode student = document.CreateElement("Student");
            document.DocumentElement.AppendChild(student);
            XmlAttribute attribute = document.CreateAttribute("number");
            attribute.Value = "1";
            student.Attributes.Append(attribute);

            XmlNode name = document.CreateElement("name");
            name.InnerText = "Yernar";
            student.AppendChild(name);

            XmlNode age = document.CreateElement("age");
            age.InnerText = "23";
            student.AppendChild(age);

            XmlNode univercity = document.CreateElement("univercity");
            univercity.InnerText = "Step";
            student.AppendChild(univercity);

            XmlNode group = document.CreateElement("group");
            group.InnerText = "SDP-162";
            student.AppendChild(group);

            document.Save("Student.xml");

            Console.WriteLine("Содержание XML файла: ");
            foreach (XmlNode node in student.ChildNodes)
            {
                Console.WriteLine(node.Name + " - " + node.InnerText);
            }


            Student student_class = new Student();

            student_class.Name = student["name"].InnerText;
            student_class.Age = Int32.Parse(student["age"].InnerText);
            student_class.Univercity = student["univercity"].InnerText;
            student_class.Group = student["group"].InnerText;

            Console.WriteLine("\n\nСодержание класса Student: ");
            Console.WriteLine(student_class.Name);
            Console.WriteLine(student_class.Age);
            Console.WriteLine(student_class.Univercity);
            Console.WriteLine(student_class.Group);

            Console.ReadLine();
        }
    }
}
