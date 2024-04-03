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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            //设置dataWindow1属性
            this.dataWindow1.PopupGridAutoSize = false;
            this.dataWindow1.DropDownHeight = 300;
            this.dataWindow1.DropDownWidth = 600;
            this.dataWindow1.DataSource = GetDataTable();//DataTable 类型
            this.dataWindow1.RowFilterVisible = true;
            this.dataWindow1.PopupGridAutoSize = true;
            this.dataWindow1.sKeyWords = "Name";
            this.dataWindow1.sValueMember = "typeName";

            //this.dataWindow1.sDisplayField = "assemblyName";
            this.dataWindow1.sDisplayMember = "typeName";
            //this.dataWindow1.Value = "assemblyName";

            this.dataWindow1.AfterSelector += new EventHandler(dataWindow1_AfterSelector);
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

            return ErrorData;

        }
        //选择完下拉表格后执行的事件
        private void dataWindow1_AfterSelector(object sender, EventArgs e)
        {
            textBox1.Text = dataWindow1.GetDataProperty("Name");
            //textBox2.Text = dataWindow1.GetDataProperty("department");
            //textBox3.Text = dataWindow1.GetDataProperty("postion");
        }
    }
}
