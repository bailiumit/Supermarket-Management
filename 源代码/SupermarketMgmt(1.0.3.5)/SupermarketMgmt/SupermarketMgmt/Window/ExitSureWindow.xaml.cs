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

namespace GUI.Window
{
	/// <summary>
	/// ExitSureWindow.xaml 的交互逻辑
	/// </summary>
	public partial class ExitSureWindow : System.Windows.Window
	{
		public ExitSureWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 退出确认窗口|是
		/// </summary>
		private void Yes_Exit_Button_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void No_Exit_Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
