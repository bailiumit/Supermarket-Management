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
	/// QueryByStoreOrGroundingTime.xaml 的交互逻辑
	/// </summary>
	public partial class QueryByStoreOrGroundingTime : UserControl
	{


		private string[] name;
		private string[] code;
		private double[] buyingprice;
		private double[] sellingprice;
		private string[] condition;
		private string[] remark;
		private int[] time;

        private int method = 0;
        private int lengthChoice = 0;

		public QueryByStoreOrGroundingTime()
		{
			InitializeComponent();
		}

        #region 获取数据库中的数据并进行加工以得到所需数据
        private bool CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();

            if (longestImport_RadioButton.IsChecked == true)
            {
                method = 1;
            }
            else if (longestShelf_RadioButton.IsChecked == true)
            {
                method = 2;
            }
            else
            {
                MessageBox.Show("请选择查询方式。");
                return false;
            }

            if (impSheSearch_TextBox.Text != "")
            {
                if (!IsNumber(impSheSearch_TextBox.Text))
                {
                    MessageBox.Show("检测到非法输入，请确保结果条目数为正整数。");
                    return false;
                }
                lengthChoice = Convert.ToInt16(impSheSearch_TextBox.Text);
                if (lengthChoice <= 0)
                {
                    MessageBox.Show("检测到非法输入，请确保结果条目数为正整数。");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请输入所需结果条目数");
                return false;
            }

            name = itemAccess.GetData(Convert.ToString(method), "ItemName");
            code = itemAccess.GetData(Convert.ToString(method), "Code");
            string[] strBuyingPrice = itemAccess.GetData(Convert.ToString(method), "BuyingPrice");
            string[] strSellingPrice = itemAccess.GetData(Convert.ToString(method), "SellingPrice");
            condition = itemAccess.GetData(Convert.ToString(method), "Condition");
            remark = itemAccess.GetData(Convert.ToString(method), "Remark");
            string[] date = itemAccess.GetData(Convert.ToString(method), "ManipulateTime");

            int length = name.Length;
            buyingprice = new double[length];
            sellingprice = new double[length];
            for (int i = 0; i < length; i++)
            {
                buyingprice[i] = Convert.ToDouble(strBuyingPrice[i]);
                sellingprice[i] = Convert.ToDouble(strSellingPrice[i]);
            }

            time = new int[length];
            for (int i = 0; i < length; i++)
            {
                TimeSpan span = DateTime.Now - Convert.ToDateTime(date[i]);
                time[i] = Convert.ToInt16(span.TotalDays);
            }

            return true;
        }
        #endregion

        #region 对数据进行排序处理，获得其下标
        //索引法确定数组中最大的n_lengthChoice个元素的下标
        private int[] SortBiggest(int[] n_timeArray, int n_lengthChoice)
        {
            int length = n_timeArray.Length;
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
                    if (n_timeArray[orderArray[j]] < n_timeArray[orderArray[j + 1]])
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
            List<dataStructForQueryByStoreOrGroundingTime> datalist = new List<dataStructForQueryByStoreOrGroundingTime>();

            if (!CreateData())
            {
                return;
            }
            
            int[] orderArray = SortBiggest(time, lengthChoice);

            for (int i = 0; i < lengthChoice; i++)
            {
                if (i < name.Length)
                {
                    datalist.Add(new dataStructForQueryByStoreOrGroundingTime(name[orderArray[i]], code[orderArray[i]], buyingprice[orderArray[i]], sellingprice[orderArray[i]], remark[orderArray[i]], time[orderArray[i]]));
                }
                else
                {
                    MessageBox.Show("查找到的结果少于要显示的结果条目数.");
                    break;
                }
            }
            QueryResult_DataGrid.ItemsSource = datalist;
           
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
    struct dataStructForQueryByStoreOrGroundingTime
	{
		private string name;
		private string code;
		private double buyingprice;
		private double sellingprice;
		private string remark;
		private int time;

		public string pName
		{
			get { return name; }
		}
		public string pCode
		{
			get { return code; }
		}
		public double pBuyingPrice
		{
			get { return buyingprice; }
		}
		public double pSellingPrice
		{
			get { return sellingprice; }
		}
		public string pRemark
		{
			get { return remark; }
		}
		public int pTime
		{
			get { return time; }
		}

		public dataStructForQueryByStoreOrGroundingTime(string _name, string _code, double _buyingprice, double _sellingprice, string _remark, int _time)
		{
			name = _name;
			code = _code;
			buyingprice = _buyingprice;
			sellingprice = _sellingprice;
			remark = _remark;
			time = _time;
		}
	}
    #endregion
}
