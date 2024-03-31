
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
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.treeView1 = new System.Windows.Forms.TreeView();

            this.SuspendLayout();
            // 
            // btn_LoadData
            // 
            this.btn_LoadData.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_LoadData.Location = new System.Drawing.Point(477, 12);
            this.btn_LoadData.Name = "btn_LoadData";
            this.btn_LoadData.Size = new System.Drawing.Size(144, 96);
            this.btn_LoadData.TabIndex = 1;
            this.btn_LoadData.Text = "button1";
            this.btn_LoadData.UseVisualStyleBackColor = false;
            this.btn_LoadData.Click += new System.EventHandler(this.btn_LoadData_Click);
            // 
            // txt_CheckValue
            // 
            this.txt_CheckValue.Location = new System.Drawing.Point(32, 475);
            this.txt_CheckValue.Multiline = true;
            this.txt_CheckValue.Name = "txt_CheckValue";
            this.txt_CheckValue.Size = new System.Drawing.Size(706, 75);
            this.txt_CheckValue.TabIndex = 2;
            // 
            // buttonEx1
            // 
            this.buttonEx1.BackgroundImage = global::WodeWinForm.Properties.Resources.Graphicloads_Colorful_Long_Shadow_Zoom_16;
            this.buttonEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Location = new System.Drawing.Point(493, 134);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Size = new System.Drawing.Size(128, 128);
            this.buttonEx1.TabIndex = 3;
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(477, 226);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(202, 35);
            this.uiSymbolButton1.TabIndex = 4;
            this.uiSymbolButton1.Text = "uiSymbolButton1";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(42, 11);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(415, 450);
            this.treeView1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.buttonEx1);
            this.Controls.Add(this.txt_CheckValue);
            this.Controls.Add(this.btn_LoadData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private MyControls.BaseTreeView treeView1;
        
        private System.Windows.Forms.Button btn_LoadData;
        private System.Windows.Forms.TextBox txt_CheckValue;
        private MyControls.ButtonEx buttonEx1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private System.Windows.Forms.TreeView treeView1;

    }
}