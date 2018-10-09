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
            else if (e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9) //启动、挂起、停止按钮
            {
                Vm vm = new Vm();
                vm.control(e.ColumnIndex - 7, this.dataGridView.Rows[e.RowIndex].Cells["path"].Value.ToString());
                refreshAll_Click(sender, e);
            }
            else if (e.ColumnIndex == 10)
            {
                vmFile.vmHost host = new vmFile.vmHost();
                host.id = this.dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
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
                    this.dataGridView.Rows[index].Cells["id"].Value = vmHost.id;
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
                    hList.Add(this.dataGridView.Rows[i].Cells["id"].Value.ToString());
                    hosts = hosts + "\r\n" + this.dataGridView.Rows[i].Cells["id"].Value.ToString();
                }
            }

            if (hList.Count > 0)
            {
                DialogResult res;

                res = MessageBox.Show(hosts, "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            /*
             * 控件列表
             * - Form：主窗体
             *   - Label：顶部警告框，默认为空
             *   - Label：id
             *   - Lable+TextBox：name标签和输入框
             *   - Lable+TextBox：path标签和输入框
             *   - Button：底部确定按钮
             *   - Button：底部取消按钮
             */
            Form cForm = new Form();
            Label warnL = new Label();
            Label idL = new Label();
            Label nameL = new Label();
            TextBox nameB = new TextBox();
            Label pathL = new Label();
            TextBox pathB = new TextBox();
            Button yesB = new Button();
            Button noB = new Button();

            //主窗体
            if (flag)
                cForm.Text = "添加虚拟机";
            else
                cForm.Text = "编辑虚拟机[" + host.id + "]";
            cForm.StartPosition = FormStartPosition.CenterScreen;
            cForm.Width = 400;
            cForm.Height = 250;
            cForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            cForm.MaximizeBox = false;

            //顶部警告框
            warnL.Name = "warn";
            warnL.Width = 380;
            warnL.ForeColor = System.Drawing.Color.Red;
            warnL.Location = new Point(10, 10);

            //id
            idL.Name = "id";
            if (flag)
                idL.Text = "";
            else
                idL.Text = host.id;
            idL.Location = new Point(50, 30);
            idL.Visible = false;

            /*
             * 名称和输入框
             *         _____________
             *   名称 |____________|
             */
            nameL.Text = "名称";
            nameL.Width = 50;
            nameL.Location = new Point(50, 50);

            nameB.Name = "name";
            nameB.Width = 250;
            nameB.Location = new Point(100, 50);
            if (!flag)
            {
                nameB.Text = host.name;
                //nameB.Enabled = false;
            }

            /*
             * 位置和输入框
             *         _____________
             *   位置 |____________|
             */
            pathL.Text = "位置";
            pathL.Width = 50;
            pathL.Location = new Point(50, 100);

            pathB.Name = "path";
            pathB.Width = 250;
            pathB.Location = new Point(100, 100);
            if (!flag)
            {
                pathB.Text = host.path;
            }

            //底部确定按钮
            yesB.Text = "确定";
            yesB.Width = 50;
            yesB.Location = new Point(125, 150);
            yesB.Click += editYesButton_Click;

            //底部取消按钮
            noB.Text = "取消";
            noB.Width = 50;
            noB.Location = new Point(225, 150);
            noB.Click += editNoButton_Click;

            //加载控件和窗口
            cForm.Controls.Add(warnL);
            cForm.Controls.Add(idL);
            cForm.Controls.Add(nameL);
            cForm.Controls.Add(nameB);
            cForm.Controls.Add(pathL);
            cForm.Controls.Add(pathB);
            cForm.Controls.Add(yesB);
            cForm.Controls.Add(noB);
            cForm.ShowDialog();
        }

        //“编辑窗口”的“确定”按钮事件
        private void editYesButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            Label idL = (Label)fm.Controls[fm.Controls.IndexOfKey("id")];
            TextBox nameB = (TextBox)fm.Controls[fm.Controls.IndexOfKey("name")];
            TextBox pathB = (TextBox)fm.Controls[fm.Controls.IndexOfKey("path")];
            Label warnL = (Label)fm.Controls[fm.Controls.IndexOfKey("warn")];

            //窗口类型：添加？编辑？
            bool flag = (idL.Text.Length == 0);

            string id = idL.Text.Trim();
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

            if (flag && vfile.isVmHostExist(id))
            {
                warnL.Text = "虚拟机["+name+"]已经存在";
                return;
            }
            
            vmFile.vmHost host = new vmFile.vmHost();
            host.id = id;
            host.name = name;
            host.path = path;

            if (flag)
            {
                host.id = System.Guid.NewGuid().ToString();
                vfile.addVmHost(host);
            }
            else
                vfile.editVmHost(host);

            fm.Close();
        }

        //“编辑窗口”的“取消”按钮
        private void editNoButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            fm.Close();
        }

        //“导入”按钮事件
        private void import_Click(object sender, EventArgs e)
        {
            string fileName;
            try
            {
                //选择导入文件
                OpenFileDialog iF = new OpenFileDialog();
                if (iF.ShowDialog() != DialogResult.OK)
                {
                    refreshAll_Click(sender, e);
                    return;
                }
                fileName = iF.FileName.ToString();

                importForm(fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Exception:\r\n" + ex.Message.ToString());
            }  
        }

        //导入窗口，显示“导入文件”中的的数据列表
        private void importForm(string fileName)
        {
            /*
             * 控件列表
             *  - Form
             *    - label：放文件名
             *    - Panal：面板，防止DataGridView
             *      - DataGridView：表格 name,path
             *    - Button：底部确定按钮
             *    - Button：底部取消按钮
             */
            Form iForm = new Form();
            Label fL = new Label();
            Panel iP = new Panel();
            DataGridView iView = new DataGridView();
            DataGridViewTextBoxColumn nBox = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn pBox = new DataGridViewTextBoxColumn();
            Button iYes = new Button();
            Button iNo = new Button();

            //fileLabel
            fL.Name = "file";
            fL.Text = fileName;
            fL.Visible = false;
            fL.Location = new Point(0, 0);

            //Panal
            iP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            iP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            iP.BackColor = System.Drawing.Color.Transparent;
            iP.Controls.Add(iView);
            iP.Location = new Point(20, 15);
            iP.Name = "iPanal";
            iP.Size = new System.Drawing.Size(560, 400);

            //表格
            iView.AllowUserToAddRows = false;
            iView.AllowUserToDeleteRows = false;
            iView.AllowUserToResizeColumns = false;
            iView.AllowUserToResizeRows = false;
            iView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            iView.BackgroundColor = iForm.BackColor;
            iView.BorderStyle = BorderStyle.None;
            iView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            iView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            iView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            iView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { nBox, pBox });
            iView.Dock = System.Windows.Forms.DockStyle.Fill;
            iView.EnableHeadersVisualStyles = false;
            iView.Location = new System.Drawing.Point(0, 0);
            iView.Name = "iView";
            iView.ReadOnly = true;
            iView.RowHeadersVisible = false;

            //表格name列
            nBox.FillWeight = 30;
            nBox.Name = "name";

            //表格path列
            pBox.FillWeight = 70;
            pBox.Name = "path";

            //iYes
            iYes.Anchor = (AnchorStyles.Bottom);
            iYes.Click += new System.EventHandler(importYesButton_Click);
            iYes.Location = new Point(200, 450);
            iYes.Name = "yes";
            iYes.Text = "确定";
            iYes.Width = 50;

            //iNo
            iNo.Anchor = (AnchorStyles.Bottom);
            iNo.Click += new System.EventHandler(importNoButton_Click);
            iNo.Location = new Point(350, 450);
            iNo.Name = "no";
            iNo.Text = "取消";
            iNo.Width = 50;

            //iForm
            iForm.AllowDrop = true;
            iForm.ClientSize = new Size(600, 500);
            iForm.Controls.Add(fL);
            iForm.Controls.Add(iP);
            iForm.Controls.Add(iYes);
            iForm.Controls.Add(iNo);
            iForm.Name = "iForm";
            iForm.KeyPreview = true;
            iForm.StartPosition = FormStartPosition.CenterScreen;
            iForm.Text = "导入";

            //layout
            iForm.Load += new System.EventHandler(iForm_Load);
            iForm.KeyDown += new System.Windows.Forms.KeyEventHandler(iForm_KeyDown);
            iP.ResumeLayout(false);
            iForm.ResumeLayout(false);

            iForm.ShowDialog();
        }

        //“导入窗口”的键盘事件
        private void iForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    iForm_Load(sender, e);
                    break;
            }
        }

        //“导入窗口”的load
        private void iForm_Load(object sender, EventArgs e)
        {
            Form iForm = (Form)sender;
            Label fL = (Label)iForm.Controls["file"];
            DataGridView iView = (DataGridView)((Panel)iForm.Controls["iPanal"]).Controls["iView"];
            bool hasError = false;

            //清空原来的表格
            iView.Rows.Clear();

            StreamReader sr = new StreamReader(fL.Text, false);
            string line;
            string[] segs;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;
                segs = line.Split(',');
                if (segs.Length <= 0)
                {
                    continue;
                }
                else if (segs.Length != 2)
                {
                    int index = iView.Rows.Add();
                    iView.Rows[index].Cells["name"].Value = segs[0];
                    iView.Rows[index].Cells["path"].Value = "这是一条错误的数据";
                    hasError = true;
                }
                else
                {
                    int index = iView.Rows.Add();
                    iView.Rows[index].Cells["name"].Value = segs[0];
                    iView.Rows[index].Cells["path"].Value = segs[1];
                }
            }
            sr.Close();

            //文件有错误，不能点击确定按钮
            if (hasError)
            {
                iForm.Controls["yes"].Enabled = false;
            }
        }

        //“导入窗口”的yes按钮事件
        private void importYesButton_Click(object sender, EventArgs e)
        {
            Form iForm = (Form)((Button)sender).Parent;
            DataGridView iView = (DataGridView)((Panel)iForm.Controls["iPanal"]).Controls["iView"];
            vmFile vfile = new vmFile();

            for (int i = 0; i < iView.Rows.Count; i++)
            {
                vmFile.vmHost host = new vmFile.vmHost();
                host.id = System.Guid.NewGuid().ToString();
                host.name = iView.Rows[i].Cells["name"].Value.ToString();
                host.path = iView.Rows[i].Cells["path"].Value.ToString();
                vfile.addVmHost(host);
                iForm.Close();
                refreshAll_Click(sender, e);
            }
        }

        //”导入窗口“的no按钮事件
        private void importNoButton_Click(object sender, EventArgs e)
        {
            Form iForm = (Form)((Button)sender).Parent;
            iForm.Close();
        }

        //“导出窗口”的按钮事件
        private void export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog oF = new SaveFileDialog();
                //设置文件类型
                oF.Filter = "数据文件(*.txt) | *.txt|数据文件(*.csv) | *.csv |数据文件(*.bak) | *.bak";
                //文件的显示顺序
                oF.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录
                oF.RestoreDirectory = true;
                //设置默认的文件名
                oF.FileName = "虚拟机备份";

                DialogResult res;
                res = oF.ShowDialog();
                if (res != DialogResult.OK)
                    return;

                string localFilePath = oF.FileName.ToString();

                vmFile vfile = new vmFile();
                vfile.exportVmHostList(localFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Exception:\r\n" + ex.Message.ToString());
            }
        }

        //设置窗口
        private void setup_Click(object sender, EventArgs e)
        {
            /*
             * 控件列表
             * - Form：主窗体
             *   - Label：顶部警告框，默认为空
             *   - Lable+TextBox：VMware路径标签和输入框
             *   - Button：底部确定按钮
             *   - Button：底部取消按钮
             */
            Form cForm = new Form();
            Label warnL = new Label();
            Label pathL = new Label();
            TextBox pathB = new TextBox();
            Button yesB = new Button();
            Button noB = new Button();

            //主窗体
            cForm.Text = "编辑";
            cForm.StartPosition = FormStartPosition.CenterScreen;
            cForm.Width = 400;
            cForm.Height = 250;
            cForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            cForm.MaximizeBox = false;

            //顶部警告框
            warnL.Name = "warn";
            warnL.Width = 380;
            warnL.ForeColor = System.Drawing.Color.Red;
            warnL.Location = new Point(10, 10);

            /*
             * VMware Workstation位置和输入框
             *                    _____________
             *   VMware安装路径 |____________|
             */
            pathL.Text = "VMware安装路径";
            pathL.Width = 90;
            pathL.Location = new Point(50, 70);

            pathB.Name = "path";
            pathB.Width = 210;
            pathB.Location = new Point(140, 70);
            vmFile vfile = new vmFile();
            pathB.Text = vfile.getVmrunPath();;

            //底部确定按钮
            yesB.Text = "确定";
            yesB.Width = 50;
            yesB.Location = new Point(125, 150);
            yesB.Click += setupYesButton_Click;

            //底部取消按钮
            noB.Text = "取消";
            noB.Width = 50;
            noB.Location = new Point(225, 150);
            noB.Click += setupNoButton_Click;

            //加载控件和窗口
            cForm.Controls.Add(warnL);
            cForm.Controls.Add(pathL);
            cForm.Controls.Add(pathB);
            cForm.Controls.Add(yesB);
            cForm.Controls.Add(noB);
            cForm.ShowDialog();
        }

        //“设置窗口”的“确定”按钮事件
        private void setupYesButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            TextBox pathB = (TextBox)fm.Controls[fm.Controls.IndexOfKey("path")];
            Label warnL = (Label)fm.Controls[fm.Controls.IndexOfKey("warn")];

            string path = pathB.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                warnL.Text = "VMware路径不能为空";
                return;
            }

            vmFile vfile = new vmFile();

            vfile.setupVmrunPath(path);

            fm.Close();
        }

        //“设置窗口”的“取消”按钮
        private void setupNoButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form fm = (Form)btn.Parent;
            fm.Close();
        }
    }
}
