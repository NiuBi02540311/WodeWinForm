using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using WodeWinForm.View;
namespace WodeWinForm
{
    
    public partial class Index : Form
    {
        private readonly DataTable MenuDataTable = null;

        private ImageList imageList;
        private ContextMenuStrip contextMenuStrip;
        public Index()
        {
            InitializeComponent();
            //https://www.jb51.net/article/80196.htm
            //this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseUp += panel1_MouseUp;
            panel1.MouseMove += panel1_MouseMove;
            panel1.Top = menuStrip1.Height;
            //panel1.Left = treeView1.Left + treeView1.Width;
            panel1.Left = tableLayoutPanel1.Left + tableLayoutPanel1.Width;
            panel1.Height = panel1.Parent.Height;

            //panel1.MouseDown += panel1_MouseDown;
            //panel1.MouseUp += panel1_MouseUp;
            //panel1.MouseMove += panel1_MouseMove;
            //panel1.Top = menuStrip1.Height;
            //panel1.Left = treeView1.Left + treeView1.Width;
            //panel1.Height = panel1.Parent.Height;

            this.Resize += ParentForm_Resize;
            this.Load += ParentForm_Load; //treeView1_NodeMouseDoubleClick
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;

            //ToolStripMenuItem1_Click();
            //ToolStripMenuItem1_Click2();
            MenuDataTable = GetMenuData();
            this.fullTabControl1.TabPages.Clear();
            //this.fullTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //this.fullTabControl1.DrawItem += tabControlLeft_DrawItem;
        }

        private void Form_Alert_Load(object sender, EventArgs e)
        {
            SaveConfig(true);
            LoadPng();
            LoadContextMenuStrip();
            
    }

        private DataTable GetMenuData()
        {
            //(string assemblyName, string typeName);
            DataTable ErrorData = new DataTable("ErrorData");

            ErrorData.Columns.Add("ID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("ParentID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("Name", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("assemblyName", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("typeName", System.Type.GetType("System.String"));

            ErrorData.Rows.Add("1", "0", "学生管理");
            ErrorData.Rows.Add("2", "0", "教师管理");
            ErrorData.Rows.Add("3", "1", "学生信息录入", "WodeWinForm", "WodeWinForm.View.Form1");
            ErrorData.Rows.Add("4", "2", "教师信息录入", "WodeWinForm", "WodeWinForm.View.Form2");
            for (int i= 5; i < 16; i++)
            {
                ErrorData.Rows.Add(i, i % 2 == 0 ? 1:2, "教师信息录入"+i, "WodeWinForm", "WodeWinForm.View.Form2");
            }
           
            return ErrorData;
        }
        private void LoadContextMenuStrip()
        {
            contextMenuStrip = new ContextMenuStrip();
            var toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            var toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();

            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem1,toolStripMenuItem2});
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            toolStripMenuItem1.Text = "关闭当前界面";

            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            toolStripMenuItem2.Text = "关闭所有界面";

            fullTabControl1.ContextMenuStrip = contextMenuStrip;
            toolStripMenuItem1.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show($"关闭当前界面【{fullTabControl1.SelectedTab.Text}】");
                fullTabControl1.TabPages.Remove(fullTabControl1.SelectedTab);
            };
            toolStripMenuItem2.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show("关闭所有界面");
                fullTabControl1.TabPages.Clear();
            };
        }
        private void LoadPng()
        {
            string imagedirPath = @"E:\2024\WodeWinForm\WodeWinForm\Lib\1";
            if (Directory.Exists(imagedirPath))
            {
                string[] stringsPath = Directory.GetFiles(imagedirPath, "*.png");
                if (stringsPath.Length > 0)
                {
                    imageList = new ImageList();
                    string[] fileType = { ".jpg", ".png",".ico" };

                    var list = stringsPath.ToList().OrderBy(x => x);
                    foreach (string s in list)
                    {
                        if (fileType.Contains(Path.GetExtension(s)))
                        {
                            Image image = Image.FromFile(s);
                            string keyName = Path.GetFileNameWithoutExtension(s);
                            imageList.Images.Add(keyName, image);
                        }
                    }
                    imageList.ImageSize = new Size(16, 16);
                    imageList.TransparentColor = Color.Transparent;
                    //使用imageList
                    //label1.ImageList = imageList1;
                    //label1.ImageKey = "1";
                    //button1.ImageList = imageList1;
                    //button1.ImageIndex = 2;

                    treeView1.ImageList = imageList;
                    fullTabControl1.ImageList = imageList;
                }
               
            }
            
        }
        private void ToolStripMenuItem1_Click()
        {
            Form1 mzhj = new Form1(); //mzhj为窗体Form
            mzhj.MdiParent = this;
            TabPage tb = new TabPage();
            tb.Controls.Add(mzhj); //将窗体添加到form中
            tb.Text = mzhj.Text + " "; //设定tabpage标签
            tb.Name = mzhj.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
            this.fullTabControl1.TabPages.Add(tb);
            mzhj.FormBorderStyle = FormBorderStyle.None; //去除原form自带的边框
            mzhj.Dock = DockStyle.Fill; //填充整个tabpage
            mzhj.Show();
            fullTabControl1.SelectedTab = fullTabControl1.TabPages[fullTabControl1.TabPages.Count - 1];
        }
        
