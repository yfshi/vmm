using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

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
            public string id;  //guid
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
                host.id = node.Attributes["id"].InnerText;
                host.name = node.Attributes["name"].InnerText;
                host.path = node.InnerText;
                list.Add(host);
                //MessageBox.Show(host.name);
            }

            return list;
        }

        public void exportVmHostList(string file)
        {
            List<vmHost> list = getVmHostList();
            StreamWriter sw = new StreamWriter(file, false);

            foreach (vmHost host in list)
            {
                sw.WriteLine(host.name + "," + host.path);
            }

            sw.Flush();
            sw.Close();
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
            //path += "\\vmrun.exe";

            //MessageBox.Show(path);
            return path;
        }

        public void setupVmrunPath(string path)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;

            node = root.SelectSingleNode("//vmware");
            if (node != null)
            {
                node.InnerText = path;
                doc.Save(vmFilePath);
            }
            else
            {
                XmlElement vmNode = doc.CreateElement("vmware");
                vmNode.InnerText = path;
                root.AppendChild(vmNode);
                doc.Save(vmFilePath);
            }
        }

        public bool isVmHostExist(string id)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@id='" + id + "']");
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
            node = root.SelectSingleNode("//vmhost[@id='" + host.id + "']");
            if (node == null)
            {
                XmlElement vmNode = doc.CreateElement("vmhost");
                vmNode.InnerText = host.path;

                //attr:name
                XmlAttribute nameAttr = doc.CreateAttribute("name");
                nameAttr.InnerText = host.name;
                vmNode.Attributes.Append(nameAttr);
                //attr:id
                XmlAttribute idAttr = doc.CreateAttribute("id");
                idAttr.InnerText = host.id;
                vmNode.Attributes.Append(idAttr);

                root.AppendChild(vmNode);
                doc.Save(vmFilePath);
            }
            else
            {
                MessageBox.Show(host.id + "已存在");
            }
        }

        public void editVmHost(vmHost host)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@id='" + host.id + "']");
            if (node == null)
            {
                MessageBox.Show(host.id + "不存在");
            }
            else
            {
                node.InnerText = host.path;
                node.Attributes["name"].InnerText = host.name;
                doc.Save(vmFilePath);
            }
        }

        public void delVmHost(string id)
        {
            XmlNode node;
            XmlNode root = doc.DocumentElement;
            node = root.SelectSingleNode("//vmhost[@id='" + id + "']");
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
