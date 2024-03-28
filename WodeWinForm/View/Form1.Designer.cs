
namespace WodeWinForm.View
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 =  new MyControls.BaseTreeView();//new System.Windows.Forms.TreeView();
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.txt_CheckValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(32, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(515, 394);
            this.treeView1.TabIndex = 0;
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.Location = new System.Drawing.Point(573, 22);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadData.TabIndex = 1;
            this.btn_LoadData.Text = "button1";
            this.btn_LoadData.UseVisualStyleBackColor = true;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // txt_CheckValue
            // 
            this.txt_CheckValue.Location = new System.Drawing.Point(32, 431);
            this.txt_CheckValue.Multiline = true;
            this.txt_CheckValue.Name = "txt_CheckValue";
            this.txt_CheckValue.Size = new System.Drawing.Size(706, 105);
            this.txt_CheckValue.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.txt_CheckValue);
            this.Controls.Add(this.btn_LoadData);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.TreeView treeView1;
        private MyControls.BaseTreeView treeView1;
        
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.TextBox txt_CheckValue;
    }
}