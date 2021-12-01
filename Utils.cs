using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace SpaceGame
{
    class Utils
    {
        public List<string> ReadTextFile(string filePath)
        {
            List<string> result = new List<string>();
            return result;
        }

        public List<Dictionary<string,string>> ReadPlanetXMLFile(string elementTag, bool getItems=false)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            
            if (getItems)
            {
                string filePath = @"..\..\..\Resources\Items.xml";
                foreach (XElement level1Element in XElement.Load(filePath).Elements(elementTag))
                {
                    Dictionary<string, string> planet = new Dictionary<string, string>();
                    planet.Add("name", level1Element.Attribute("name").Value);
                    foreach (XElement level2Element in level1Element.Elements())
                    {
                        planet.Add(level2Element.Name.ToString(), level2Element.Attribute("value").Value);
                    }
                    result.Add(planet);
                }

            } else
            {
                string filePath = @"..\..\..\Resources\PlanetConfig.xml";
                foreach (XElement level1Element in XElement.Load(filePath).Elements(elementTag))
                {
                    Dictionary<string, string> planet = new Dictionary<string, string>();
                    planet.Add("name", level1Element.Attribute("name").Value);
                    foreach (XElement level2Element in level1Element.Elements())
                    {
                        planet.Add(level2Element.Name.ToString(), level2Element.Attribute("value").Value);
                    }
                    result.Add(planet);
                }
            }
            
            return result;
        }
        //public List<Dictionary<string, string>> ReadItemsXMLFile(string filePath, string elementTag)
        //{

        //}
    }
}