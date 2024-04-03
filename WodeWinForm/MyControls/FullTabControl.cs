using System;
using System.Drawing;
using System.Windows.Forms;
using WodeWinForm.Properties;

namespace WodeWinForm.MyControls
{
    public class FullTabControl : TabControl
    {

        protected override void OnPaint(PaintEventArgs pe)
        {
            //this.DrawTitle(pe.Graphics);
            base.OnPaint(pe);


        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                //return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8);
                return new Rectangle(rect.Left - 2, rect.Top - 2, rect.Width + 4, rect.Height + 4);

                // 如果需要与父控件之间有间隔，可以用tabpage的padding来模拟
            }
        }

        const int CLOSE_SIZE = 15;
        private Color _BackColor; //背景颜色 原文链接：https://blog.csdn.net/sinat_29136193/article/details/80652443
        public override Color BackColor
        {//重写backcolor属性 
            get
            {
                return this._BackColor;
            }
            set
            {
                this._BackColor = value;
            }
        }


        //tabPage标签图片
        //Bitmap image = new Bitmap(@"C:\Users\admin\Desktop\下载 (1).jpg");

        //private MenuItemCollection menuItemCollection;
        public FullTabControl()
        {
            //https://www.cnblogs.com/fangjb/p/15786779.html
            //InitializeComponent();

            //this.SetStyle(ControlStyles.UserPaint, true);//用户自己绘制
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);   //
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ////让控件支持透明色
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.UpdateStyles();

            //将TabControl的SizeMode属性设为Fixed
            //设置ItemSize的大小(width)

            //this.SizeMode = TabSizeMode.Fixed;
            // 设置TabControl的标签高度
            //this.ItemSize = new Size(0, 40); // 宽度设置为0，自动计算；高度设置为100像素
             // this.ItemSize = new Size(0, 30);
            // 设置TabControl的标签与边缘的间距
            //tabControl.Padding = new Padding(10); // 默认情况下，高度不受Padding影响，但可以调整左右间距

             //this.Padding = new Point(12, 3);
             //this.Padding = new System.Drawing.Point(30, 60);

