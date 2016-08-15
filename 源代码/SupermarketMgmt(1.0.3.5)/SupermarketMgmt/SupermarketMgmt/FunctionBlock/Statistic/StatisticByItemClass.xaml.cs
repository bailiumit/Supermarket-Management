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
	/// StatisticByItemClass.xaml 的交互逻辑
	/// </summary>
	public partial class StatisticByItemClass : UserControl
	{
		private double[] amountData;
		private double[] profitData;

		private string[] itemClassNames = new string[4] { "电器（01）", "百货（02）", "食品（03）", "书籍（04）" };

        public StatisticByItemClass()
        {
            InitializeComponent();
			ChartData.ItemNames = itemClassNames;
        }

        public void CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();

            string[] strBuyingPriceArray = itemAccess.GetData("3", "BuyingPrice");
            string[] strSellingPriceArray = itemAccess.GetData("3", "SellingPrice");
            string[] firstCatArray = itemAccess.GetData("3", "FirstCategory");
            int length = firstCatArray.Length;
            double[] profitArray = new double[length];

            for (int i = 0; i < length; i++)
            {
                profitArray[i] = Convert.ToDouble(strSellingPriceArray[i]) -
                    Convert.ToDouble(strBuyingPriceArray[i]);
                switch (firstCatArray[i])
                {
                    case "01":
                        amountData[0]++;
                        profitData[0] += profitArray[i];
                        break;
                    case "02":
                        amountData[1]++;
                        profitData[1] += profitArray[i];
                        break;
                    case "03":
                        amountData[2]++;
                        profitData[2] += profitArray[i];
                        break;
                    case "04":
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
				ChartDataSeries.Label = "按销量统计";
				ChartDataSeries.ValuesSource = amountData;
				if (ShowMethod_ComboBox.SelectedItem == Bar_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Bar;
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
				ChartDataSeries.Label = "按利润统计";
				ChartDataSeries.ValuesSource = profitData;
				if (ShowMethod_ComboBox.SelectedItem == Bar_ComboBoxItem)
				{
					Chart.ChartType = ChartType.Bar;
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
