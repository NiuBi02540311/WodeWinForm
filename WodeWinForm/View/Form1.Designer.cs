
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
            this.btn_LoadData = new System.Windows.Forms.Button();
            this.txt_CheckValue = new System.Windows.Forms.TextBox();
            this.buttonEx1 = new WodeWinForm.MyControls.ButtonEx();
            this.treeView1 = new WodeWinForm.MyControls.BaseTreeView();
            this.SuspendLayout();
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_LoadData.Location = new System.Drawing.Point(573, 22);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(144, 96);
            this.btn_LoadData.TabIndex = 1;
            this.btn_LoadData.Text = "button1";
            this.btn_LoadData.UseVisualStyleBackColor = false;
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
            // buttonEx1
            // 
            this.buttonEx1.BackgroundImage = global::WodeWinForm.Properties.Resources.Gartoon_Team_Gartoon_Action_Tool_tweak_128;
            this.buttonEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Location = new System.Drawing.Point(573, 135);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Size = new System.Drawing.Size(128, 128);
            this.buttonEx1.TabIndex = 3;
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.ItemHeight = 23;
            this.treeView1.Location = new System.Drawing.Point(32, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(515, 394);
            this.treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.buttonEx1);
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
        private MyControls.ButtonEx buttonEx1;
    }
}