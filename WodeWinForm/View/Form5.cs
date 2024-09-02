using PopupTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WodeWinForm.MyControls;

namespace WodeWinForm.View
{
    public partial class Form5 : Form
    {
        private DataTable _table;
        public Form5()
        {
            InitializeComponent();
            getdata();
        }
        private void getdata()
        {
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
            _table = dtData;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicColumnName = new Dictionary<string, string>();
            dicColumnName.Add("GROUP", "部门");
            dicColumnName.Add("NAME", "姓名");
            var txtSelectValue = textBox1;
            MyGridCombobox uc = new MyGridCombobox(txtSelectValue, _table, "GROUP,NAME", "NAME", 600, 0, dicColumnName);
            Popup pop = new Popup(uc);
            pop.Show(txtSelectValue, false);

        }
        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            Dictionary<string, string> dicColumnName = new Dictionary<string, string>();
            dicColumnName.Add("TEST4", "姓名");
            dicColumnName.Add("TEST5", "年龄");
            var txtSelectValue = textBox1;
            MyGridCombobox uc = new MyGridCombobox(txtSelectValue, _table, "GROUP,NAME", "NAME", 600, 0, dicColumnName);
            Popup pop = new Popup(uc);
            pop.Show(txtSelectValue, false);
        }
    }
}
