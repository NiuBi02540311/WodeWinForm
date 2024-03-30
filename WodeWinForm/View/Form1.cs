using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm.View
{
    //public partial class Form1 : UIPage
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.AfterCheck += treeView1_AfterCheck;

            //var BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            //this.BackColor = BackColor;

        }


        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            //设置树形组件的基础属性
            treeView1.CheckBoxes = true;
            treeView1.FullRowSelect = true;
            treeView1.Indent = 20;
            treeView1.ItemHeight = 20;
            treeView1.LabelEdit = false;
            treeView1.Scrollable = true;
            treeView1.ShowPlusMinus = true;
            treeView1.ShowRootLines = true;


            //需要加载树形的源数据
            string[] strData = { "1;内地;柳岩",
                                 "2;内地;杨幂",
                                 "3;欧美;卡戴珊",
                                 "4;日韩;李成敏",
                                 "5;日韩;宇都宫紫苑"};

            //解析到DataTable数据集
            DataTable dtData = new DataTable();
            dtData.Columns.Add("ID");
            dtData.Columns.Add("GROUP");
            dtData.Columns.Add("NAME");

            foreach (string item in strData)
            {
                string[] values = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 3)
                {
                    DataRow row = dtData.NewRow();
                    row["ID"] = values[0];
                    row["GROUP"] = values[1];
                    row["NAME"] = values[2];
                    dtData.Rows.Add(row);
                }
            }


            TreeNode tn = new TreeNode();
            tn.Name = "全部";
            tn.Text = "全部";


            //将数据集加载到树形控件当中
            foreach (DataRow row in dtData.Rows)
            {
                string strValue = row["GROUP"].ToString();
                if (tn.Nodes.Count > 0)
                {
                    if (!tn.Nodes.ContainsKey(strValue))
                    {
                        BindTreeData(tn, dtData, strValue);
                    }
                }
                else
                {
                    BindTreeData(tn, dtData, strValue);
                }
            }

            treeView1.Nodes.Add(tn);
            treeView1.ExpandAll();
        }

        private void BindTreeData(TreeNode tn, DataTable dtData, string strValue)
        {
            TreeNode tn1 = new TreeNode();
            tn1.Name = strValue;
            tn1.Text = strValue;
            tn.Nodes.Add(tn1);

            DataRow[] rows = dtData.Select(string.Format("GROUP='{0}'", strValue));
            if (rows.Length > 0)
            {
                foreach (DataRow dr in rows)
                {
                    TreeNode tn2 = new TreeNode();
                    tn2.Name = dr["GROUP"].ToString();
                    tn2.Text = dr["NAME"].ToString();
                    tn1.Nodes.Add(tn2);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //鼠标勾选树节点时需要使树节点为选中状态，反之忽略
            if (isMouseClick)
            {
                treeView1.SelectedNode = e.Node;
            }

            //获取勾选项名称
            StringBuilder sb = new StringBuilder();
            GetTreeNodesCheckName(sb, treeView1.Nodes);
            txt_CheckValue.Text = sb.ToString().Trim(';');
        }

        private void GetTreeNodesCheckName(StringBuilder sb, TreeNodeCollection tnc)
        {
            foreach (TreeNode item in tnc)
            {
                if (item.Checked) { sb.AppendFormat("{0};", item.Text); }

                GetTreeNodesCheckName(sb, item.Nodes);
            }
        }

        bool isMouseClick = true;
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //选中或勾选树节点时触发子树节点或父树节点的逻辑操作
            isMouseClick = false;

            SetCheckedChildNodes(e.Node, e.Node.Checked);

            SetCheckedParentNodes(e.Node, e.Node.Checked);

            isMouseClick = true;
        }

        //树节点的父树节点逻辑操作
        private static void SetCheckedParentNodes(TreeNode tn, bool CheckState)
        {
            if (tn.Parent != null)
            {
                //当选中树节点勾选后同级所有树节点都勾选时，父树节点为勾选状态；
                //当选中树节点中的同级树节点其中有一个树节点未勾选则父树节点为未勾选状态；
                bool b = false;
                for (int i = 0; i < tn.Parent.Nodes.Count; i++)
                {
                    bool state = tn.Parent.Nodes[i].Checked;
                    if (!state.Equals(CheckState))
                    {
                        b = !b;
                        break;
                    }
                }
                tn.Parent.Checked = b ? (Boolean)false : CheckState;

                SetCheckedParentNodes(tn.Parent, CheckState);
            }
        }

        //树节点的子树节点逻辑操作
        private static void SetCheckedChildNodes(TreeNode tn, bool CheckState)
        {
            if (tn.Nodes.Count > 0)
            {
                //当前树节点状态变更，子树节点同步状态
                foreach (TreeNode tn1 in tn.Nodes)
                {
                    tn1.Checked = CheckState;

                    SetCheckedChildNodes(tn1, CheckState);
                }
            }
        }

        private void uiWaitingBar1_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            //ShowSuccessTip("轻便消息提示框 - 成功");
        }
    }
}
