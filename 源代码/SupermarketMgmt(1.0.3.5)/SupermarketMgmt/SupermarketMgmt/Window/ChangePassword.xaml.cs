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
using System.Diagnostics;

namespace GUI.Window
{
	/// <summary>
	/// ChangePassword.xaml 的交互逻辑
	/// </summary>
	public partial class ChangePassword : System.Windows.Window
	{
		private string currStuffNumber;
		private string currPassword;

		public ChangePassword(string _currStuffNumber)
		{
			InitializeComponent();

			currStuffNumber = _currStuffNumber;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string oldPassword = OldPassword_PasswordBox.Password;
			string newPassword = NewPassword_PasswordBox.Password;
			string repeatPassword = RepeatPassword_PasswordBox.Password;

			StuffAccess myStuffAccess = new StuffAccess();

			currPassword = myStuffAccess.PasswordQuery(currStuffNumber);

			if (oldPassword != currPassword)
			{
				MessageBox.Show("旧密码输入错误！");
				Debug.WriteLine(oldPassword);
				return;
			}
			if (newPassword != repeatPassword)
			{
				MessageBox.Show("两次输入的新密码不一致！");
				return;
			}

			if (MessageBox.Show("确定要修改密码？", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				string[] toUpdate = new string[2];
				toUpdate[0] = currStuffNumber;
				toUpdate[1] = repeatPassword;
				myStuffAccess.UpdatePassword(toUpdate);
				Debug.WriteLine("Old password:" + oldPassword);
				this.Close();
			}
			else
			{
				return;
			}
		}
	}
}
