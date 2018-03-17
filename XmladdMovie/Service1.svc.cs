using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Web;


namespace XmladdMovie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string AddMovie(string Title,string Runtime,string Ratings,string Genre,string Director,string Studio,string Year)
        {
            string s = "http://www.public.asu.edu/~eyang12/Movie/Movies1.xml";
            string s2 = "C:/Users/Edward/eclipse-workspace/XML/1.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            XmlNode root = doc.DocumentElement;
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Movie", "http://www.public.asu.edu/~eyang12/Movie");
            try
            {
                XmlNode nodeTitle = doc.CreateElement("Title");
                XmlNode nodeGenre = doc.CreateElement("Genre");
                nodeTitle.InnerText = Title;
                nodeGenre.InnerText = Genre;
                node.AppendChild(nodeTitle);
                node.AppendChild(nodeGenre);
            }
            catch
            {
                return "section1 error";
            }
            try
            {
                
                string[] result = Director.Split('|');
                XmlNode nodeDirector = doc.CreateElement("Director");
                XmlNode nodeName = doc.CreateElement("Name");
                XmlNode nodeFirst = doc.CreateElement("First");
                XmlNode nodeLast = doc.CreateElement("Last");
                nodeFirst.InnerText = result[0];
                nodeLast.InnerText = result[1];
                nodeDirector.AppendChild(nodeName);
                nodeName.AppendChild(nodeFirst);
                nodeName.AppendChild(nodeLast);
                node.AppendChild(nodeDirector);
                /*
                for (int i = 0; i < result.Length; i++)
                {
                    XmlNode nodeDirector = doc.CreateElement("Director");
                    XmlNode nodeName = doc.CreateElement("Name");
                    XmlNode nodeFirst = doc.CreateElement("First");
                    XmlNode nodeLast = doc.CreateElement("Last");
                    nodeFirst.InnerText = result[i];
                    nodeLast.InnerText = result[++i];
                    nodeDirector.AppendChild(nodeName);
                    nodeName.AppendChild(nodeFirst);
                    nodeName.AppendChild(nodeLast);
                    if (result[++i] != null)
                    {
                        XmlAttribute nodeHighRatedMovie = doc.CreateAttribute("High-rated-movie");
                        nodeName.Attributes.Append(nodeHighRatedMovie);
                    }
                    node.AppendChild(nodeDirector);
                }
                */
            }
            catch
            {
                return "section2 error";
            }
            try
            {
                XmlNode nodeStudio = doc.CreateElement("Studio");
                XmlNode nodeYear = doc.CreateElement("Year");
                nodeStudio.InnerText = Studio;
                nodeYear.InnerText = Year;
                node.AppendChild(nodeStudio);
                node.AppendChild(nodeYear);
                doc.DocumentElement.AppendChild(node);
                string path = HttpContext.Current.Server.MapPath("~/App_Data/1.xml");
                doc.Save(path);
            }
            catch
            {
                return "section3 error";
            }
            string appPath = System.Environment.CurrentDirectory;
            return appPath;
            
        }
        
    }
}
