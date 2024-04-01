
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WodeWinForm
{
    public partial class Login : Form
    {
        //CCSkinMain ，Skin_Color，Skin_DevExpress，Skin_Mac，Skin_Metro，Skin_VS
        public Login()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            uiTextBoxUserName.Clear();
            uiTextBoxPassWord.Clear();
            uiTextBoxCode.Clear();
        }

        private async void uiButton1_Click(object sender, EventArgs e)
        {
            if(uiTextBoxCode.Text.ToLower() != CheckCode.ToLower())
            {
                uiPanelLoginMsg.Text = "验证码不正确，请检查！";
                uiPanelLoginMsg.ForeColor = Color.Red;
                return;
            }
            string u = uiTextBoxUserName.Text.Trim();
            string p = uiTextBoxUserName.Text.Trim();
            if(u == "" || p == "")
            {
                uiPanelLoginMsg.Text = "账号或密码不能为空";
                uiPanelLoginMsg.ForeColor = Color.Red;
                return;
            }
            uiButton1.Enabled = false;
            uiPanelLoginMsg.ForeColor = Color.Black;
            //登陆窗体，验证成功执行代码 
            uiPanelLoginMsg.Text = "正在登录，请稍后";
            if(1 == 0)
            {
                await Task.Delay(3000);
                uiPanelLoginMsg.Text = "登录OK";
                await Task.Delay(1000);
                GlobalConfig.LoginUserName = u;
                GlobalConfig.LoginUserPassword = p;
                this.DialogResult = DialogResult.OK;
                return;
            }
            uiPanelLoginMsg.Text = "账号或密码错误，请重新输入！";
            uiPanelLoginMsg.ForeColor = Color.Red;
            uiButton1.Enabled = true;

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
           

            try
            {
                //对消息框进行判断
                if (MessageBox.Show("你确定要退出吗？", "退出", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            //捕获异常
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetLettersNumbers();
            //GetLettersNumbers2();
        }
        private string CheckCode = "";
        /// <summary>
        /// 字母和数字
        /// </summary>
        private void GetLettersNumbers()
        {
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            string[] font = { "Times New Roman" };
            //验证码的字符集，去掉了一些容易混淆的字符 
            char[] character = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rnd = new Random();
            //生成验证码字符串 
            string txt = "";
            for (int i = 0; i < 4; i++)
            {
                txt += character[rnd.Next(character.Length)];
            }
            //创建画布
            int codeW = txt.Length * 22;
            int codeH = 22;
            codeW = pictureBox1.Width;
            codeH = pictureBox1.Height;
            Bitmap bmp = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪线 
            for (int i = 0; i < 3; i++)
            {
                int x1 = rnd.Next(codeW);
                int y1 = rnd.Next(codeH);
                int x2 = rnd.Next(codeW);
                int y2 = rnd.Next(codeH);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串 
            for (int i = 0; i < txt.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, 28);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(txt[i].ToString(), ft, new SolidBrush(clr), (float)i * 18, (float)0);
            }
            pictureBox1.Image = bmp;

            //uiTextBoxCode.Text = txt;
            CheckCode = txt;
        }

        private void GetLettersNumbers2()
        {
            string code = RandomVerificationCode(5);
            Bitmap bitmap = DrawImage(code);
            pictureBox1.Image = bitmap;
        }

        private Bitmap DrawImage(string code)
        {
            Color[] colors = {
        Color.Red, Color.OrangeRed,Color.SaddleBrown,
        Color.LimeGreen,Color.Green,Color.MediumAquamarine,
        Color.Blue,Color.MediumOrchid,Color.Black,
        Color.DarkBlue,Color.Orange,Color.Brown,
        Color.DarkCyan,Color.Purple
    };
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random random = new Random();
            // 创建一个 Bitmap 图片类型对象
            Bitmap bitmap = new Bitmap(code.Length * 18, 32);
            bitmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            // 创建一个图形画笔
            Graphics graphics = Graphics.FromImage(bitmap);
            // 将图片背景填充成白色
            graphics.Clear(Color.White);
            // 绘制验证码噪点
            for (int i = 0; i < random.Next(60, 80); i++)
            {
                int pointX = random.Next(bitmap.Width);
                int pointY = random.Next(bitmap.Height);
                graphics.DrawLine(new Pen(Color.LightGray, 1), pointX, pointY, pointX + 1, pointY);
            }
            // 绘制随机线条 1 条
            graphics.DrawLine(
                    new Pen(colors[random.Next(colors.Length)], random.Next(3)),
                    new Point(
                        random.Next(bitmap.Width),
                        random.Next(bitmap.Height)),
                    new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height)));
            // 绘制验证码
            for (int i = 0; i < code.Length; i++)
            {
                graphics.DrawString(
                    code.Substring(i, 1),
                    new Font(fonts[random.Next(fonts.Length)], 25, FontStyle.Bold),
                    new SolidBrush(colors[random.Next(colors.Length)]),16 * i + 1, random.Next(0, 5)
                    );
            }
            // 绘制验证码噪点
            for (int i = 0; i < random.Next(30, 50); i++)
            {
                int pointX = random.Next(bitmap.Width);
                int pointY = random.Next(bitmap.Height);
                graphics.DrawLine(new Pen(colors[random.Next(colors.Length)], 1), pointX, pointY, pointX, pointY + 1);
            }
            // 绘制随机线条 1 条
            graphics.DrawLine(
                    new Pen(colors[random.Next(colors.Length)], random.Next(3)),
                    new Point(
                        random.Next(bitmap.Width),
                        random.Next(bitmap.Height)),
                    new Point(random.Next(bitmap.Width),
                    random.Next(bitmap.Height)));
            return bitmap;
        }

        private  string RandomVerificationCode(int lengths)
        {
            string[] chars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string code = "";
            Random random = new Random();
            for (int i = 0; i < lengths; i++)
            {
                code += chars[random.Next(chars.Length)];
            }
            return code;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, null);
        }

        //如果是前端展示的话，还需要将图片数据转换成 Base64 的图片数据，代码如下所示。
        private  string BitmapToBase64Str(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                byte[] bytes = memoryStream.ToArray();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            uiButton1_Click(null, null);
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            uiButton2_Click(null, null);
        }
    }
    /*
     1.用户名为空时，文本框变颜色
2.进入到用户名后，恢复为原来颜色3.当用户名超过4位时，登录按钮不可用,并且提示4.双击用户名文本框，登录按钮可用5.当用户名超过6位时，弹出错误提示
6.按回车进入下一个文本框
7.关闭窗体时，弹出是否关闭的对话框8.按ENter=按登录，按Esc=按退出
9.防止窗体在任务栏出现
10.去掉最大化或最小化按钮
11.默认最大化的显示窗体
12.设置显示窗体中屏幕的中间
13.鼠标经过用户名文本框附近出现提示语
14.修改登录按钮为圆形
15.简单的验证码
16.填写的验证码必须是数字的验证
17.设置窗体与背景图片一样大小
18.防止用户使用AIt+F4关闭窗体
19.运行后，无法拖放窗体,两种方法
    httpss://blog.51cto.com/leafwf/185809


     */

    /*
说明：
首先CSkin界面库是完全免费的，可以任意使用，并且代码中无任何限制，如果有其他问题或者想购买界面库源码的可以加我QQ:345015918。
文件夹中的2.0和4.0指的是netframework版本。
使用教程：
1.工具箱右键-新建项-命名CSkin。
2.将CSkin.dll拖到新建的工具箱栏里。
3.控件添加完毕，控件拖拽到界面即可使用和引用。
4.窗体美化需要继承CCSkinMain。
 如：
 public partial class FrmMain : Form

 改成：
 public partial class FrmMain : CCSkinMain

 并且引用命名空间：
 using CCWin;

5.窗体还可以继承以下等多种主题：
Skin_Color，Skin_DevExpress，Skin_Mac，Skin_Metro，Skin_VS

详细图解参考此帖：
http://bbs.cskin.net/thread-803-1-1.html

更多CSkin案例源码下载：
http://bbs.cskin.net/thread-800-1-1.html
     */
}
