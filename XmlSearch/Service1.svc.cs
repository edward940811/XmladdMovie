using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace XmlSearch
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Getnode(string url,string key)
        {
           
            string s = url;
            string solution = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            var stringWriter = new StringWriter();
            var xmlTextWriter = XmlWriter.Create(stringWriter);
            {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                //return stringWriter.GetStringBuilder().ToString();
            }
            string fileData = stringWriter.GetStringBuilder().ToString();
            fileData = fileData.Replace("xmlns=\"", " whocares=\"");
            using (StringReader sr = new StringReader(fileData))
            {
                doc.Load(sr);
            }
            XPathDocument document = new XPathDocument(s);
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator nodes3 = navigator.Select(key);
            nodes3.MoveNext();
            XPathNavigator nodesNavigator = nodes3.Current;
            XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);
            /*
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("bk", NameSpace);
            XPathNodeIterator nodes3 = navigator.Select("/bk:Movies/bk:Movie/bk:Director", manager);
            nodes3.MoveNext();
            XPathNavigator nodesNavigator = nodes3.Current;
            XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);
            */
            while (nodesText.MoveNext())
                solution += nodesText.Current.Value;

            return solution;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
