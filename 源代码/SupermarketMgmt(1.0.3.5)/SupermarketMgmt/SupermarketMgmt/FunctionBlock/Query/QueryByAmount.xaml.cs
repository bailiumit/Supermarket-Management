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
using GUI.Window;
using System.Text.RegularExpressions;

namespace GUI.FunctionBlock.Query
{
	/// <summary>
	/// QueryByAmount.xaml 的交互逻辑
	/// </summary>
	public partial class QueryByAmount : UserControl
	{
        private int condition = 0;
        private int method = 0;
        int lengthChoice = 0;

        private string[] itemNameArray;

        private string[] sortedItemNameArray;
        private double[] sortedBuyingPriceArray;
        private double[] sortedSellingPriceArray;
        private int[] sortedNumberArray;

		private string[] name;
		private double[] buyingprice;
		private double[] sellingprice;
		private int[] amount;

		public QueryByAmount()
		{
			InitializeComponent();
		}

        #region 获取数据库中的数据并进行加工以得到所需数据
        //直接获得数据库中的数据
        private bool CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();
            int sortedLength = 0;
            int sortedCount = 0;

			if (condition == 0 || method == 0)
			{
				if (condition == 0)
				{
					MessageBox.Show("请选择商品状态。");
				}
				else
				{
					MessageBox.Show("请选择查询方式。");
				}
				return false;
			}

			if (amNumber_TextBox.Text != "")
			{
                if (!IsNumber(amNumber_TextBox.Text))
                {
                    MessageBox.Show("检测到非法输入，请确保结果条目数为正整数。");
                    return false;
                }
				lengthChoice = Convert.ToInt16(amNumber_TextBox.Text);
				if (lengthChoice <= 0)
				{
                    MessageBox.Show("检测到非法输入，请确保结果条目数为正整数。");
					return false;
				}
			}
			else
			{
				MessageBox.Show("请输入所需结果条目数。");
				return false;
			}

            itemNameArray = itemAccess.GetData(Convert.ToString(condition), "ItemName");
            string[] strBuyingPriceArray = itemAccess.GetData(Convert.ToString(condition), "BuyingPrice");
            string[] strSellingPriceArray = itemAccess.GetData(Convert.ToString(condition), "SellingPrice");
            int length = itemNameArray.Length;

            for (int i = 0; i < length; i++)
            {
                if (!IsNameExisted(i))
                {
                    sortedLength++;
                }
            }

            sortedItemNameArray = new string[sortedLength];
            sortedBuyingPriceArray = new double[sortedLength];
            sortedSellingPriceArray = new double[sortedLength];
            sortedNumberArray = new int[sortedLength];
            for (int i = 0; i < length; i++)
            {
                if (!IsNameExisted(i))
                {
                    sortedItemNameArray[sortedCount] = itemNameArray[i];
                    sortedBuyingPriceArray[sortedCount] = Convert.ToDouble(strBuyingPriceArray[i]);
                    sortedSellingPriceArray[sortedCount] = Convert.ToDouble(strSellingPriceArray[i]);
                    sortedNumberArray[sortedCount]++;
                    sortedCount++;
                }
                else
                {
                    sortedNumberArray[Anchor(i)]++;
                }
            }

            return true;
        }
        #endregion

