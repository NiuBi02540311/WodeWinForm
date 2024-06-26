﻿using System;
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
    public partial class Form4 : Form
    {
        DataTable dt = new DataTable();
        public Form4()
        {
            InitializeComponent();

            //设置dataWindow1属性
            //this.dataWindow1.PopupGridAutoSize = true;
            //this.dataWindow1.DropDownHeight = 100;
            //this.dataWindow1.DropDownWidth = 600;
            this.dataWindow1.DataSource = GetDataTable();//DataTable 类型
            this.dataWindow1.RowFilterVisible = true;
            //this.dataWindow1.PopupGridAutoSize = true;
            this.dataWindow1.sKeyWords = "Name";
            this.dataWindow1.sValueMember = "typeName";

            //this.dataWindow1.sDisplayField = "assemblyName";
            this.dataWindow1.sDisplayMember = "typeName";
            //this.dataWindow1.Value = "assemblyName";

            this.dataWindow1.AfterSelector += new EventHandler(dataWindow1_AfterSelector);


            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(string));
            dt.Columns.Add("Column3", typeof(string));

            for (int i = 0; i < 100; i++)
            {
                dt.Rows.Add("A" + i.ToString("D2"), "B" + (i + 1).ToString("D2"), "C" + (i + 2).ToString("D2"));
            }

            uiComboDataGridView1.DataGridView.Init();
            uiComboDataGridView1.ItemSize = new System.Drawing.Size(360, 240);
            uiComboDataGridView1.DataGridView.AddColumn("Column1", "Column1");
            uiComboDataGridView1.DataGridView.AddColumn("Column2", "Column2");
            uiComboDataGridView1.DataGridView.AddColumn("Column3", "Column3");
            uiComboDataGridView1.DataGridView.ReadOnly = true;
            uiComboDataGridView1.SelectIndexChange += UiComboDataGridView1_SelectIndexChange;
            uiComboDataGridView1.ShowFilter = true;
            uiComboDataGridView1.DataGridView.DataSource = dt;
            uiComboDataGridView1.FilterColumnName = "Column1"; //不设置则全部列过滤
            this.uiComboDataGridView1.SelectIndexChange += new Sunny.UI.UIDataGridView.OnSelectIndexChange(this.uiComboDataGridView1_SelectIndexChange_1);
            this.uiComboDataGridView1.ValueChanged += new Sunny.UI.UIComboDataGridView.OnValueChanged(this.uiComboDataGridView1_ValueChanged);

            loadlistView();

            comCheckBoxList1.AddItems("1....");
            comCheckBoxList1.AddItems("2....");
            comCheckBoxList1.AddItems("3....");
        }
        private void UiComboDataGridView1_SelectIndexChange(object sender, int index)
        {
            uiComboDataGridView1.Text = dt.Rows[index]["Column1"].ToString();
        }
        private void uiComboDataGridView1_ValueChanged(object sender, object value)
        {
            uiComboDataGridView1.Text = "";
            if (value != null && value is DataGridViewRow)
            {
                DataGridViewRow row = (DataGridViewRow)value;
                uiComboDataGridView1.Text = row.Cells["Column1"].Value.ToString();
            }
        }

        private void uiComboDataGridView1_SelectIndexChange_1(object sender, int index)
        {
            uiComboDataGridView1.Text = dt.Rows[index]["Column1"].ToString();
        }
        private void loadlistView()
        {
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            ListViewItem viewItem = new ListViewItem();
            viewItem.Text = "a";//第一列
            viewItem.Name = "a1";
            viewItem.ImageIndex = 3;
            viewItem.SubItems.Add("b");
            viewItem.SubItems.Add("c");

            ListViewItem viewItem2 = new ListViewItem();
            viewItem2.ImageIndex = 2;
            viewItem2.Text = "d";//第一列
            viewItem2.SubItems.Add("e");
            viewItem2.SubItems.Add("f");

            //listView1.Items.Add(viewItem);
            //listView1.Items.Add(viewItem2);
            listView1.SmallImageList = GlobalConfig.imageList;

            listView1.Items.Add(new ListViewItem(new string[] { "tetrse", "rerwerrr", "sddddd" }, 3));
            listView1.Items.Add(new ListViewItem(new string[] { "11", "22", "33" }, 2));
            listView1.Items.Add(new ListViewItem(new string[] { "aa", "bb", "cc" }, 4));

            listView1.FullRowSelect = true;
            //listView1.Items.Remove(viewItem2);
            //listView1.Items.RemoveAt(1);
            //listView1.Items.RemoveByKey("a1");
            textBox2.TextChanged += new EventHandler(searchBox_TextChanged);
            listView1.MouseDoubleClick += listView1Doubleclick;
            // Set the View to list to use the FindItemWithText method.
            //listView1.View = System.Windows.Forms.View.List;  //View.List;

            // Populate the ListViewWithItems
            //listView1.Items.AddRange(new ListViewItem[]{
            //new ListViewItem("Amy Alberts"),
            //new ListViewItem("Amy Recker"),
            //new ListViewItem("Erin Hagens"),
            //new ListViewItem("Barry Johnson"),
            //new ListViewItem("Jay Hamlin"),
            //new ListViewItem("Brian Valentine"),
            //new ListViewItem("Brian Welker"),
            //new ListViewItem("Daniel Weisman") });
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            // Call FindItemWithText with the contents of the textbox.
            //ListViewItem foundItem =  listView1.FindItemWithText(textBox2.Text, false, 0, true);
            ListViewItem foundItem = textBox2.Text == "" ? null: listView1.FindItemWithText(textBox2.Text, true, 0, true);
            //ListViewItem foundItem =  listView1.FindItemWithText(this.textBox2.Text, true, 0);
            if (foundItem != null)
            {
                listView1.TopItem = foundItem;
                //foundItem.ForeColor = Color.Red;
            }
            // if(textBox2.Text.Trim() == "")
            //{
            //    foundItem = null;
            //}
            foreach(ListViewItem item in listView1.Items)
            {
                item.ForeColor = item == foundItem ? Color.Red : Color.Black;
                item.BackColor = item == foundItem ? GlobalConfig.BackColor2 : Color.White;
            }
            //ListViewItem foundItem = this.listView1.FindItemWithText(this.textBox1.Text, true, 0);    //参数1：要查找的文本；参数2：是否子项也要查找；参数3：开始查找位置

            //if (foundItem != null)
            //{

            //    this.listView1.TopItem = foundItem;  //定位到该项

            //    foundItem.ForeColor = Color.Red;
            //}

        }
        private void listView1Doubleclick(object sender, EventArgs e) {

            var checks = listView1.CheckedItems;
            int qty = checks == null ? 0 : checks.Count;
            MessageBox.Show(qty.ToString());
            ListViewItem item = this.listView1.SelectedItems[0];//当前选中行
            if(item==null)
            return;
            string s = item.Text + "="+  item.SubItems[0].Text + "=" + item.SubItems[1].Text;
            MessageBox.Show(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataWindow1.Text);
            MessageBox.Show(dataWindow1.Value);
            //MessageBox.Show(dataWindow1.ValueMember);
        }
        private DataTable GetDataTable()
        {


            DataTable ErrorData = new DataTable("ErrorData");

            ErrorData.Columns.Add("ID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("ParentID", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("Name", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("assemblyName", System.Type.GetType("System.String"));
            ErrorData.Columns.Add("typeName", System.Type.GetType("System.String"));

            ErrorData.Rows.Add("1", "0", "学生管理");
            ErrorData.Rows.Add("2", "0", "教师管理");
            ErrorData.Rows.Add("3", "1", "学生信息录入", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form2");
            ErrorData.Rows.Add("4", "2", "教师信息录入", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form3");
            ErrorData.Rows.Add("5", "0", "View");
            ErrorData.Rows.Add("6", "5", "Form6", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form6");
            ErrorData.Rows.Add("7", "5", "Form7", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form7");
            ErrorData.Rows.Add("8", "5", "Form8", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form8");
            ErrorData.Rows.Add("9", "5", "Form9", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form9");
            ErrorData.Rows.Add("10", "5", "Form10", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form10");
            for(int i = 11; i < 50; i++)
            {
                ErrorData.Rows.Add(i, "5", "Form10", "WindowsFormsApplication2", "WindowsFormsApplication2.View.Form10");
            }
            return ErrorData;

        }
        //选择完下拉表格后执行的事件
        private void dataWindow1_AfterSelector(object sender, EventArgs e)
        {
            textBox1.Text = dataWindow1.GetDataProperty("Name");
            //textBox2.Text = dataWindow1.GetDataProperty("department");
            //textBox3.Text = dataWindow1.GetDataProperty("postion");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comCheckBoxList1_ItemClick(object sender, ItemCheckEventArgs e)
        {
            //httpss://www.cnblogs.com/yangsirc/p/8080510.html
            string text = comCheckBoxList1.GetItemText(comCheckBoxList1.Items[e.Index]);

            
            //if (jobs_result.Contains(text))
            //    jobs_result.Remove(text);
            //else
            //    jobs_result.Add(text);

            MessageBox.Show(text);
        }
    }
}
