#define _DEBUG

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using LogicLib;
using System.Collections;

namespace GUI.Window
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : System.Windows.Window
	{
		private string currUserNumber;
        static public string currUserName;

		public MainWindow(string _stuffName, string _stuffNumber, string _stuffPosition, bool[] _stuffRight)
		{
			InitializeComponent();

			MainPad.Content = new FunctionBlock.StartupWelcome.StartupWelcome();

			ItemManagement_MenuItem.IsEnabled = _stuffRight[0];
			StuffManagement_MenuItem.IsEnabled = _stuffRight[1];
			Query_MenuItem.IsEnabled = _stuffRight[2];
			Statistic_MenuItem.IsEnabled = _stuffRight[3];

			Right0.IsChecked = _stuffRight[0];
			Right1.IsChecked = _stuffRight[1];
			Right2.IsChecked = _stuffRight[2];
			Right3.IsChecked = _stuffRight[3];

			currUserNumber = _stuffNumber;
            currUserName = _stuffName;

			StuffName_TextBox.Text = _stuffName;
			StuffNumber_TextBox.Text = _stuffNumber;
			StuffPosition_TextBox.Text = _stuffPosition;

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(10000);
			timer.Tick += new EventHandler(OnTimerTick);
			timer.Start();
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			CurrentTime_TextBox.Text = DateTime.Now.ToString();
		}

        private string GetCurrUserName()
        {
            return currUserName;
        }

		/// <summary>
		/// 系统|退出系统 的交互逻辑
		/// </summary>
		private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			ExitSureWindow _ExitSureWindow = new ExitSureWindow();
			_ExitSureWindow.Show();
		}

		/// <summary>
		/// 系统|关于 的交互逻辑
		/// </summary>
		private void About_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			AboutWindow _AboutWindow = new AboutWindow();
			_AboutWindow.Show();

//#if _DEBUG
//            Class0101 newComputer = new Class0101();

//            newComputer.CpuFreq = 2.75;
//            newComputer.Ram = 8;
//            newComputer.Guarantee = 4;
//            newComputer.ItemName = "Laptop";
//            newComputer.BuyingPrice = 2000;
//            newComputer.SellingPrice = 2500;
//            newComputer.Remark = "Good Computer!";
//            newComputer.FirstCategory = "01";
//            newComputer.SecondCategory = "0101";
//            newComputer.Code = "code0122654";
//            newComputer.Condition = _Condition.售出;
//            newComputer.Quarter = _Quarter.FirstQuarter;

//            ArrayList list = newComputer.ToStringArrayList();
//            foreach (string str in list)
//            {
//                Debug.WriteLine(str);
//            }
//#endif
		}

		/// <summary>
		/// 操作|管理商品 的交互逻辑
		/// </summary>
		private void ItemManagement_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Operation.ItemManagement();
		}

		/// <summary>
		/// 操作|管理员工 的交互逻辑
		/// </summary>
		private void StuffManagement_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Operation.StuffManagementt();
		}

		/// <summary>
		/// 查询|商品数量查询 的交互逻辑
		/// </summary>
		private void QueryByAmount_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Query.QueryByAmount();
		}

		/// <summary>
		/// 查询|商品入库时间查询 的交互逻辑
		/// </summary>
		private void QueryByImportTime_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Query.QueryByImportTime();
		}

		/// <summary>
		/// 查询|商品库存/上架时间查询 的交互逻辑
		/// </summary>
		private void QueryByStoreOrGroundingTime_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Query.QueryByStoreOrGroundingTime();
		}

		/// <summary>
		/// 统计|按季度统计 的交互逻辑
		/// </summary>
		private void StatisticBySeason_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Statistic.StatisticBySeason();
		}

		/// <summary>
		/// 统计|按商品类别统计 的交互逻辑
		/// </summary>
		private void StatisticByItemClass_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Statistic.StatisticByItemClass();
		}

		private void StatisticByItem_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Statistic.StatisticByItem();
		}

		private void ModifyPassword_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			ChangePassword _ChangePassword = new ChangePassword(currUserNumber);
			_ChangePassword.Show();
		}

		private void QueryBySingleItem_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MainPad.Content = new FunctionBlock.Query.QueryBySingleItem();
		}
	}
}
