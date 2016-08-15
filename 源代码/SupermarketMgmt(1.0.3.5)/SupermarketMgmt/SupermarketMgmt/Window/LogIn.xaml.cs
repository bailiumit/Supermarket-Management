using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI.Window;

namespace GUI.Window
{
	/// <summary>
	/// LogIn.xaml 的交互逻辑
	/// </summary>
	public partial class LogIn : System.Windows.Window
	{
		private string stuffName = "";
		private string stuffNumber = "";
		private string stuffPosition = "";
		private string positionName;

		private bool[] rights = new bool[4];

		public string pName
		{
			set { stuffName = value; }
		}
		public string pPositionStr
		{
			set { stuffPosition = value; }
		}

		public LogIn()
		{
			InitializeComponent();
		}

        //定义“登陆框”中“登陆”按钮被按下后的事件操作
		private void logIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] logInCommand = new string[2];
            string[] queryResult = new string[5];
            string logInResult = null;
            StuffAccess stuffAccess = new StuffAccess();

            logInCommand[0] = stuffNumber_TextBox.Text;
            logInCommand[1] = password_PasswordBox.Password;
            queryResult = stuffAccess.LogInStuff(logInCommand);
            logInResult = queryResult[4];


            if (logInResult == "1")
            {
                stuffNumber = queryResult[0];
                stuffName = queryResult[1];
                stuffPosition = queryResult[2];

				if (stuffPosition == "1")
				{
					positionName = "仓库管理员";
					rights[0] = true;
					rights[1] = false;
					rights[2] = false;
					rights[3] = false;
				}
				else if (stuffPosition == "2")
				{
					positionName = "会计";
					rights[0] = false;
					rights[1] = false;
					rights[2] = true;
					rights[3] = true;
				}
				else if (stuffPosition == "3")
				{
					positionName = "经理";
					rights[0] = true;
					rights[1] = true;
					rights[2] = true;
					rights[3] = true;
				}

                MainWindow window = new MainWindow(stuffName, stuffNumber, positionName, rights);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入！");
            }
        }

        //定义“登陆框”中“退出”按钮被按下后的事件操作
		private void exit_Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			Application.Current.Shutdown();
		}
	}
}