            //DrawMode:指定用户还是系统来绘制标题
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            //this.SizeMode = TabSizeMode.Fixed;
            this.HotTrack = true;
            this.DrawItem += new DrawItemEventHandler(this.KDelTabControl_DrawItem);
            this.MouseDown += new MouseEventHandler(this.KDelTabControl_MouseDown);
            //menuItemCollection = this.ContextMenu.MenuItems;

        }

        SolidBrush red = new SolidBrush(Color.Red);              // 红色
        SolidBrush yellow = new SolidBrush(Color.Yellow);        //黄色
        SolidBrush blue = new SolidBrush(Color.Blue);             //蓝色
        SolidBrush black = new SolidBrush(Color.Black);            //黑色
        SolidBrush Azure = new SolidBrush(Color.Azure);

         
        //绘制“Ｘ”号即关闭按钮
        private void KDelTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //选中的标签页填充成白色
                //using (SolidBrush s = new SolidBrush(Color.White))

                var BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
                var color = e.Index == this.SelectedIndex ? Color.LightGoldenrodYellow : BackColor;
                //color = e.Index == this.SelectedIndex ? SystemColors.InactiveBorder : BackColor;
                //color = e.Index == this.SelectedIndex ? Color.FromArgb(0, 255, 255, 255) : BackColor;
                //color = e.Index == this.SelectedIndex ? BackColor : Color.FromArgb(0, 255, 255, 255);
                //using (SolidBrush s = new SolidBrush(Color.LightYellow))
                using (SolidBrush s = new SolidBrush(color))
                {
                    //Rectangle rect = this.GetTabRect(this.SelectedIndex);
                    Rectangle rect = this.GetTabRect(e.Index);
                    e.Graphics.FillRectangle(s, rect);
                }
                if (e.State == DrawItemState.Selected)
                {
                    //SolidBrush backbrush = new SolidBrush(Color.FromArgb(255, 51, 102, 255));
                    //SolidBrush fontbrush = new SolidBrush(Color.White);
                    //Font tabFont = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);
                    //borderpen = new Pen(Color.FromArgb(255, 51, 102, 255));
                }
                else
                {
                    //SolidBrush backbrush = new SolidBrush(Color.FromArgb(255, 43, 87, 154));
                    //SolidBrush fontbrush = new SolidBrush(Color.White);
                    //Font tabFont = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);
                    //borderpen = new Pen(Color.FromArgb(255, 43, 87, 154));
                }
                StringFormat StringF = new StringFormat();
                StringF.Alignment = StringAlignment.Near;
                //StringF.LineAlignment = StringAlignment.Far;
                var ziti = new Font("黑体", 10);
                //ziti = new Font("微软雅黑", 10);
                ziti = e.State == DrawItemState.Selected ? new Font("微软雅黑", 11.3F, FontStyle.Bold, GraphicsUnit.Pixel) : new Font("微软雅黑", 11.3F, GraphicsUnit.Pixel);
                ziti = e.State == DrawItemState.Selected ? new Font("微软雅黑", 11.5F, FontStyle.Bold, GraphicsUnit.Pixel) : new Font("微软雅黑", 11.5F, GraphicsUnit.Pixel);
                ziti = e.State == DrawItemState.Selected ? new Font("微软雅黑", 12, FontStyle.Bold, GraphicsUnit.Pixel) : new Font("微软雅黑", 12, GraphicsUnit.Pixel);
                //ziti = e.State == DrawItemState.Selected ? new Font("宋体", 12, FontStyle.Bold, GraphicsUnit.Pixel) : new Font("宋体", 12, GraphicsUnit.Pixel);

                Rectangle tab = this.GetTabRect(e.Index);
                var yanse = e.Index == this.SelectedIndex ? blue : black;
                //先添加TabPage属性  
                //e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, tab.X + 2, tab.Y + 2);
                //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, yanse, tab.X + 2, tab.Y + 2);

                //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, yanse, tab.X + 1.5F, tab.Y + 20, StringF);
                e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, yanse, tab.X + 2, tab.Y + 20);
                //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, yanse, tab.X + 2, tab.Y + 20, StringF);
                //绘制标签背景
                //e.Graphics.FillRectangle(yellow, tab);

                //绘制标签字体
                StringFormat _StringFlags = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                _StringFlags.Alignment = StringAlignment.Center;
                _StringFlags.LineAlignment = StringAlignment.Center;
                //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, blue, tab, _StringFlags);
                //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, blue, tab, StringF);

                //绘制非标签原始名称【可依据e.State修改】 g.DrawString("呵呵", tabFont, fontbrush, backrect, new StringFormat(_StringFlags));


                //再画一个矩形框
                using (Pen p = new Pen(Color.Transparent))
                {
                    tab.Offset(tab.Width - (CLOSE_SIZE + 3), 2);
                    tab.Width = CLOSE_SIZE;
                    tab.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, tab);
                }
                //填充矩形框
                //Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.Transparent;
                //using (Brush b = new SolidBrush(recColor))
                //{
                //    e.Graphics.FillRectangle(b, tab);
                //}
                //画关闭符号
                float w = 2F;
                var X = e.Index == this.SelectedIndex ? red : blue;
                //using (Pen objpen = new Pen(Color.Red, w))
                if (e.State == DrawItemState.Selected)
                {
                    #region 关闭按钮
                    using (Pen objpen = new Pen(X, w))
                    {
                        ////=============================================
                        //自己画X
                        //"\"线
                        Point p1 = new Point(tab.X + 3, tab.Y + 3);
                        Point p2 = new Point(tab.X + tab.Width - 3, tab.Y + tab.Height - 3);
                        e.Graphics.DrawLine(objpen, p1, p2);
                        //"/"线
                        Point p3 = new Point(tab.X + 3, tab.Y + tab.Height - 3);
                        Point p4 = new Point(tab.X + tab.Width - 3, tab.Y + 3);
                        e.Graphics.DrawLine(objpen, p3, p4);

                        ////=============================================
                        //使用图片
                        //Bitmap bt = new Bitmap(image);
                        //Point p5 = new Point(tab.X, 4);
                        //e.Graphics.DrawImage(bt, p5);

                        ////设置文字对齐方式
                        //StringFormat StringF = new StringFormat();
                        //StringF.Alignment = StringAlignment.Center;
                        //StringF.LineAlignment = StringAlignment.Center;
                        //var ziti = new Font("宋体", 12);

                        //e.Graphics.DrawString(this.TabPages[e.Index].Text, ziti, objpen.Brush, tab, StringF);
                    }
                    #endregion
                }
              
                //e.Graphics.Dispose();
            }
            catch (Exception)
            { }
            finally
            {
                e.Graphics.Dispose();
            }
        }

        private void KDelTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域  
                Rectangle tab = this.GetTabRect(this.SelectedIndex);
                tab.Offset(tab.Width - (CLOSE_SIZE + 3), 2);
                tab.Width = CLOSE_SIZE;
                tab.Height = CLOSE_SIZE;
                //如果鼠标在区域内就关闭选项卡  
                bool isClose = x > tab.X && x < tab.Right && y > tab.Y && y < tab.Bottom;

                if (isClose == true)
                {

                    var tp = base.SelectedTab; //sender as TabPage;

                    if (MessageBox.Show($"确认要关闭（{tp.Text}）", "提醒", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    this.TabPages.Remove(this.SelectedTab);
                    if (this.TabPages.Count - 1 > 0)
                    {
                        this.SelectedTab = this.TabPages[this.TabPages.Count - 1];
                    }
                }
            }


            if (e.Button == MouseButtons.Right)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域  
                Rectangle tab = this.GetTabRect(this.SelectedIndex);
                //tab.Offset(tab.Width - (CLOSE_SIZE + 3), 2);
                //tab.Width = CLOSE_SIZE;
                //tab.Height = CLOSE_SIZE;
                //如果鼠标在区域内就关闭选项卡  
                int w = e.Location.X + tab.Width;
                int h = e.Location.Y + tab.Height;
                bool isClose = x > tab.X && x < tab.Right && y > tab.Y && y < tab.Bottom;
                isClose = x >= e.Location.X && x <= w && h >= e.Location.Y && y <= h;
                
                if (isClose == true) {
                   // MessageBox.Show(" MouseButtons.Right");
                }
                else
                {
                    
                }
                this.ContextMenuStrip.Visible = isClose;
                //foreach(MenuItem v in this.ContextMenuStrip.Visible)
                //{
                //    v.Visible = isClose;
                // }

            }
        }

        private void tabControl_main_DrawItem(object sender, DrawItemEventArgs e)
        {
            //设置笔刷
            //SolidBrush red = new SolidBrush(Color.Red);              // 红色
            //SolidBrush yellow = new SolidBrush(Color.Yellow);        //黄色
            //SolidBrush blue = new SolidBrush(Color.Blue);             //蓝色
            //SolidBrush black = new SolidBrush(Color.Black);            //黑色
            //设置背景

            //绘制红色背景
            // Rectangle rectangleRed = this.GetTabRect(0);
            // e.Graphics.FillRectangle(red, rectangleRed);

            //绘制黄色背景
            //Rectangle rectangleYellow = this.GetTabRect(1);
            //e.Graphics.FillRectangle(yellow, rectangleYellow);
            //绘制黄色背景
            //Rectangle rectangleBlue = this.GetTabRect(2);
            //e.Graphics.FillRectangle(blue, rectangleBlue);
            //设置标签文字居中对齐
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            //设置标签文字
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle rec = this.GetTabRect(i);
                e.Graphics.FillRectangle(yellow, rec);
                //设置文字字体和文字大小
                //e.Graphics.DrawString(this.TabPages[i].Text, new Font("宋体", 10), black, rec, stringFormat);
                e.Graphics.DrawString("hahaha", new Font("宋体", 10), black, rec, stringFormat);
            }

        }
        private void tabControlLeft_DrawItem(object sender, DrawItemEventArgs e)
        {
            //标签背景填充颜色
            SolidBrush BackBrush = new SolidBrush(Color.Yellow);
            //标签文字填充颜色
            SolidBrush FrontBrush = new SolidBrush(Color.Black);
            StringFormat StringF = new StringFormat();
            //设置文字对齐方式
            StringF.Alignment = StringAlignment.Center;
            StringF.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < this.TabPages.Count; i++)
            {
                //获取标签头工作区域
                Rectangle Rec = this.GetTabRect(i);
                //绘制标签头背景颜色
                //e.Graphics.FillRectangle(BackBrush, Rec);
                //绘制标签头文字
                e.Graphics.DrawString(this.TabPages[i].Text, new Font("宋体", 12), FrontBrush, Rec, StringF);
            }
        }

        private void tabControlLeft_DrawItem3(object sender, DrawItemEventArgs e)
        {
            //标签背景填充颜色
            //SolidBrush BackBrush = new SolidBrush(MainBackColor);
            ////标签文字填充颜色
            //SolidBrush FrontBrush = new SolidBrush(Color.Black);
            //StringFormat StringF = new StringFormat();
            ////设置文字对齐方式
            //StringF.Alignment = StringAlignment.Center;
            //StringF.LineAlignment = StringAlignment.Center;

            //for (int i = 0; i < tabControlLeft.TabPages.Count; i++)
            //{
            //    //获取标签头工作区域
            //    Rectangle Rec = tabControlLeft.GetTabRect(i);
            //    //绘制标签头背景颜色
            //    e.Graphics.FillRectangle(BackBrush, Rec);
            //    //绘制标签头文字
            //    e.Graphics.DrawString(tabControlLeft.TabPages[i].Text, new Font("宋体", 12), FrontBrush, Rec, StringF);
            //}
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image imgButton = null;//Mana.Properties.Resources.button;
            Image imgBJ = null;//Mana.Properties.Resources.bg3;
            //绘制主控件的背景
            Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
            e.Graphics.DrawImage(imgBJ, Rect);

            //新建一个StringFormat对象，用于对标签文字的布局设置
            StringFormat StrFormat = new StringFormat();
            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中
            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中          

            SolidBrush bruFont = new SolidBrush(Color.FromArgb(255, 255, 255));// 标签字体颜色
            Font font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);//设置标签字体样式

            //绘制标签样式         
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                //获取标签头的工作区域
                Rectangle recChild = this.GetTabRect(i);
                Rectangle newRect = new Rectangle(recChild.Left - 7, recChild.Top, recChild.Width - 7, recChild.Height);
                //绘制标签头背景颜色
                e.Graphics.DrawImage(imgButton, newRect);
                //绘制标签头的文字
                e.Graphics.DrawString(this.TabPages[i].Text, font, bruFont, newRect, StrFormat);
            }
            //Console.WriteLine("tabControl_DrawItem" + "  " + countTest.ToString());
            //countTest++;
        }

        private void tclDemo_DrawItem(object sender, DrawItemEventArgs e)
        {

            //获取TabControl主控件的工作区域
            Rectangle rec = this.ClientRectangle;
            //获取背景图片，我的背景图片在项目资源文件中。

            Image backImage = Resources.Graphicloads_Colorful_Long_Shadow_Zoom_16;
            //新建一个StringFormat对象，用于对标签文字的布局设置

            StringFormat StrFormat = new StringFormat();
            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中
            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中          

            // 标签背景填充颜色，也可以是图片

            SolidBrush bru = new SolidBrush(Color.FromArgb(72, 181, 250));
            SolidBrush bruFont = new SolidBrush(Color.FromArgb(217, 54, 26));// 标签字体颜色
            Font font = new System.Drawing.Font("微软雅黑", 12F);//设置标签字体样式

            //绘制主控件的背景
            e.Graphics.DrawImage(backImage, 0, 0, this.Width, this.Height);

            //绘制标签样式
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                //获取标签头的工作区域
                Rectangle recChild = this.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(bru, recChild);
                //绘制标签头的文字
                e.Graphics.DrawString(this.TabPages[i].Text, font, bruFont, recChild, StrFormat);

            }
        }

        private void tabModuleMainItem_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font font;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.SelectedIndex)
            {
                font = new Font("微软雅黑", 12.5f, FontStyle.Bold);
                bshBack = new SolidBrush(Color.Yellow);
                bshFore = Brushes.Black;
            }
            else
            {
                font = new Font("微软雅黑", 12f, FontStyle.Regular);
                bshBack = new SolidBrush(Color.Gray);
                bshFore = new SolidBrush(Color.White);
            }

            StringFormat sftTab = new StringFormat();
            sftTab.LineAlignment = StringAlignment.Center;
            sftTab.Alignment = StringAlignment.Center;

            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 8);
            e.Graphics.DrawString(this.TabPages[e.Index].Text, font, bshFore, recTab, sftTab);
        }

        private void tb_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();

            #region 头背景
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Rectangle rec = this.ClientRectangle;
            //获取背景图片，我的背景图片在项目资源文件中。
            Image backImage = Properties.Resources.Ampeross_Qetto_2_Search_32;
            e.Graphics.DrawImage(backImage, 0, 2, this.Width, this.ItemSize.Height + 2);
            #endregion
            #region  设置选择的标签的背景
            if (e.Index == this.SelectedIndex)
                e.Graphics.DrawImage(Properties.Resources.Ampeross_Qetto_2_Search_32, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            else
                e.Graphics.DrawImage(Properties.Resources.Ampeross_Qetto_2_Search_32, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,
            System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.Black), e.Bounds, sf);
            #endregion
            #region 重写标签名
            ColorConverter colorConverter = new ColorConverter();
            Color cwhite = (Color)colorConverter.ConvertFromString("#2178ba");
            SolidBrush white = new SolidBrush(cwhite);
            Rectangle rect0 = this.GetTabRect(0);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("申请单号", new Font("微软雅黑", 12), white, rect0, stringFormat);
            #endregion
        }

        //protected virtual void DrawTitle(Graphics g)
        //{
        //    Image imgButton = null;//OcvMana.Properties.Resources.button;

        //    StringFormat sf = new StringFormat();
        //    sf.Alignment = StringAlignment.Center;
        //    sf.LineAlignment = StringAlignment.Center;
        //    Font font = new System.Drawing.Font("微软雅黑", 10F, FontStyle.Bold);//设置标签字体样式
        //    using (SolidBrush sb = new SolidBrush(Color.FromArgb(127, 0, 0, 0)))
        //    {
        //        for (int i = 0; i < this.TabPages.Count; i++)
        //        {
        //            Rectangle rect = this.GetTabRect(i);
        //            Rectangle newRect = new Rectangle(rect.Left + 7, rect.Top, rect.Width - 7, rect.Height);

        //            g.DrawImage(imgButton, newRect);
        //            g.DrawString(this.TabPages[i].Text, font, Brushes.White, rect, sf);
        //        }
        //    }
        //}


    }
}
