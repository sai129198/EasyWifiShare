/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 2013/11/28
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EasyWifiShare
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.labelName = new System.Windows.Forms.Label();
			this.textName = new System.Windows.Forms.TextBox();
			this.labelPsd = new System.Windows.Forms.Label();
			this.textPsd = new System.Windows.Forms.TextBox();
			this.netComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCreate = new System.Windows.Forms.Button();
			this.labelState = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.cbRemember = new System.Windows.Forms.CheckBox();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoEllipsis = true;
			this.labelName.Location = new System.Drawing.Point(12, 23);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(76, 14);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "无线名：";
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(146, 16);
			this.textName.MaxLength = 18;
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(116, 21);
			this.textName.TabIndex = 1;
			// 
			// labelPsd
			// 
			this.labelPsd.Location = new System.Drawing.Point(12, 57);
			this.labelPsd.Name = "labelPsd";
			this.labelPsd.Size = new System.Drawing.Size(76, 17);
			this.labelPsd.TabIndex = 2;
			this.labelPsd.Text = "密码：";
			// 
			// textPsd
			// 
			this.textPsd.Location = new System.Drawing.Point(146, 53);
			this.textPsd.MaxLength = 12;
			this.textPsd.Name = "textPsd";
			this.textPsd.Size = new System.Drawing.Size(116, 21);
			this.textPsd.TabIndex = 3;
			// 
			// netComboBox
			// 
			this.netComboBox.FormattingEnabled = true;
			this.netComboBox.Location = new System.Drawing.Point(146, 91);
			this.netComboBox.Name = "netComboBox";
			this.netComboBox.Size = new System.Drawing.Size(116, 20);
			this.netComboBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "要共享的网络连接：";
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(63, 156);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 6;
			this.btnCreate.Text = "创建共享";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
			// 
			// labelState
			// 
			this.labelState.Location = new System.Drawing.Point(63, 194);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(135, 18);
			this.labelState.TabIndex = 7;
			this.labelState.Text = "当前wifi共享未开启";
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(173, 156);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "删除共享";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "EasyWifiShare";
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_doubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ToolStripMenuItem,
									this.ToolStripMenuItem2});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
			// 
			// ToolStripMenuItem
			// 
			this.ToolStripMenuItem.Name = "ToolStripMenuItem";
			this.ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItem.Text = "显示主界面";
			this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemClick);
			// 
			// ToolStripMenuItem2
			// 
			this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
			this.ToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItem2.Text = "退出";
			this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(188, 243);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 19);
			this.label2.TabIndex = 9;
			this.label2.Text = "564923716@qq.com";
			// 
			// cbRemember
			// 
			this.cbRemember.Location = new System.Drawing.Point(63, 126);
			this.cbRemember.Name = "cbRemember";
			this.cbRemember.Size = new System.Drawing.Size(104, 24);
			this.cbRemember.TabIndex = 10;
			this.cbRemember.Text = "记住密码";
			this.cbRemember.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 262);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.cbRemember);
			this.Controls.Add(this.labelState);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.netComboBox);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.textPsd);
			this.Controls.Add(this.labelPsd);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.labelName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(400, 300);
			this.MaximumSize = new System.Drawing.Size(316, 300);
			this.Name = "MainForm";
			this.Text = "EasyWifiShare";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramExit);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox cbRemember;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox netComboBox;
		private System.Windows.Forms.TextBox textPsd;
		private System.Windows.Forms.Label labelPsd;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label labelName;
		
		void BtnCreateClick(object sender, System.EventArgs e)
		{
			//ShowMessage(this.netComboBox.Text);
			if(textName.Text.Equals("") || textPsd.Text.Equals("") || netComboBox.Text.Equals(""))
			{
				ShowMessage("无线名、密码、要共享的连接名都不能为空");
			}
			else if(textPsd.Text.Length < 8)
			{
				ShowMessage("密码不能少于8位");
			}
			//创建无线分享
			else{
				//记录记住密码信息
				savePsd();
				//调用创建无线分享功能
				CreateWifiShare(textName.Text, textPsd.Text, netComboBox.Text);
			}
		}
		
	}
}
