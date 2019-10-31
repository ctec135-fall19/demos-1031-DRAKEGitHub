using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// add these to the top to use XML
using System.Xml;
using System.Xml.Linq;
// shortcut to pull in the library to use the methods in it
using static System.Console;

namespace ReadAndQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Loading an XML doc");

            XDocument myDoc = XDocument.Load("Inventory3.xml");
            WriteLine(myDoc);
            WriteLine();

            var result = from car in myDoc.Descendants("Car")
                         where ((string)car.Attribute("ID")).Equals("2")
                         select car;

            foreach (var car in result)
                WriteLine(car);
        }
    }
}
