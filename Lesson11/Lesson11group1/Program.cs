// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

const string FILENAME = "..\\..\\..\\Chanuka.xml";

Console.WriteLine("Hello, World!");

XDocument doc=XDocument.Load(FILENAME );

Console.WriteLine("locations of events");

//var x = doc.Root?.Elements("event")??throw new Exception ("events not found");
//x.Where(ev=>ev.Attribute("type")?.Value.CompareTo("חברות")==0)
//    .ToList().ForEach
//    (ev => Console.WriteLine($"{ev.Attribute("name")?.Value} {ev.Element("location")?.Value }"));

//foreach (var item in x)
//{
//    Console.WriteLine(item.Attribute("name")?.Value );
//    Console.WriteLine(item.Element("location")?.Value );
//}

var y = doc.Root.Descendants("person")
        .Where(p => p.Value.CompareTo("מיכל") == 0).Ancestors("event");
y.ToList().ForEach(ev => Console.WriteLine(ev.Attribute("name")?.Value));

XElement el = new("event", new XAttribute("name", "מסיבת מסלול")
                        , new XAttribute("type", "חברות")
                        , new XElement("bringing")
                        ) ;
XElement el2 = new("location");
el2.Value = "סמינר";
el.Add(el2);
doc.Root.Add(el);
doc.Root.Save(FILENAME);



Console.WriteLine("success");