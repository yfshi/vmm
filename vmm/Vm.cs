using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace vmm
{
    class Vm
    {
        /*
         * 虚拟机状态：
         * - name：配置名
         * - displayName：虚拟机名
         * - path：虚拟机的vmx路径
         * - state：虚拟机当前状态
         *   - 0：已开机
         *   - 1：正在开机
         *   - 2：已挂起
         *   - 3：已关机
         *   - 4：未知
         */
        public class vmState
        {
            public string id;
            public string name;
            public string displayName;
            public string path;
            public int state;
        };

        public List<string> getRunList()
        {
            List<string> runList = new List<string>();

            vmFile vfile = new vmFile();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = vfile.getVmrunPath();
            p.StartInfo.Arguments = "list";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            p.StandardInput.AutoFlush = true;

            StreamReader reader = p.StandardOutput;
            string output = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                output = reader.ReadLine();
                runList.Add(output);
            }

            p.WaitForExit();
            p.Close();

            return runList;
        }

        /*
         *  0: startup
         *  1: suspend
         *  2: stop
         */
        public void control(int op, string path)
        {
            string args = null;
            if (op == 0)
                args = "start " + "\"" + path + "\"" + " nogui";
            else if (op == 1)
                args = "suspend " + "\"" + path + "\"";
            else if (op == 2)
                args = "stop " + "\"" + path + "\"";

            vmFile vfile = new vmFile();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = vfile.getVmrunPath();
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            //p.WaitForExit();
            p.Close();
        }

        public List<vmState> getAllVmState()
        {
            List<vmState> list = new List<vmState>();
            vmFile vFile = new vmFile();
            List<string> runList = getRunList(); //正在运行的虚拟机
            List<vmFile.vmHost> vmHostList =  vFile.getVmHostList(); //配置的虚拟机

            foreach (vmFile.vmHost vh in vmHostList)
            {
                vmState vs = new vmState();
                vs.id = vh.id;
                vs.name = vh.name;
                vs.path = vh.path;

                /*
                 * 获取虚拟机名字和状态：
                 * - vmx文件不存在，则虚拟机不存在
                 * - vmx文件中没有checkpoint.vmState字段或为空，则处于开机或关机状态，先标记为关机状态，最后如果有开机的再更新一下
                 * - vmx文件的checkpoint.vmState字段为*.vmss，则处于挂起状态
                 * - 如果vmx发生io错误，可虚拟机正在启动，无法读取该文件
                 */
                if (!File.Exists(vh.path))
                {
                    vs.displayName = "不存在";
                    vs.state = 4;
                }
                else
                {
                    try
                    {
                        Dictionary<string, string> conf = File.ReadAllLines(vh.path)
                        .Select(line => line.Split(new[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries))
                        .Where(split => split.Length == 2)
                        .GroupBy(split => split[0].Trim())
                        .ToDictionary(group => group.Key.Trim(), group => group.Last().Last().Trim().TrimEnd('"').TrimStart('"'));

                        vs.displayName = conf["displayName"];

                        if (conf.ContainsKey("checkpoint.vmState") && conf["checkpoint.vmState"].EndsWith(".vmss"))
                            vs.state = 2;
                        else
                            vs.state = 3;
                    }
                    catch (IOException)
                    {
                        vs.displayName = "启动中";
                        vs.state = 1;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                foreach (string rp in runList)
                {
                    if (vs.path.Equals(rp))
                        vs.state = 0;
                }

                list.Add(vs);
            }

            return list;
        } 
    }
}
