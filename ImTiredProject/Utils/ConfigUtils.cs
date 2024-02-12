using System.Xml;

namespace AppiumTestProject.Utils
{
    public static class ConfigUtils
    {
        private static string rezult;
        public static string GetAndroidConfig(string variableName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"../../../Resources/testVariables.xml");
            XmlElement xmlElement = xmlDocument.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == variableName)
                            rezult = childNode.InnerText;
                    }
                }
            }
            return rezult;
        }
    }
}