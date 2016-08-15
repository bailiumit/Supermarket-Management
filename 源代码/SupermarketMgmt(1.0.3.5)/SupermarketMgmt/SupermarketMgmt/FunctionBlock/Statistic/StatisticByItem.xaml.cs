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
	/// StatisticByItem.xaml 的交互逻辑
	/// </summary>
	public partial class StatisticByItem : UserControl
	{
        private string[] itemNameArray;
        private string[] sortedItemNameArray;
        private double[] sortedNumberArray;
        private double[] sortedProfitArray;
        
        private double[] amountData;
		private string[] amountName;

		private double[] profitData;
		private string[] profitName;

		public StatisticByItem()
		{
			InitializeComponent();
		}

        private void CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();
            int sortedLength = 0;

            itemNameArray = itemAccess.GetData("3", "ItemName");
            string[] strBuyingPriceArray = itemAccess.GetData("3", "BuyingPrice");
            string[] strSellingPriceArray = itemAccess.GetData("3", "SellingPrice");
            int length = itemNameArray.Length;
            double[] profitArray = new double[length];
            for (int i = 0; i < length; i++)
            {
                profitArray[i] = Convert.ToDouble(strSellingPriceArray[i]) -
                    Convert.ToDouble(strBuyingPriceArray[i]);
            }

            sortedItemNameArray = new string[length];
            sortedNumberArray = new double[length];
            sortedProfitArray = new double[length];
            for (int i = 0; i < length; i++)
            {
                if (!IsNameExisted(i))
                {
                    sortedItemNameArray[sortedLength] = itemNameArray[i];
                    sortedNumberArray[sortedLength]++;
                    sortedProfitArray[sortedLength] += profitArray[i];
                    sortedLength++;
                }
                else
                {
                    sortedNumberArray[Anchor(i)]++;
                    sortedProfitArray[Anchor(i)] += profitArray[i];
                }
            }
        }

        private bool IsNameExisted(int position)
        {
            for (int i = 0; i < position; i++)
            {
                if(itemNameArray[i] == itemNameArray[position])
                    return true;
            }
            return false;
        }

        private int Anchor(int position)
        {
            for (int i = 0; i < position; i++)
            {
                if (itemNameArray[position] == sortedItemNameArray[i])
                    return i;
            }
            return -1;
        }

        //索引法确定数组中最大的六个元素的下标
        private int[] SortBiggest(double[] n_sortedArray)
        {
            int length = n_sortedArray.Length;
            int[] orderArray = new int[length];
            int[] resultArray = new int[6];

            for (int i = 0; i < length; i++)
            {
                orderArray[i] = i;
            }
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (n_sortedArray[orderArray[j]] < n_sortedArray[orderArray[j+1]])
                    {
                        int temp = orderArray[j];
                        orderArray[j] = orderArray[j + 1];
                        orderArray[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                resultArray[i] = orderArray[i];
            }

            return resultArray;
        }

        private void DoStatistic_Button_Click(object sender, RoutedEventArgs e)
		{
            CreateData();
            int[] amountOrder = SortBiggest(sortedNumberArray);
            int[] profitOrder = SortBiggest(sortedProfitArray);

            amountData = new double[6] { 
                sortedNumberArray[amountOrder[0]], 
                sortedNumberArray[amountOrder[1]], 
                sortedNumberArray[amountOrder[2]],
                sortedNumberArray[amountOrder[3]], 
                sortedNumberArray[amountOrder[4]], 
                sortedNumberArray[amountOrder[5]]
            };
            amountName = new string[6] { 
                sortedItemNameArray[amountOrder[0]],
                sortedItemNameArray[amountOrder[1]],
                sortedItemNameArray[amountOrder[2]],
                sortedItemNameArray[amountOrder[3]],
                sortedItemNameArray[amountOrder[4]],
                sortedItemNameArray[amountOrder[5]]
            };

            profitData = new double[6] {
                sortedProfitArray[profitOrder[0]],
                sortedProfitArray[profitOrder[1]],
                sortedProfitArray[profitOrder[2]],
                sortedProfitArray[profitOrder[3]],
                sortedProfitArray[profitOrder[4]],
                sortedProfitArray[profitOrder[5]],
            };
            profitName = new string[6] {
                sortedItemNameArray[profitOrder[0]],
                sortedItemNameArray[profitOrder[1]],
                sortedItemNameArray[profitOrder[2]],
                sortedItemNameArray[profitOrder[3]],
                sortedItemNameArray[profitOrder[4]],
                sortedItemNameArray[profitOrder[5]],    
            };

			if (StaticMethod_ComboBox.SelectedItem == ByAmount_ComboboxItem)
			{
				ChartDataSeries.Label = "销量最大的六件商品";
				ChartDataSeries.ValuesSource = amountData;
				ChartData.ItemNames = amountName;
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
				ChartDataSeries.Label = "利润最大的六件商品";
				ChartDataSeries.ValuesSource = profitData;
				ChartData.ItemNames = profitName;
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
