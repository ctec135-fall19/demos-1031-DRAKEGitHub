using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;

namespace XMLOldWay
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildXmlDocWithDOM();
            
            BuildXmlDocWithLINQToXml();
            
            BuildFullDocument();
            Console.WriteLine("Done");
        }
        
        public static void BuildXmlDocWithDOM()
        {
            // Make a new XML document in memory
            XmlDocument doc = new XmlDocument();

            // create root element
            XmlElement inventory = doc.CreateElement("Inventory");
            
            // create a car element
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("ID", "1000");
            
            // build additional elements to be used within car
            XmlElement name = doc.CreateElement("PetName");
            XmlElement color = doc.CreateElement("Color");
            XmlElement make = doc.CreateElement("Make");
            
            // set values to elements
            name.InnerText = "Jimbo";
            color.InnerText = "Red";
            make.InnerText = "Ford";
            
            // now add elements to car element
            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);
            
            // now add car to inventory
            inventory.AppendChild(car);
            
            // insert the xml doc into the DOM and save
            doc.AppendChild(inventory);
            doc.Save("Inventory1.xml");
        }
        
        public static void BuildXmlDocWithLINQToXml()
        {
            XElement doc =
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1000"),
                        new XElement("PetName", "Jimbo"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Ford")
                )
            );
            
            // save to file
            doc.Save("Inventory2.xlm");
        }
        
        public static void BuildFullDocument()
        {
            XDocument inventoryDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Current Inventory of cars"),
                    new XElement("Inventory",
                        new XElement("Car", new XAttribute("ID", "1"),
                            new XElement("Color", "Green"),
                            new XElement("Make", "BMW"),
                            new XElement("PetName", "Stan")
                        ),
                        new XElement("Car", new XAttribute("ID", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Yugo"),
                            new XElement("PetName", "Melvin")
                        )
                    )
                );
            inventoryDoc.Save("Inventory3.xml");
        }
    }
}
