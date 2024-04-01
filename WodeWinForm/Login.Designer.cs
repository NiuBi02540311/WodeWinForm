
namespace WodeWinForm
{
    partial class Login
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
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTextBoxUserName = new Sunny.UI.UITextBox();
            this.uiTextBoxPassWord = new Sunny.UI.UITextBox();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.chk_rem = new System.Windows.Forms.CheckBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiTextBoxCode = new Sunny.UI.UITextBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiPanelLoginMsg = new Sunny.UI.UIPanel();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiPanel4.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.uiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton1.FillColor = System.Drawing.Color.Navy;
            this.uiButton1.FillHoverColor = System.Drawing.Color.Crimson;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(151, 3);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(142, 103);
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "Login";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton2.FillColor = System.Drawing.Color.Maroon;
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(299, 3);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(142, 103);
            this.uiButton2.TabIndex = 1;
            this.uiButton2.Text = "Cancel";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.uiLabel2.Location = new System.Drawing.Point(3, 50);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(173, 50);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "PassWord";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.Click += new System.EventHandler(this.uiLabel2_Click);
            // 
            // uiTextBoxUserName
            // 
            this.uiTextBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBoxUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxUserName.Location = new System.Drawing.Point(183, 5);
            this.uiTextBoxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxUserName.Name = "uiTextBoxUserName";
            this.uiTextBoxUserName.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxUserName.ShowText = false;
            this.uiTextBoxUserName.Size = new System.Drawing.Size(413, 40);
            this.uiTextBoxUserName.TabIndex = 1;
            this.uiTextBoxUserName.Text = "uiTextBox1";
            this.uiTextBoxUserName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxUserName.Watermark = "";
            this.uiTextBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiTextBoxUserName_KeyDown);
            // 
            // uiTextBoxPassWord
            // 
            this.uiTextBoxPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxPassWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBoxPassWord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxPassWord.Location = new System.Drawing.Point(183, 55);
            this.uiTextBoxPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxPassWord.Name = "uiTextBoxPassWord";
            this.uiTextBoxPassWord.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxPassWord.ShowText = false;
            this.uiTextBoxPassWord.Size = new System.Drawing.Size(413, 40);
            this.uiTextBoxPassWord.TabIndex = 2;
            this.uiTextBoxPassWord.Text = "uiTextBox2";
            this.uiTextBoxPassWord.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxPassWord.Watermark = "";
            this.uiTextBoxPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiTextBoxPassWord_KeyDown);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.97658F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.02342F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiTextBoxUserName, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTextBoxPassWord, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiPanel4, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel3, 1, 2);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 4;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(600, 269);
            this.uiTableLayoutPanel1.TabIndex = 6;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(173, 50);
            this.uiLabel1.TabIndex = 6;
            this.uiLabel1.Text = "UserName";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel4
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiPanel4, 2);
            this.uiPanel4.Controls.Add(this.uiTableLayoutPanel2);
            this.uiPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel4.Location = new System.Drawing.Point(4, 155);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.Size = new System.Drawing.Size(592, 109);
            this.uiPanel4.TabIndex = 7;
            this.uiPanel4.Text = "uiPanel4";
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 4;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Controls.Add(this.uiButton2, 2, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiButton1, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.chk_rem, 3, 0);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 1;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(592, 109);
            this.uiTableLayoutPanel2.TabIndex = 0;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // chk_rem
            // 
            this.chk_rem.AutoSize = true;
            this.chk_rem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chk_rem.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_rem.ForeColor = System.Drawing.Color.Indigo;
            this.chk_rem.Location = new System.Drawing.Point(447, 85);
            this.chk_rem.Name = "chk_rem";
            this.chk_rem.Size = new System.Drawing.Size(142, 21);
            this.chk_rem.TabIndex = 2;
            this.chk_rem.Text = "remember me";
            this.chk_rem.UseVisualStyleBackColor = true;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(3, 100);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(173, 50);
            this.uiLabel3.TabIndex = 8;
            this.uiLabel3.Text = "验证码";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 2;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.uiTableLayoutPanel3.Controls.Add(this.uiTextBoxCode, 1, 0);
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(182, 103);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 1;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(415, 44);
            this.uiTableLayoutPanel3.TabIndex = 3;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 38);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // uiTextBoxCode
            // 
            this.uiTextBoxCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBoxCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxCode.Location = new System.Drawing.Point(211, 5);
            this.uiTextBoxCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxCode.Name = "uiTextBoxCode";
            this.uiTextBoxCode.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxCode.ShowText = false;
            this.uiTextBoxCode.Size = new System.Drawing.Size(200, 34);
            this.uiTextBoxCode.TabIndex = 3;
            this.uiTextBoxCode.Text = "uiTextBox1";
            this.uiTextBoxCode.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxCode.Watermark = "";
            this.uiTextBoxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiTextBoxCode_KeyDown);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(600, 125);
            this.uiPanel1.TabIndex = 7;
            this.uiPanel1.Text = "图片展示区域";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelLoginMsg
            // 
            this.uiPanelLoginMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanelLoginMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelLoginMsg.Location = new System.Drawing.Point(0, 394);
            this.uiPanelLoginMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelLoginMsg.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelLoginMsg.Name = "uiPanelLoginMsg";
            this.uiPanelLoginMsg.Size = new System.Drawing.Size(600, 56);
            this.uiPanelLoginMsg.TabIndex = 8;
            this.uiPanelLoginMsg.Text = "登录消息展示区域";
            this.uiPanelLoginMsg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiTableLayoutPanel1);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel3.Location = new System.Drawing.Point(0, 125);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(600, 269);
            this.uiPanel3.TabIndex = 9;
            this.uiPanel3.Text = "uiPanel3";
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.uiPanel3);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiPanelLoginMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiPanel4.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.uiTableLayoutPanel2.PerformLayout();
            this.uiTableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox uiTextBoxUserName;
        private Sunny.UI.UITextBox uiTextBoxPassWord;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPanel uiPanelLoginMsg;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunny.UI.UITextBox uiTextBoxCode;
        private System.Windows.Forms.CheckBox chk_rem;
    }
}