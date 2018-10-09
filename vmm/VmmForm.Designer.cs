namespace vmm
{
    partial class VmmForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VmmForm));
            this.panel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewButtonColumn();
            this.suspend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.stop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.export = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.deleteSelected = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.stopSelected = new System.Windows.Forms.Button();
            this.suspendSelected = new System.Windows.Forms.Button();
            this.startSelected = new System.Windows.Forms.Button();
            this.refreshAll = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.dataGridView);
            this.panel.Location = new System.Drawing.Point(26, 67);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(593, 393);
            this.panel.TabIndex = 6;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = this.BackColor;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CausesValidation = false;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 21;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.id,
            this.name,
            this.path,
            this.displayName,
            this.state,
            this.stateValue,
            this.start,
            this.suspend,
            this.stop,
            this.edit});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.RosyBrown;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(593, 393);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // check
            // 
            this.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.check.Frozen = true;
            this.check.HeaderText = "";
            this.check.MinimumWidth = 30;
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 30;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.ToolTipText = "唯一标识";
            // 
            // name
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.HeaderText = "名称";
            this.name.MinimumWidth = 50;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.ToolTipText = "用户自定义名称";
            // 
            // path
            // 
            this.path.HeaderText = "位置";
            this.path.MinimumWidth = 50;
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.ToolTipText = "vmx文件路径";
            // 
            // displayName
            // 
            this.displayName.HeaderText = "虚拟机";
            this.displayName.MinimumWidth = 50;
            this.displayName.Name = "displayName";
            this.displayName.ReadOnly = true;
            this.displayName.ToolTipText = "VMWare Workstation中的显示名称";
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.state.HeaderText = "状态";
            this.state.MinimumWidth = 60;
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.ToolTipText = "虚拟机的当前状态";
            this.state.Width = 60;
            // 
            // stateValue
            // 
            this.stateValue.HeaderText = "隐藏状态";
            this.stateValue.MinimumWidth = 50;
            this.stateValue.Name = "stateValue";
            this.stateValue.ReadOnly = true;
            this.stateValue.Visible = false;
            // 
            // start
            // 
            this.start.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.start.HeaderText = "";
            this.start.MinimumWidth = 50;
            this.start.Name = "start";
            this.start.ReadOnly = true;
            this.start.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.start.Width = 50;
            // 
            // suspend
            // 
            this.suspend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.suspend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.suspend.HeaderText = "";
            this.suspend.MinimumWidth = 50;
            this.suspend.Name = "suspend";
            this.suspend.ReadOnly = true;
            this.suspend.Width = 50;
            // 
            // stop
            // 
            this.stop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stop.HeaderText = "";
            this.stop.MinimumWidth = 50;
            this.stop.Name = "stop";
            this.stop.ReadOnly = true;
            this.stop.Width = 50;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen;
            this.edit.DefaultCellStyle = dataGridViewCellStyle3;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edit.HeaderText = "";
            this.edit.MinimumWidth = 50;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 50;
            // 
            // export
            // 
            this.export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.export.BackColor = System.Drawing.Color.Transparent;
            this.export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.export.FlatAppearance.BorderSize = 0;
            this.export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.Image = global::vmm.Properties.Resources.export;
            this.export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.export.Location = new System.Drawing.Point(565, 38);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(54, 23);
            this.export.TabIndex = 10;
            this.export.Text = "导出";
            this.export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.export.UseVisualStyleBackColor = false;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // import
            // 
            this.import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.import.BackColor = System.Drawing.Color.Transparent;
            this.import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.import.FlatAppearance.BorderSize = 0;
            this.import.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.import.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import.Image = global::vmm.Properties.Resources.import;
            this.import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.import.Location = new System.Drawing.Point(565, 12);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(54, 23);
            this.import.TabIndex = 9;
            this.import.Text = "导入";
            this.import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.import.UseVisualStyleBackColor = false;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // deleteSelected
            // 
            this.deleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSelected.BackColor = System.Drawing.Color.Transparent;
            this.deleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteSelected.FlatAppearance.BorderSize = 0;
            this.deleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.deleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.deleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelected.Image = global::vmm.Properties.Resources.删除;
            this.deleteSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteSelected.Location = new System.Drawing.Point(505, 38);
            this.deleteSelected.Name = "deleteSelected";
            this.deleteSelected.Size = new System.Drawing.Size(54, 23);
            this.deleteSelected.TabIndex = 8;
            this.deleteSelected.Text = "删除";
            this.deleteSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteSelected.UseVisualStyleBackColor = false;
            this.deleteSelected.Click += new System.EventHandler(this.deleteSelected_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.FlatAppearance.BorderSize = 0;
            this.add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Image = global::vmm.Properties.Resources.add;
            this.add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add.Location = new System.Drawing.Point(505, 12);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(54, 23);
            this.add.TabIndex = 7;
            this.add.Text = "添加";
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // stopSelected
            // 
            this.stopSelected.BackColor = System.Drawing.Color.Transparent;
            this.stopSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopSelected.FlatAppearance.BorderSize = 0;
            this.stopSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.stopSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.stopSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopSelected.Image = global::vmm.Properties.Resources.stop;
            this.stopSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopSelected.Location = new System.Drawing.Point(241, 12);
            this.stopSelected.Name = "stopSelected";
            this.stopSelected.Size = new System.Drawing.Size(54, 23);
            this.stopSelected.TabIndex = 4;
            this.stopSelected.Text = "关机";
            this.stopSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stopSelected.UseVisualStyleBackColor = false;
            this.stopSelected.Click += new System.EventHandler(this.stopSelected_Click);
            // 
            // suspendSelected
            // 
            this.suspendSelected.BackColor = System.Drawing.Color.Transparent;
            this.suspendSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.suspendSelected.FlatAppearance.BorderSize = 0;
            this.suspendSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.suspendSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.suspendSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspendSelected.Image = global::vmm.Properties.Resources.suspend;
            this.suspendSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suspendSelected.Location = new System.Drawing.Point(170, 12);
            this.suspendSelected.Name = "suspendSelected";
            this.suspendSelected.Size = new System.Drawing.Size(54, 23);
            this.suspendSelected.TabIndex = 3;
            this.suspendSelected.Text = "挂起";
            this.suspendSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.suspendSelected.UseVisualStyleBackColor = false;
            this.suspendSelected.Click += new System.EventHandler(this.suspendSelected_Click);
            // 
            // startSelected
            // 
            this.startSelected.BackColor = System.Drawing.Color.Transparent;
            this.startSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startSelected.FlatAppearance.BorderSize = 0;
            this.startSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.startSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.startSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSelected.Image = global::vmm.Properties.Resources.start;
            this.startSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startSelected.Location = new System.Drawing.Point(97, 12);
            this.startSelected.Name = "startSelected";
            this.startSelected.Size = new System.Drawing.Size(54, 23);
            this.startSelected.TabIndex = 2;
            this.startSelected.Text = "启动";
            this.startSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.startSelected.UseVisualStyleBackColor = false;
            this.startSelected.Click += new System.EventHandler(this.startSelected_Click);
            // 
            // refreshAll
            // 
            this.refreshAll.BackColor = System.Drawing.Color.Transparent;
            this.refreshAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshAll.FlatAppearance.BorderSize = 0;
            this.refreshAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.refreshAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.refreshAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshAll.Image = global::vmm.Properties.Resources.refresh;
            this.refreshAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshAll.Location = new System.Drawing.Point(26, 12);
            this.refreshAll.Name = "refreshAll";
            this.refreshAll.Size = new System.Drawing.Size(54, 23);
            this.refreshAll.TabIndex = 1;
            this.refreshAll.Text = "刷新";
            this.refreshAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshAll.UseVisualStyleBackColor = false;
            this.refreshAll.Click += new System.EventHandler(this.refreshAll_Click);
            // 
            // VmmForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 488);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.deleteSelected);
            this.Controls.Add(this.add);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.stopSelected);
            this.Controls.Add(this.suspendSelected);
            this.Controls.Add(this.startSelected);
            this.Controls.Add(this.refreshAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "VmmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "虚拟机管理工具";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.VmForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VmForm_KeyDown);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshAll;
        private System.Windows.Forms.Button startSelected;
        private System.Windows.Forms.Button suspendSelected;
        private System.Windows.Forms.Button stopSelected;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button deleteSelected;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateValue;
        private System.Windows.Forms.DataGridViewButtonColumn start;
        private System.Windows.Forms.DataGridViewButtonColumn suspend;
        private System.Windows.Forms.DataGridViewButtonColumn stop;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
    }
}

