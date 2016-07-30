using System;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using PostViewerTool.Properties;
using System.Xml.Xsl;
using System.IO;

namespace PostViewerTool.Utility
{
    static class Conversion
    {
        /// <summary>
        /// Gets the XML conversion of text
        /// </summary>
        /// <returns>The Xml text</returns>
        public static string ToXml(string inputcontent)
        {
            if (string.IsNullOrEmpty(inputcontent))
            {
                throw new ArgumentException("inputcontent");
            }

            using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(inputcontent), XmlDictionaryReaderQuotas.Max))
            {
                XElement xElement = XElement.Load(reader);
                return xElement.ToString();
            }
        }

        /// <summary>
        /// Gets the HTML conversion of text
        /// </summary>
        /// <returns>The Html Content</returns>
        public static string ToHtml(string inputcontent)
        {
            if (string.IsNullOrEmpty(inputcontent))
            {
                throw new ArgumentException("inputcontent");
            }

            string xmltext = ToXml(inputcontent);
            StringWriter results = new StringWriter();
            try
            {
                XslCompiledTransform transform = new XslCompiledTransform();
                using (XmlReader xmlreader = XmlReader.Create(new StringReader(Resources.HtmlParser)), xsltreader = XmlReader.Create(new StringReader(xmltext)))
                {
                    transform.Load(xmlreader);
                    transform.Transform(xsltreader, null, results);
                    return results.ToString();
                }
            }
            finally
            {
                results.Dispose();
            }
        }

    }
}
