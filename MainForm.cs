/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 2013/11/28
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;	//process所在
using System.Net;
using System.IO;
using NETCONLib;			//网络设置的dll
using System.Net.NetworkInformation;
using System.Data;
using System.Net.Sockets;

namespace EasyWifiShare
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		bool isShare = false;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//从记住密码信息文件中读取信息
			readPsd();
			//设置下拉框为当前连接
			SetComboBox();
		}
		
		//弹出消息框
		void ShowMessage(string msg)
		{
			MessageBox.Show(msg);
		}
		
		//控制台命令，并返回结果
		public string executeCmd(string Command)
        {
				ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c C:\\Windows\\System32\\cmd.exe";
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute =false ;
                startInfo.CreateNoWindow = true;			//新加的，用来不显示控制台
                startInfo.Verb = "RunAs";
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.StandardInput.WriteLine(Command);
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
                string strRst = process.StandardOutput.ReadToEnd();
                process.Close();
                return strRst;
                //Bootinitext.AppendText("\n"+strRst );
               // process.WaitForExit();
                
                /*
            Process process = new Process
            {
                StartInfo = { FileName = " cmd.exe ", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, CreateNoWindow = true }
            };
            process.Start();
            process.StandardInput.WriteLine(Command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
            */
        }
		
		//创建无线共享的方法
		void CreateWifiShare(string name, string key, string netName)
		{
			//新建网络
			string command = "netsh wlan set hostednetwork mode=allow ssid=" + name + " key=" + key;
            string str2 = executeCmd(command);
            
            executeCmd("netsh wlan start hostednetwork");
            //设置共享映射
            try
            {
               	string connectionToShare = netName; // 被共享的网络连接
               	string sharedForConnection = "";//"Microsoft Virtual wlan Miniport Adapter";无线网络连接 2
               	//得到需要共享的网络连接的名字
               	System.Net.NetworkInformation.NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
           		foreach (System.Net.NetworkInformation.NetworkInterface ni in interfaces)
            	{
           			/*if(ni.Description.Contains("Virtual WiFi") ||ni.Description.Contains("托管网络虚拟适配器"))
                	{
                		//Console.WriteLine("虚拟WIFI" + ni.Name);
                		sharedForConnection = ni.Name;
                			//MessageBox.Show(netName + sharedForConnection);
                		break;
                		}*/
           			//根据IP来找虚拟无线网卡
           			IPInterfaceProperties fIPInterfaceProperties = ni.GetIPProperties();
                	UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = fIPInterfaceProperties.UnicastAddresses;
                	foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
                	{
                    	if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    	{
                    		//Console.WriteLine("Ip Address .......... : {0}", UnicastIPAddressInformation.Address); // Ip 地址
                    		if(UnicastIPAddressInformation.Address.ToString().Equals("192.168.137.1"))
                    		{
                    			sharedForConnection = ni.Name;
                    		}
                    	}
                       	 		
                	}
                
            	}
                //string sharedForConnection = "无线网络连接 2"; // 需要共享的网络连接
                		
 
                var manager = new NetSharingManager();
                var connections = manager.EnumEveryConnection;
 
                foreach (INetConnection c in connections)
                {
                    var props = manager.NetConnectionProps[c];
                    var sharingCfg = manager.INetSharingConfigurationForINetConnection[c];
                    if (props.Name == connectionToShare)
                    {
                       	sharingCfg.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC);
                    }
                    else if (props.Name == sharedForConnection)
                    {
                    			
                        sharingCfg.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE);
                    }
                }
 				labelState.Text = "已开启wifi共享";
 				isShare = true;
 				btnCreate.Enabled = false;
 				textName.Enabled = false;
 				textPsd.Enabled = false;
 				netComboBox.Enabled = false;
 				btnDelete.Enabled = true;
               			
            }
            catch
            {
                MessageBox.Show("共享失败，请打开网络和共享中心.查看要共享的连接名称是否和上面选择的一致!",
                   "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
          	}    	
            		
            /*
            //这里返回的如果是英文呢？
            //新建共享网络成功！设置承载网络模式为允许
            if (((str2.IndexOf("承载网络模式已设置为允许") > -1) && (str2.IndexOf("已成功更改承载网络的 SSID。") > -1)) && (str2.IndexOf("已成功更改托管网络的用户密钥密码。") > -1))
            {
            	//启动承载网络成功
                if (executeCmd("netsh wlan start hostednetwork").IndexOf("已启动承载网络") > -1)
           		{
			 
                	//设置共享映射
                	try
            		{
                		string connectionToShare = netName; // 被共享的网络连接
                		string sharedForConnection = "无线网络连接 2"; // 需要共享的网络连接
 
                		var manager = new NetSharingManager();
                		var connections = manager.EnumEveryConnection;
 
                		foreach (INetConnection c in connections)
                		{
                    		var props = manager.NetConnectionProps[c];
                    		var sharingCfg = manager.INetSharingConfigurationForINetConnection[c];
                    		if (props.Name == connectionToShare)
                    		{
                       			sharingCfg.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC);
                    		}
                    		else if (props.Name == sharedForConnection)
                    		{
                        		sharingCfg.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE);
                    		}
                		}
 						labelState.Text = "已开启wifi共享";
 						isShare = true;
 						btnCreate.Enabled = false;
 						textName.Enabled = false;
 						textPsd.Enabled = false;
 						netComboBox.Enabled = false;
 						btnDelete.Enabled = true;
               			
            		}
            		catch
            		{
                		MessageBox.Show("共享失败，请打开网络和共享中心.查看要共享的连接名称是否和上面选择的一致!",
                    	"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
          			}
            		
           		}
                //启动承载网络失败
            	else
            	{
                	MessageBox.Show("创建共享失败，可能由于系统没有开启ICS服务.错误号02");
            	}

            }
            //新建共享网络失败
            else
            {
            	MessageBox.Show("创建共享失败，可能由于系统没有开启ICS服务。错误号01");
            }
            */

		}
		
		//按下删除共享的按钮
		void BtnDeleteClick(object sender, EventArgs e)
		{
			DeleteShare();
		}
		
		//删除无线共享的方法
		void DeleteShare()
		{
			executeCmd("netsh wlan stop hostednetwork");
			executeCmd("netsh wlan set hostednetwork mode=disallow");
			labelState.Text = "当前wifi共享未开启";
      		isShare = false;
      		btnCreate.Enabled = true;
      		textName.Enabled = true;
      		textPsd.Enabled = true;
      		netComboBox.Enabled = true;
      		btnDelete.Enabled = false;
			/*
			//先停止网络承载	
			if (executeCmd("netsh wlan stop hostednetwork").IndexOf("已停止承载网络") > -1)
            {
                string command = "netsh wlan set hostednetwork mode=disallow";
         	    executeCmd(command);			//承载网络模式设为禁止
      			//更改控件状态
      			labelState.Text = "当前wifi共享未开启";
      			isShare = false;
      			btnCreate.Enabled = true;
      			textName.Enabled = true;
      			textPsd.Enabled = true;
      			netComboBox.Enabled = true;
      			btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show("删除共享失败，请重试！");
            }*/
		}
		
		//退出程序函数，这里检查wifi是否处于分享状态，如果是则提示是否继续退出，退出的话，wifi共享也将被关闭
		void ProgramExit(object sender, FormClosingEventArgs e)
		{
			//如果wifi正处于分享状态，那么提示用户是否继续退出
			if(isShare)
			{
				//如果选择退出,关闭wifi再退出
				if(
					MessageBox.Show("现在开启了wifi无线热点分享，如果退出将会关闭该热点，是否继续？",
				                "是否继续退出",
				               MessageBoxButtons.OKCancel,
				               MessageBoxIcon.Question) 
					== DialogResult.OK
				  )
				{
					DeleteShare();
				}
				else						//如果选择了取消
				{
					e.Cancel = true;		//取消关闭窗口事件
				}
			}
		}
		
		//双击托盘图标
		void NotifyIcon1_doubleClick(object sender, EventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
			this.Show();
			this.ShowInTaskbar = true;
			notifyIcon1.Visible = false;		//隐藏托盘图标
		}
		
		//点击最小化按钮
		void MainFormResize(object sender, EventArgs e)
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
				this.Hide();
				this.ShowInTaskbar = false;
				notifyIcon1.Visible = true;
			}
		}
		
		//托盘右键菜单显示主界面
		void ToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
			this.Show();
			this.ShowInTaskbar = true;
			notifyIcon1.Visible = false;		//隐藏托盘图标
		}
		
		//托盘右键菜单退出
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			//如果wifi正处于分享状态，那么提示用户是否继续退出
			if(isShare)
			{
				//如果选择退出,关闭wifi再退出
				if(
					MessageBox.Show("现在开启了wifi无线热点分享，如果退出将会关闭该热点，是否继续？",
				                "是否继续退出",
				               MessageBoxButtons.OKCancel,
				               MessageBoxIcon.Question) 
					== DialogResult.OK
				  )
				{
					DeleteShare();			//关闭热点分享
					//退出程序
					Environment.Exit(0);
				}
				else						//如果选择了取消
				{
					return;
				}
			}
			else	//如果此时并没热点分享
			{
				//退出程序
				Environment.Exit(0);
			}
		}
		
		/*******************************************************************************/
		//从保存密码文件中读取信息
		void readPsd()
		{
			string path = "msg.wf";
			if(!File.Exists(path))
			{
				return;
			}
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string msg = sr.ReadToEnd();
			//MessageBox.Show(msg);
			string[] str = msg.Split('#');
			
			/////////////////////////////////////////////////////
			//检查用户有没有选择记住密码,有则加载密码
			if(str[0].Equals("true"))
			{
				cbRemember.Checked = true;
				//判断用户名或者密码框是否为空的情况
				if(str.Length == 3)
				{
					textName.Text = str[1];
					textPsd.Text = str[2];
				}
			}
			else
			{
				cbRemember.Checked = false;
			}
			sr.Close();
			fs.Close();
		}
		/**********************************************************************************/
		//记住密码功能,把几个复选框状态、连同账号密码一起保存
		void savePsd()
		{
			string path = "msg.wf";
			
			if(File.Exists(path))	//删除原来的
			{
				File.Delete(path);
			}
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			StreamWriter sw = new StreamWriter(fs);
			//如果选中保存密码功能
			if(cbRemember.Checked)
				sw.Write("true#");
			else 
				sw.Write("false#");
			
			sw.Write(textName.Text + "#");
			sw.Write(textPsd.Text);
			sw.Close();
			fs.Close();
		}
		/**********************************************************************************/
		
		
		//设置下拉框的函数
		void SetComboBox()
		{
			List<string> items = new List<string>();
			
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    //Console.WriteLine("当前正在连接的IP是："+ni.Name);
                    items.Add(ni.Name);
                }
                /*else
                {
                     Console.WriteLine("当前IP"+ni.Name+"处于静止或者中断状态。");
                }*/
            }
			netComboBox.ValueMember = "text";		
			netComboBox.DisplayMember = "value";
			netComboBox.DataSource = items;
		}
	}

}
