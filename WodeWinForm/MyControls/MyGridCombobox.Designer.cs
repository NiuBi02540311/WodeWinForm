
namespace WodeWinForm.MyControls
{
      partial class MyGridCombobox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFind = new System.Windows.Forms.TextBox();
            this.dgvDataGird = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGird)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFind.Location = new System.Drawing.Point(0, 0);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(403, 21);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // dgvDataGird
            // 
            this.dgvDataGird.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvDataGird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataGird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataGird.Location = new System.Drawing.Point(0, 21);
            this.dgvDataGird.Name = "dgvDataGird";
            this.dgvDataGird.RowTemplate.Height = 23;
            this.dgvDataGird.Size = new System.Drawing.Size(403, 250);
            this.dgvDataGird.TabIndex = 1;
            this.dgvDataGird.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDataGird_KeyDown);
            // 
            // MyGridCombobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDataGird);
            this.Controls.Add(this.txtFind);
            this.Name = "MyGridCombobox";
            this.Size = new System.Drawing.Size(403, 271);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.DataGridView dgvDataGird;
    }
}
