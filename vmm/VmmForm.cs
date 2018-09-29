using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace vmm
{
    public partial class VmmForm : Form
    {
        private CheckBox ckBox = new CheckBox();

        public VmmForm()
        {
            InitializeComponent();
        }

        private void VmForm_Load(object sender, EventArgs e)
        {
            refreshAll_Click(sender, e);
        }

        /*
         * 处理datagridview的点击事件
         * - 第一列的checkbox
         * - 启动、挂起、关机按钮
         */
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("您单击的是第["+e.RowIndex+"]行第["+e.ColumnIndex+"列]，单元格的内容是["+this.dataGridView.Rows[e.RowIndex].Cells[2].Value+"]");

            if (e.ColumnIndex == 0 && e.RowIndex != -1) //checkbox
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[e.RowIndex].Cells["check"];
                if (Convert.ToBoolean(checkCell.Value))
                    checkCell.Value = false;
                else
                    checkCell.Value = true;
            }
            else if (e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8) //启动、挂起、停止按钮
            {
                Vm vm = new Vm();
                vm.control(e.ColumnIndex - 6, this.dataGridView.Rows[e.RowIndex].Cells["path"].Value.ToString());
                refreshAll_Click(sender, e);
            }
            else if (e.ColumnIndex == 9)
            {
                vmFile.vmHost host = new vmFile.vmHost();
                host.name = this.dataGridView.Rows[e.RowIndex].Cells["name"].Value.ToString();
                host.path = this.dataGridView.Rows[e.RowIndex].Cells["path"].Value.ToString();
                editForm(sender, e, false, host);
                refreshAll_Click(sender, e);
            }
        }

        //刷新
        private void refreshAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView.Rows.Clear();
                
                Vm vm = new Vm();
                List<Vm.vmState> list = vm.getAllVmState();

                foreach (Vm.vmState vmHost in list)
                {
                    int index = this.dataGridView.Rows.Add();
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[index].Cells["check"];
                    checkCell.Value = false;
                    this.dataGridView.Rows[index].Cells["name"].Value = vmHost.name;
                    this.dataGridView.Rows[index].Cells["name"].ToolTipText = vmHost.path;
                    this.dataGridView.Rows[index].Cells["displayName"].Value = vmHost.displayName;
                    this.dataGridView.Rows[index].Cells["displayName"].ToolTipText = vmHost.path;
                    this.dataGridView.Rows[index].Cells["path"].Value = vmHost.path;
                    this.dataGridView.Rows[index].Cells["stateValue"].Value = vmHost.state;
                    this.dataGridView.Rows[index].Cells["start"].Value = "启动";
                    this.dataGridView.Rows[index].Cells["suspend"].Value = "挂起";
                    this.dataGridView.Rows[index].Cells["stop"].Value = "关机";
                    this.dataGridView.Rows[index].Cells["edit"].Value = "编辑";
                    switch (vmHost.state)
                    {
                        case 0:
                            this.dataGridView.Rows[index].Cells["state"].Style.BackColor = Color.LightGreen;
                            this.dataGridView.Rows[index].Cells["state"].Value = "已开机";
                            break;
                        case 1:
                            this.dataGridView.Rows[index].Cells["state"].Style.BackColor = Color.LightBlue;
                            this.dataGridView.Rows[index].Cells["state"].Value = "启动中";
                            break;
                        case 2:
                            this.dataGridView.Rows[index].Cells["state"].Style.BackColor = Color.Yellow;
                            this.dataGridView.Rows[index].Cells["state"].Value = "已挂起";
                            break;
                        case 3:
                            this.dataGridView.Rows[index].Cells["state"].Style.BackColor = Color.LightCoral;
                            this.dataGridView.Rows[index].Cells["state"].Value = "已关机";
                            break;
                        default:
                            this.dataGridView.Rows[index].Cells["state"].Style.BackColor = Color.LightGray;
                            this.dataGridView.Rows[index].Cells["state"].Value = "未知";
                            break;
                    }
                }

                /*for (int i = 0; i < 15; i++)
                {
                    int index = this.dataGridView.Rows.Add();
                    this.dataGridView.Rows[index].Cells["name"].Value = "xxx";
                    this.dataGridView.Rows[index].Cells["displayName"].Value = "xxx";
                    this.dataGridView.Rows[index].Cells["path"].Value = "xxx";
                    this.dataGridView.Rows[index].Cells["start"].Value = "启动";
                    this.dataGridView.Rows[index].Cells["suspend"].Value = "挂起";
                    this.dataGridView.Rows[index].Cells["stop"].Value = "关机";
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("[Exception]\n" + ex);
            }

            //默认根据状态排序
            this.dataGridView.Sort(this.dataGridView.Columns["stateValue"], ListSortDirection.Ascending);

            //清除选中
            this.dataGridView.ClearSelection();

            //添加复选框
            if (this.dataGridView.Rows.Count > 0)
            {
                ckBox.Checked = false;
                ckBox.Size = new Size(15, 15);
                Rectangle rect = this.dataGridView.GetCellDisplayRectangle(0, -1, true);
                Rectangle oRectangle = this.dataGridView.GetCellDisplayRectangle(0, 0, true);
                Point oPoint = new Point();
                oPoint.X = (oRectangle.Width - ckBox.Width) / 2 + 1;
                oPoint.Y = (oRectangle.Height - ckBox.Height) / 2 + 1;
                ckBox.Location = oPoint;
                ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
                this.dataGridView.Controls.Add(ckBox);
            }
        }

        //启动选中的虚拟机
        private void startSelected_Click(object sender, EventArgs e)
        {
            Vm vHost = new Vm();

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                if (Convert.ToBoolean(checkCell.Value))
                {
                    vHost.control(0, this.dataGridView.Rows[i].Cells["path"].Value.ToString());
                }
            }
            refreshAll_Click(sender, e);
        }

        //挂起选中的虚拟机
        private void suspendSelected_Click(object sender, EventArgs e)
        {
            Vm vHost = new Vm();

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                if (Convert.ToBoolean(checkCell.Value))
                {
                    vHost.control(1, this.dataGridView.Rows[i].Cells["path"].Value.ToString());
                }
            }
            refreshAll_Click(sender, e);
        }

        //关闭选中的虚拟机
        private void stopSelected_Click(object sender, EventArgs e)
        {
            Vm vHost = new Vm();

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                if (Convert.ToBoolean(checkCell.Value))
                {
                    vHost.control(2, this.dataGridView.Rows[i].Cells["path"].Value.ToString());
                }
            }
            refreshAll_Click(sender, e);
        }

        //删除选中的虚拟机
        private void deleteSelected_Click(object sender, EventArgs e)
        {
            Vm vHost = new Vm();
            List<string> hList = new List<string>();
            string hosts =  "确定要删除以下虚拟机？";

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                if (Convert.ToBoolean(checkCell.Value))
                {
                    vmFile vfile = new vmFile();
                    hList.Add(this.dataGridView.Rows[i].Cells["name"].Value.ToString());
                    hosts = hosts + "\r\n" + this.dataGridView.Rows[i].Cells["name"].Value.ToString();
                }
            }

            if (hList.Count > 0)
            {
                DialogResult res;

                res = MessageBox.Show(hosts, "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //MessageBox.Show(res.ToString());
                if (res == DialogResult.OK)
                {
                    vmFile vfile = new vmFile();
                    foreach (string n in hList)
                        vfile.delVmHost(n);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("没有选中任何虚拟机");
            }
            refreshAll_Click(sender, e);
        }

        //全选
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView.EndEdit();
            if (this.ckBox.Checked)
            {
                for (int i = 0; i < this.dataGridView.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                    if (!Convert.ToBoolean(checkCell.Value))
                    {
                        checkCell.Value = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.dataGridView.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dataGridView.Rows[i].Cells["check"];
                    if (Convert.ToBoolean(checkCell.Value))
                    {
                        checkCell.Value = false;
                    }
                }
            }
        }

        /*
         * 处理键盘事件
         * - F5：刷新datagridview
         */
        private void VmForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    VmForm_Load(sender, e);
                    break;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            editForm(sender, e, true, null);
            refreshAll_Click(sender, e);
        }

        /*
         * 添加和编辑窗口共用:
         * - flag
         *   - true：添加
         *   - false：编辑
         * - host
         *   - 要编辑的对象，添加时不需要
         */
        private void editForm(object sender, EventArgs e, bool flag, vmFile.vmHost host)
        {
            Form cForm = new Form();
            if (flag)
                cForm.Text = "添加虚拟机";
            else
                cForm.Text = "编辑虚拟机";
            cForm.StartPosition = FormStartPosition.CenterScreen;
            cForm.Width = 400;
            cForm.Height = 250;

            //顶部警告框
            Label warnL = new Label();
            warnL.Name = "warn";
            warnL.Width = 380;
            warnL.ForeColor = System.Drawing.Color.Red;
            warnL.Location = new Point(10, 10);
            cForm.Controls.Add(warnL);

            /*
             * 名称和输入框
             *         _____________
             *   名称 |____________|
             */
            Label nameL = new Label();
            nameL.Text = "名称";
            nameL.Width = 50;
            nameL.Location = new Point(50, 50);
            cForm.Controls.Add(nameL);

            TextBox nameB = new TextBox();
            nameB.Name = "name";
            nameB.Width = 250;
            nameB.Location = new Point(100, 50);
            if (!flag)
            {
                nameB.Text = host.name;
                nameB.Enabled = false;
            }
            cForm.Controls.Add(nameB);

            /*
             * 位置和输入框
             *         _____________
             *   位置 |____________|
             */
            Label pathL = new Label();
            pathL.Text = "位置";
            pathL.Width = 50;
            pathL.Location = new Point(50, 100);
            cForm.Controls.Add(pathL);

            TextBox pathB = new TextBox();
            pathB.Name = "path";
            pathB.Width = 250;
            pathB.Location = new Point(100, 100);
            if (!flag)
            {
                pathB.Text = host.path;
            }
            cForm.Controls.Add(pathB);

            //底部确定按钮
            Button yesB = new Button();
            yesB.Text = "确定";
            yesB.Width = 50;
            yesB.Location = new Point(125, 150);
            yesB.Click += yesB_Click;
            cForm.Controls.Add(yesB);

            //底部取消按钮
            Button noB = new Button();
            noB.Text = "取消";
            noB.Width = 50;
            noB.Location = new Point(225, 150);
            noB.Click += noB_Click;
            cForm.Controls.Add(noB);

            cForm.ShowDialog();
        }

        //编辑窗口的确定按钮事件
        private void yesB_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            TextBox nameB = (TextBox)fm.Controls[fm.Controls.IndexOfKey("name")];
            TextBox pathB = (TextBox)fm.Controls[fm.Controls.IndexOfKey("path")];
            Label warnL = (Label)fm.Controls[fm.Controls.IndexOfKey("warn")];

            //窗口类型：添加？编辑？
            bool flag = fm.Text.Equals("添加虚拟机");

            string name = nameB.Text.Trim();
            string path = pathB.Text.Trim();

            vmFile vfile = new vmFile();

            if (name.Length == 0)
            {
                warnL.Text = "虚拟机名称不能为空";
                return;
            }

            if (path.Length == 0)
            {
                warnL.Text = "虚拟机位置不能为空";
                return;
            }

            if (flag && vfile.isVmHostExist(name))
            {
                warnL.Text = "虚拟机["+name+"]已经存在";
                return;
            }
            
            vmFile.vmHost host = new vmFile.vmHost();
            host.name = name;
            host.path = path;

            if (flag)
                vfile.addVmHost(host);
            else
                vfile.editVmHost(host);

            fm.Close();
        }

        //编辑窗口的取消事件
        private void noB_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            fm.Close();
        }
    }
}
