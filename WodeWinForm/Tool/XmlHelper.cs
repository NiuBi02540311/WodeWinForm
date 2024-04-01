using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WodeWinForm.Tool
{
  public  class XmlHelper
  {
        //public XmlHelper(){ }

        public static void CreateXmlFile(string filename)
        {
            // 创建 XmlDocument 对象
            XmlDocument xmlDoc = new XmlDocument();

            // 添加根节点
            XmlElement root = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(root);

            // 添加子节点及其内容
            //XmlElement child = xmlDoc.CreateElement("panel1Left");
            //child.InnerText = panel1.Left.ToString();
            //root.AppendChild(child);

            // 保存到文件
            //xmlDoc.Save("config.xml");
            if (filename.ToLower().EndsWith(".xml"))
            {
                xmlDoc.Save(filename);
                return;
            }
            xmlDoc.Save("config.xml");
        }
        public static void Addchild(string childNode, string InnerText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("config.xml");

            // 获取根节点
            XmlNode root = xmlDoc.SelectSingleNode("/Root");

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == childNode)
                {
                    node.InnerText = InnerText;
                    Eidtchild(childNode, InnerText);
                    return;
                }
            }

            XmlElement child = xmlDoc.CreateElement(childNode);
            child.InnerText = InnerText;
            root.AppendChild(child);
            xmlDoc.Save("config.xml");
        }
        public static void Eidtchild(string childNode, string InnerText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("config.xml");

            // 获取根节点
            XmlNode root = xmlDoc.SelectSingleNode("/Root");

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == childNode)
                {
                     node.InnerText = InnerText;
                     break;
                }
            }
            
            xmlDoc.Save("config.xml");
        }
        public static string Getchild(string childNode)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("config.xml");

            // 获取根节点
            XmlNode root = xmlDoc.SelectSingleNode("/Root");
            string InnerText = "";
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == childNode)
                {
                    InnerText = node.InnerText;
                    break;
                     
                }
            }
            return InnerText;


        }
    }
}
