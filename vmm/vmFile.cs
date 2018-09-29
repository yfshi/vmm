using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace vmm
{
    public partial class vmFile : XmlDocument
    {
        private XmlDocument doc = new XmlDocument();
        private string vmFilePath = "./vm.xml";

        public vmFile()
        {
            doc.Load(vmFilePath);
        }

        public class vmHost
        {
            public string name;
            public string path;
        }

        public List<vmHost> getVmHostList()
        {
            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            nodeList = root.SelectNodes("//vmhost");

            List<vmHost> list = new List<vmHost>();

            foreach (XmlNode node in nodeList)
            {
                vmHost host = new vmHost();
                host.name = node.Attributes["name"].InnerText;
                host.path = node.InnerText;
                list.Add(host);
                //MessageBox.Show(host.name);
            }

            return list;
        }

        public string getVmrunPath()
        {
            XmlNode node;
            string path = "";
            XmlNode root = doc.DocumentElement;

            node = root.SelectSingleNode("//vmware");
            if (node != null)
            {
                path += node.InnerText;
            }
            path += "\\vmrun.exe";

            //MessageBox.Show(path);
            return path;
        }

        public bool isVmHostExist(string name)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@name='" + name + "']");
            if (node == null)
            {
                return false;
            }
            else
                return true;
        }

        public void addVmHost(vmHost host)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@name='" + host.name + "']");
            if (node == null)
            {
                XmlElement vmNode = doc.CreateElement("vmhost");
                vmNode.InnerText = host.path;
                XmlAttribute attr = doc.CreateAttribute("name");
                attr.InnerText = host.name;
                vmNode.Attributes.Append(attr);
                root.AppendChild(vmNode);
                doc.Save(vmFilePath);
            }
            else
            {
                MessageBox.Show(host.name + "已存在");
            }
        }

        public void editVmHost(vmHost host)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@name='" + host.name + "']");
            if (node == null)
            {
                MessageBox.Show(host.name + "不存在");
            }
            else
            {
                node.InnerText = host.path;
                doc.Save(vmFilePath);
            }
        }

        public void delVmHost(string name)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@name='" + name + "']");
            if (node != null)
            {
                node.ParentNode.RemoveChild(node);
                doc.Save(vmFilePath);
            }
        }

        public void test()
        {
            //getVmHostList();

            getVmrunPath();

            /*vmHost host = new vmHost();

            host.name = "xxx";
            host.path = "zzzzzzzzzzzzzzz";

            delVmHost(host.name);

            addVmHost(host);

            host.path = "yyyyyyyyyyyyyy";
            editVmHost(host);*/
        }
    }
}