        private void ParentForm_Resize(object sender, EventArgs e)
        {
            panel1.Height = panel1.Parent.Height;
        }
        private bool startMove = false; //用于标记是否在移动中
        void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startMove)
            {
                panel1.Left += e.X;
                //panel1.BackColor = Color.Lime;
            }
            else
            {
                //panel1.BackColor = Color.Red;
                // panel1.BackColor = Color.Blue;
            }
             panel1.BackColor = Color.Blue;
        }
        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startMove)
            {
                panel1.Left += e.X;
                startMove = false;
                //this.treeView1.Width = panel1.Left;
                this.tableLayoutPanel1.Width = panel1.Left;
                panel1.BackColor = Color.Blue;
            }
            else
            {
                panel1.BackColor = Color.LightGray;
            }
            //txtSearchMenu.Text = panel1.Left.ToString();
            SaveConfig();
        }
        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startMove = true;
            panel1.BackColor = Color.Blue;
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            //LoadMenuNodes();
            frmTree_Load();
        }
        private void LoadMenuNodes() //实现情况应该是从数据库及用户权限来进行动态创建菜单项
        {
            this.treeView1.Nodes.Clear();
            var root = this.treeView1.Nodes.Add("Root");
            for (int i = 1; i <= 10; i++)
            {
                var section = root.Nodes.Add("Section-" + i);
                int maxNodes = new Random(i).Next(1, 10);
                for (int n = 1; n <= maxNodes; n++)
                {
                    section.Nodes.Add(string.Format("Level-{0}-{1}", i, n));
                }
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            if (e.Node.Nodes.Count <= 0)//当非父节点（即：实际的功能节点）
            {
                //ShowChildForm<Form1>();
                string strID = e.Node.Tag.ToString();
                //MessageBox.Show(" strID = " + strID);
                addTabPage(strID);
            }
        }

        private void addTabPage(string strID)
        {

            //1.Activator.CreateInstance(Type)
            //2.Activator.CreateInstance(Type, Object[])

            //Form2 mzhj = new Form2(); //mzhj为窗体Form   
            var find = MenuDataTable.Select($"ID = '{strID}'" );
            if (find == null || find.Length == 0) return;

            //CreateInstance(string assemblyName, string typeName);
            //ObjectHandle t = Activator.CreateInstance("WindowsFormsApplication2", "WindowsFormsApplication2.View.Form2");
            ObjectHandle t = Activator.CreateInstance(find[0]["assemblyName"].ToString(), find[0]["typeName"].ToString());
            Form mzhj = (Form)t.Unwrap();
            //f.ShowDialog();
            //if (ShowChildForm(mzhj.Text))
            if (ShowChildForm(find[0]["Name"].ToString()))
            {
                //MessageBox.Show(mzhj.Text + " - 已打开");
                return;
            }
            mzhj.AutoScroll = true;
            mzhj.MdiParent = this;
            TabPage tb = new TabPage();
            //tb.ImageIndex = new Random().Next(0, imageList.Images.Count - 1);
            //tb.BackColor = GlobalConfig.BackColor;
            //tb.BackColor = Color.FromArgb(0, 255, 255, 255);
            tb.Padding = new Padding { All = 2 };
            //tb.BackColor = GlobalConfig.BackColor;
            tb.Controls.Add(mzhj); //将窗体添加到form中
            //tb.Text = mzhj.Text ; //设定tabpage标签
            tb.Text = find[0]["Name"].ToString();
            tb.Name = mzhj.Name; //设定tabpage的name属性，为了之后的新增和销毁处理
            this.fullTabControl1.TabPages.Add(tb);
            mzhj.FormBorderStyle = FormBorderStyle.None; //去除原form自带的边框
            mzhj.Dock = DockStyle.Fill; //填充整个tabpage
            mzhj.Show();
            fullTabControl1.SelectedTab = fullTabControl1.TabPages[fullTabControl1.TabPages.Count - 1];
        }
        private bool ShowChildForm(string sonText)
        {

            foreach (TabPage mdic in fullTabControl1.TabPages)
            {
                if (mdic.Text == sonText)
                {
                    //mdic.ForeColor = Color.Blue;
                    fullTabControl1.SelectedTab = mdic;
                    return true;
                }
            }
            
            return false;
        }
        private bool ShowChildForm2(string sonText)
        {
            TabPage find = null;
            foreach (TabPage mdic in fullTabControl1.TabPages)
            {
                if (mdic.Text == sonText)
                {
                    find = mdic;
                    mdic.ForeColor = Color.Blue;
                }
                else
                {
                    mdic.ForeColor = Color.Black;
                }
            }
            if (find == null) return false;
            fullTabControl1.SelectedTab = find;
            fullTabControl1.SelectedTab.ForeColor = Color.Blue;
            return true;
        }
        ///通过反射创建子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Type t = Assembly.Load("TestForm").GetType("TestForm.Form4");
            Form fc = (Activator.CreateInstance(t) as Form);
            if (!ShowChildForm(fc.Text, this))//通过name判断会更好一些 毕竟name不会重名
            {
                fc.MdiParent = this;
                fc.Show();
            }
            else
            {
                fc.Dispose();
            }
        }
        private  bool ShowChildForm(string sonText, Form MdiParentForm)
        {

            foreach (var mdic in MdiParentForm.MdiChildren)
                if (mdic.Text == sonText)
                {
                    mdic.BringToFront();
                    return true;
                }

            return false;
        }
        private void ShowChildForm<TForm>() where TForm : Form, new()
        {

           
                Form childForm = new TForm();
            childForm.MdiParent = this;
            childForm.Name = "ChildForm - " + DateTime.Now.Millisecond.ToString();
            childForm.Text = childForm.Name;
            childForm.Show();

           // var frm = e.Control as Form;
            string menuName = "menu_" + childForm.Name;
            bool exists = panel1.Controls.Contains(childForm);
            if (exists)
            {
                MessageBox.Show(menuName);
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.LightGray;
            
        }

        void MenuClicked(object sender, EventArgs e)
        {
            //以下主要是动态生成事件并打开窗体
            //((sender as ToolStripMenuItem).Tag)强制转换
            ObjectHandle t = Activator.CreateInstance("WinForms", "WinForms.Form2");
            Form f = (Form)t.Unwrap();
            f.ShowDialog();
        }

        private DataTable SetErrorSData()
        {
            //(string assemblyName, string typeName);
            DataTable ErrorData = new DataTable("ErrorData");

            ErrorData.Columns.Add("ID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("ParentID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("Name", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("assemblyName", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("typeName", System.Type.GetType("System.String"));

            ErrorData.Rows.Add("1", "0", "学生管理");
            ErrorData.Rows.Add("2", "0", "教师管理", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form2");
            ErrorData.Rows.Add("3", "1", "学生信息录入");
            ErrorData.Rows.Add("4", "2", "教师信息录入", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form3");
            return ErrorData;
        }
       
        /// <summary>
        /// 创建树形菜单
        /// </summary>
        public void AddTree(int ParentID, TreeNode pNode,DataTable NewTable = null)
        {
            // 数据库名字字段
            string strName = "Name";
            // 数据库ID字段
            string strID = "ID";
            // 数据库父级ID字段
            string strParentID = "ParentID";
            //DataTable dt = SetErrorSData();
            //DataView dvTree = new DataView(dt);
            DataView dvTree = new DataView(MenuDataTable);
            if(NewTable != null)
            {
                dvTree = new DataView(NewTable);
            }
            dvTree.RowFilter = strParentID + " = " + ParentID;
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    Node.Text = Row[strName].ToString();
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    this.treeView1.Nodes.Add(Node);
                    AddTree(Int32.Parse(Row[strID].ToString()), Node, NewTable); //再次递归
                }
                else
                {
                    Node.Text = Row[strName].ToString() + "\t" ;
                    Node.Name = Row[strName].ToString();
                    Node.Tag = Row[strID].ToString();
                    Node.ImageIndex = 1;
                    pNode.Nodes.Add(Node);
                    AddTree(Int32.Parse(Row[strID].ToString()), Node, NewTable); //再次递归
                }
            }
        }

        /// <summary>
        /// 主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTree_Load(DataTable NewTable = null)
        {
            // 根节点ID值
            int i = 0;
            this.treeView1.Nodes.Clear();
            AddTree(i, (TreeNode)null, NewTable);
            treeView1.HideSelection = true;
            treeView1.ShowLines = true;
        }


        //第二部分功能-文件夹图标变换：

        private void treeView1_NodeMouseDoubleClick2(object sender, TreeNodeMouseClickEventArgs e)
        {
            ImageChange(e);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ImageChange(e);
        }
        /// <summary>
        /// 变换文件夹图标 httpss://www.jb51.net/article/34541.htm
        /// </summary>
        /// <param name="e"></param>
        public void ImageChange(TreeNodeMouseClickEventArgs e)
        {
            if (null == e.Node.FirstNode)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
            else
            {
                if (e.Node.IsExpanded)
                {
                    e.Node.ImageIndex = 0;
                    e.Node.SelectedImageIndex = 0;
                }
                else
                {
                    e.Node.ImageIndex = 1;
                    e.Node.SelectedImageIndex = 1;
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearchMenu.Text.Trim();
            if(key == "")
            {
                frmTree_Load();
                treeView1.ExpandAll();
                return;
            }
            var find = MenuDataTable.Select($" Name like '%{key}%'");
            if(find == null || find.Length == 0)
            {
                treeView1.Nodes.Clear();
                return;
            }
            string str = "";
            var NewTable = find.CopyToDataTable();
            foreach(DataRow w in NewTable.Rows)
            {
                str +=  w["ID"].ToString() + "," + w["ParentID"].ToString() + ",";
            }
            str += "0";

            find = MenuDataTable.Select($" ID in ({str}) ");

            NewTable = find.CopyToDataTable();

            frmTree_Load(NewTable);
            treeView1.ExpandAll();
            

        }

       
        int tableLayoutPanel1Width = 0;
         
        private void showHideMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.Visible)
            {
                tableLayoutPanel1Width = tableLayoutPanel1.Width;
                tableLayoutPanel1.Visible = false;
                panel1.Visible = false;
                showHideMenuToolStripMenuItem.Text = "ShowMenu";
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                panel1.Visible = true;
                tableLayoutPanel1.Width = tableLayoutPanel1Width;
                showHideMenuToolStripMenuItem.Text = "HideMenu";
            }
            
        }
        private void SaveConfig(bool Onload = false)
        {
            if (File.Exists("config.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("config.xml");

                // 获取根节点
                XmlNode root = xmlDoc.SelectSingleNode("/Root");

                string panel1Left = "";
               
                if (Onload)
                {
                    // 遍历子节点
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Name == "panel1Left")
                        {
                            panel1Left = node.InnerText;
                        }
                    }
                    tableLayoutPanel1.Width = int.Parse(panel1Left);
                    panel1.Left = int.Parse(panel1Left);
                }
                else
                {
                    // 遍历子节点
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        Console.WriteLine(node.Name + ": " + node.InnerText);
                        if (node.Name == "panel1Left")
                        {
                            node.InnerText = panel1.Left.ToString();
                        }
                    }
                    xmlDoc.Save("config.xml");
                }
               
            }
            else
            {
                // 创建 XmlDocument 对象
                XmlDocument xmlDoc = new XmlDocument();

                // 添加根节点
                XmlElement root = xmlDoc.CreateElement("Root");
                xmlDoc.AppendChild(root);

                // 添加子节点及其内容
                XmlElement child = xmlDoc.CreateElement("panel1Left");
                child.InnerText = panel1.Left.ToString();
                root.AppendChild(child);

                // 保存到文件
                xmlDoc.Save("config.xml");
            }
           
        }

        private void fullTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}