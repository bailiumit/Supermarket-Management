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
using C1.WPF.C1Chart;
using GUI.Window;

namespace GUI.FunctionBlock.Statistic
{
	/// <summary>
	/// StatisticBySeason.xaml 的交互逻辑
	/// </summary>
	public partial class StatisticBySeason : UserControl
	{
		private double[] amountData;
		private double[] profitData;

		private string[] quarters = new string[4] { "第一季度", "第二季度", "第三季度", "第四季度" };

		public StatisticBySeason()
		{
			InitializeComponent();
			ChartData.ItemNames = quarters;
		}

        public void CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();

            string[] strBuyingPriceArray = itemAccess.GetData("3", "BuyingPrice");
            string[] strSellingPriceArray = itemAccess.GetData("3", "SellingPrice");
            string[] quaterArray = itemAccess.GetData("3", "Quarter");
            int length = quaterArray.Length;
            double[] profitArray = new double[length];

            for (int i = 0; i < length; i++)
            {
                profitArray[i] = Convert.ToDouble(strSellingPriceArray[i]) -
                    Convert.ToDouble(strBuyingPriceArray[i]);
                switch (quaterArray[i])
                {
                    case "1":
                        amountData[0]++;
                        profitData[0] += profitArray[i];
                        break;
                    case "2":
                        amountData[1]++;
                        profitData[1] += profitArray[i];
                        break;
                    case "3":
                        amountData[2]++;
                        profitData[2] += profitArray[i];
                        break;
                    case "4":
                        amountData[3]++;
                        profitData[3] += profitArray[i];
                        break;
                    default:
                        break;
                }
            }            
        }

		private void DoStatistic_Button_Click(object sender, RoutedEventArgs e)
		{
            amountData = new double[4] { 0, 0, 0, 0 };
            profitData = new double[4] { 0, 0, 0, 0 };

            CreateData();

			if (StaticMethod_ComboBox.SelectedItem == ByAmount_ComboboxItem)
			{
				ChartDataSeries.Label = "按季度销量统计";
				ChartDataSeries.ValuesSource = amountData;
				if (ShowMethod_ComboBox.SelectedItem == Bar_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Bar;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else if (ShowMethod_ComboBox.SelectedItem == Line_ComboBoxItem)
				{
					Chart.ChartType = ChartType.LineSymbols;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else if (ShowMethod_ComboBox.SelectedItem == Pie_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Pie;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else
				{
					MessageBox.Show("请选择呈现方式！");
				}
			}
			else if (StaticMethod_ComboBox.SelectedItem == ByProfit_ComboboxItem)
			{
				ChartDataSeries.Label = "按季度利润统计";
				ChartDataSeries.ValuesSource = profitData;
				if (ShowMethod_ComboBox.SelectedItem == Bar_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Bar;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else if (ShowMethod_ComboBox.SelectedItem == Line_ComboBoxItem)
				{
					Chart.ChartType = ChartType.LineSymbols;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else if (ShowMethod_ComboBox.SelectedItem == Pie_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Pie;
					Chart.Reset(false);
					Chart.Visibility = Visibility.Visible;
				}
				else
				{
					MessageBox.Show("请选择呈现方式！");
				}
			}
			else
			{
				MessageBox.Show("请选择统计方式！");
			}
		}
	}
}
