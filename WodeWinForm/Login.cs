using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WodeWinForm
{
    public partial class Login : Skin_VS
    {
        //CCSkinMain Skin_Color，Skin_DevExpress，Skin_Mac，Skin_Metro，Skin_VS
        public Login()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //登陆窗体，验证成功执行代码 
            this.DialogResult = DialogResult.OK;

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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
