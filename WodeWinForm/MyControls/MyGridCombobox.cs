using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm.MyControls
{
    public partial class MyGridCombobox : UserControl
    {
        //httpss://wwww.cnblogs.com/springSky/archive/2013/02/19/2913993.html

        private DataTable _dataList = new DataTable();
        private TextBox _txtBox;
        private string _findColumnName;
        private string _keyColumnName;
        private Dictionary<string, string> _dicColumnName;
        public MyGridCombobox(TextBox txtBox, DataTable dataList, string findColumnName, string keyColumnName
          , int Width = 0, int Height = 0, Dictionary<string, string> dicColumnName = null)
        {
            InitializeComponent();
            this.dgvDataGird.AllowUserToAddRows = false;
            this.dgvDataGird.ReadOnly = true;
            //this.dgvDataGird.RowStateChanged += dataGridViewRowStateChanged;

            #region 表格居左
            dgvDataGird.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            #endregion

            #region 表格行号
            //dgvDataGird.RowPostPaint += DataGridView_RowPostPaint;

            //dgvDataGird.RowPostPaint += DataGridView_RowPostPaint;

            dgvDataGird.RowPostPaint += dgGrid_RowPostPaint;

            //dgvDataGird.RowHeadersVisible = true;
            //dgvDataGird.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //千位数的序号需要加上_Add*2；
            //具体做法是将DataGridView的RowsHeaderWidthSizeMode属性 设置为AutoSizeToAllHeaders或者AutoSizeToDisplayedHeaders，这样自动设置宽度就不会出现行指示符挤压行号的情况了
            //dgvDataGird.RowHeadersWidth = Properties.Settings.Default.RowHeadersWidth_Start + Properties.Settings.Default.RowHeadersWidth_Add * 2;


            //dgvDataGird.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            //dgvDataGird.RowsAdded += dgvinfo_RowsAdded;
            //dgvDataGird.RowsRemoved += dgvinfo_RowsRemoved;
            #endregion

            this.Width = Width > 0 ? Width : this.Width;
            this.Height = Height > 0 ? Height : this.Height;
            this._dicColumnName = dicColumnName;
            this._txtBox = txtBox;
            this._dataList = dataList;
            this._findColumnName = findColumnName;
            this._keyColumnName = keyColumnName;
            this.Load += ListControl_Load;
            this.txtFind.TextChanged += new EventHandler(txtKeys_TextChanged);
            //this.dgvDataGird.CellClick += dgvStudentList_Click;
            this.dgvDataGird.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataGird_CellDoubleClick);

            //  this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);


        }
        private void dgGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //在dataGridView1的RowPostPaint事件中，选择dataGridView1_RowPostPaint函数
            DataGridView dataGridView1 = sender as DataGridView;

            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dataGridView1.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridView1.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //注册事件 this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                //var cen = new StringFormat()
                //{
                //    Alignment = StringAlignment.Center,
                //    LineAlignment = StringAlignment.Center

                //};
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                //using (Brush brush = new SolidBrush(e.CellStyle.ForeColor))
                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.CellStyle.Font, brush, e.CellBounds.Location.X + 14, e.CellBounds.Location.Y + 8);
                }
                e.Handled = true;
            }
        }
        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView datagridview = sender as DataGridView;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            datagridview.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
              datagridview.RowHeadersDefaultCellStyle.Font,
              rectangle,
              datagridview.RowHeadersDefaultCellStyle.ForeColor,
              TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvInfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void ListControl_Load(object sender, EventArgs e)
        {
            dgvDataGird.DataSource = _dataList;
            SetColumnName();
        }
        /// <summary>

        private void txtKeys_TextChanged(object sender, EventArgs e)
        {
            var findtxt = txtFind.Text;
            if (string.IsNullOrEmpty(findtxt) || string.IsNullOrWhiteSpace(findtxt))
            {
                dgvDataGird.DataSource = _dataList;
                SetColumnName();
                return;
            }

            string sql = $"  {_findColumnName} like '%{findtxt}%' "; ;
            if (_findColumnName.Contains(","))
            {
                sql = "";
                string[] arr = _findColumnName.Split(',');
                foreach (string v in arr)
                {
                    sql += $" {v} like '%{txtFind.Text}%' or";
                }
                sql = sql.Substring(0, sql.Length - 2);
            }
            var newData = _dataList.Select(sql);
            dgvDataGird.DataSource = null;
            if (newData == null || newData.Length == 0)
            {
                return;
            }
            dgvDataGird.DataSource = newData.CopyToDataTable();
            SetColumnName();
            //var resultList = _dataList.FindAll(std => std.SName.Contains(txtKeys.Text) || std.SAddress.Contains(txtKeys.Text));
            //dgvStudentList.DataSource = resultList;

        }

        private void dgvStudentList_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;


            //_txtBox.Text = this.dgvDataGird.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            _txtBox.Text = this.dgvDataGird.Rows[e.RowIndex].Cells[_keyColumnName].Value.ToString();
            _txtBox.ReadOnly = true;
            _txtBox.BackColor = Color.White;
            this.Dispose();

        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode != Keys.Enter) return;
            //if(dgvDataGird.Rows.Count == 0 ) return;
            //_txtBox.Text = this.dgvDataGird.Rows[0].Cells[_keyColumnName].Value.ToString();
            //_txtBox.ReadOnly = true;
            //_txtBox.BackColor = Color.White;
            //this.Dispose();

            if (e.KeyCode != Keys.Enter) return;
            if (dgvDataGird.Rows.Count == 0) return;
            var CurrentCell = dgvDataGird.CurrentCell;
            int CurrentCellRowIndex = CurrentCell == null ? 0 : CurrentCell.RowIndex;
            _txtBox.Text = this.dgvDataGird.Rows[CurrentCellRowIndex].Cells[_keyColumnName].Value.ToString();

            _txtBox.ReadOnly = true;
            _txtBox.BackColor = Color.White;
            this.Dispose();
        }

        private void dgvDataGird_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            //_txtBox.Text = this.dgvDataGird.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            _txtBox.Text = this.dgvDataGird.Rows[e.RowIndex].Cells[_keyColumnName].Value.ToString();
            _txtBox.ReadOnly = true;
            _txtBox.BackColor = Color.White;
            this.Dispose();
        }

        private void SetColumnName()
        {
            if (_dicColumnName == null || _dicColumnName.Count == 0) return;
            if (dgvDataGird.Rows.Count == 0) return;

            foreach (var k in _dicColumnName)
            {
                if (dgvDataGird.Columns.Contains(k.Key))
                {
                    dgvDataGird.Columns[k.Key].HeaderText = k.Value;
                }

            }
        }

        private void dgvDataGird_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Enter) return;
            if (dgvDataGird.Rows.Count == 0) return;
            var CurrentCell = dgvDataGird.CurrentCell;
            int CurrentCellRowIndex = CurrentCell == null ? 0 : CurrentCell.RowIndex;
            _txtBox.Text = this.dgvDataGird.Rows[CurrentCellRowIndex].Cells[_keyColumnName].Value.ToString();

            _txtBox.ReadOnly = true;
            _txtBox.BackColor = Color.White;
            this.Dispose();
        }
    }
}