        #region 生成所需数组数组的辅助函数
        private bool IsNameExisted(int position)
        {
            for (int i = 0; i < position; i++)
            {
                if (itemNameArray[i] == itemNameArray[position])
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
        #endregion

        #region 对数据进行排序处理，获得其下标
        //索引法确定数组中最大的n_lengthChoice个元素的下标
        private int[] SortBiggest(int[] n_sortedArray, int n_lengthChoice)
        {
            int length = n_sortedArray.Length;
            int[] orderArray = new int[length];
            int[] resultArray = new int[(length < n_lengthChoice)? length:n_lengthChoice];

            for (int i = 0; i < length; i++)
            {
                orderArray[i] = i;
            }
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (n_sortedArray[orderArray[j]] < n_sortedArray[orderArray[j + 1]])
                    {
                        int temp = orderArray[j];
                        orderArray[j] = orderArray[j + 1];
                        orderArray[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < n_lengthChoice && i < length; i++)
            {
                resultArray[i] = orderArray[i];
            }

            return resultArray;
        }

        //索引法确定数组中最小的n_lengthChoice个元素的下标
        private int[] SortSmallest(int[] n_sortedArray, int n_lengthChoice)
        {
            int length = n_sortedArray.Length;
            int[] orderArray = new int[length];
            int[] resultArray = new int[(length < n_lengthChoice) ? length : n_lengthChoice];

            for (int i = 0; i < length; i++)
            {
                orderArray[i] = i;
            }
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (n_sortedArray[orderArray[j]] > n_sortedArray[orderArray[j + 1]])
                    {
                        int temp = orderArray[j];
                        orderArray[j] = orderArray[j + 1];
                        orderArray[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < n_lengthChoice && i < length; i++)
            {
                resultArray[i] = orderArray[i];
            }

            return resultArray;
        }
        #endregion

        #region 点击“查询”按钮后对事件的操作
        private void DoQuery_Button_Click(object sender, RoutedEventArgs e)
		{
			List<dataStructForQueryByAmount> datalist = new List<dataStructForQueryByAmount>();

            if (!CreateData())
            {
                return;
            }

            name = new string[lengthChoice];
            buyingprice = new double[lengthChoice];
            sellingprice = new double[lengthChoice];
            amount = new int[lengthChoice];

            int[] orderArray = null;

            if (method > 0)
            {
                orderArray = SortBiggest(sortedNumberArray, lengthChoice);
            }
            else if (method < 0)
            {
                orderArray = SortSmallest(sortedNumberArray, lengthChoice);
            }


            for (int i = 0; i < lengthChoice; i++)
            {
                if (i >= sortedItemNameArray.Length)
                {
                    name[i] = "";
                    buyingprice[i] = 0;
                    sellingprice[i] = 0;
                    amount[i] = 0;
                }
                else
                {
                    name[i] = sortedItemNameArray[orderArray[i]];
                    buyingprice[i] = sortedBuyingPriceArray[orderArray[i]];
                    sellingprice[i] = sortedSellingPriceArray[orderArray[i]];
                    amount[i] = sortedNumberArray[orderArray[i]];
                }
            }

            bool warningThrownFlag = false;

            for (int i = 0; i < lengthChoice; i++)
            {
                if (buyingprice[i] != 0)
                {
                    datalist.Add(new dataStructForQueryByAmount(name[i], buyingprice[i], sellingprice[i], amount[i]));
                }
                if (buyingprice[i] == 0)
                {
                    if (!warningThrownFlag)
                    {
                        warningThrownFlag = true;
                        MessageBox.Show("查找到的结果少于要显示的结果条目数。");
                    }
                }        
            }
            QueryResult_DataGrid.ItemsSource = datalist;
		}
        #endregion

        #region 根据单选按钮组的选择确定condition, method属性
        private void amCD1_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            condition = 1;
        }

        private void amCD2_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            condition = 2;
        }

        private void amCD3_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            condition = 3;
        }

        private void amCD4_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            condition = 4;
        }

        private void amBiggest_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            method = 1;
        }

        private void amSmallest_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            method = -1;
        }
        #endregion

        #region 判断字符串内容是否为数字
        private bool IsNumber(string n_string)
        {
            Regex isNumber = new Regex("^[0-9]+$");
            if (isNumber.IsMatch(n_string))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

    #region 定义储存数据的结构体数组
    struct dataStructForQueryByAmount
	{
		private string name;
		private double buyingprice;
		private double sellingprice;
		private int amount;

		public string pName
		{
			get { return name; }
		}
		public double pBuyingPrice
		{
			get { return buyingprice; }
		}
		public double pSellingPrice
		{
			get { return sellingprice; }
		}
		public int pAmount
		{
			get { return amount; }
		}

		public dataStructForQueryByAmount(string _name, double _buyingprice, double _sellingprice, int _amount)
		{
			name = _name;
			buyingprice = _buyingprice;
			sellingprice = _sellingprice;
			amount = _amount;
		}
	}
    #endregion
}
