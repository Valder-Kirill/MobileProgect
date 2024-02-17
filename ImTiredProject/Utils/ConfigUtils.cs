using System.Xml;

namespace AppiumTestProject.Utils
{
    public static class ConfigUtils
    {
        public static string GetAndroidConfig(string variableName)
        {
            var rezult = string.Empty;

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(@"../../../Resources/testVariables.xml");
            var xmlElement = xmlDocument.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement!)
            {
                if (xmlNode.Attributes!.Count > 0)
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