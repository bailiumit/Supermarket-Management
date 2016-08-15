using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using GUI.Window;
using LogicLib;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ICSharpCode;

namespace GUI.FunctionBlock.Query
{
	/// <summary>
	/// QueryByImportTime.xaml 的交互逻辑
	/// </summary>
	public partial class QueryByImportTime : UserControl
	{
		private string[] name;
		private string[] code;
        private double[] buyingprice;
        private double[] sellingprice;
		private string[] condition;
		private string[] remark;
        private string[] date;

        private int year;
        private int month;

		public QueryByImportTime()
		{
			InitializeComponent();
		}

        #region 获取数据库中的数据并进行加工以得到所需数据
        private bool CreateData()
        {
            ItemAccess itemAccess = new ItemAccess();

            #region 根据下拉列表框的选择结果判断选中了哪一年哪一月
            if (importY2014_ComboBoxItem.IsSelected)
            {
                year = 2014;
            }
            else if (importY2013_ComboBoxItem.IsSelected)
            {
                year = 2013;
            }
            else if (importY2012_ComboBoxItem.IsSelected)
            {
                year = 2012;
            }
            else if (importY2011_ComboBoxItem.IsSelected)
            {
                year = 2011;
            }
            else if (importY2010Less_ComboBoxItem.IsSelected)
            {
                year = 2010;
            }
            else
            {
                year = 0;
            }

            if (importM01_ComboBoxItem.IsSelected)
            {
                month = 1;
            }
            else if (importM02_ComboBoxItem.IsSelected)
            {
                month = 2;
            }
            else if (importM03_ComboBoxItem.IsSelected)
            {
                month = 3;
            }
            else if (importM04_ComboBoxItem.IsSelected)
            {
                month = 4;
            }
            else if (importM05_ComboBoxItem.IsSelected)
            {
                month = 5;
            }
            else if (importM06_ComboBoxItem.IsSelected)
            {
                month = 6;
            }
            else if (importM07_ComboBoxItem.IsSelected)
            {
                month = 7;
            }
            else if (importM08_ComboBoxItem.IsSelected)
            {
                month = 8;
            }
            else if (importM09_ComboBoxItem.IsSelected)
            {
                month = 9;
            }
            else if (importM10_ComboBoxItem.IsSelected)
            {
                month = 10;
            }
            else if (importM11_ComboBoxItem.IsSelected)
            {
                month = 11;
            }
            else if (importM12_ComboBoxItem.IsSelected)
            {
                month = 12;
            }
            else
            {
                month = 0;
            }
            #endregion

            if (year == 0 || month == 0) 
            {
                if (year == 0)
                {
                    MessageBox.Show("请输入查询年份。");
                }
                else
                {
                    MessageBox.Show("请输入查询月份。");
                }
                return false;
            }

            name = itemAccess.GetDataWithTime("1", "ItemName", year, month);
            code = itemAccess.GetDataWithTime("1", "code", year, month);
            string[] strBuyingPrice = itemAccess.GetDataWithTime("1", "BuyingPrice", year, month);
            string[] strSellingPrice = itemAccess.GetDataWithTime("1", "SellingPrice", year, month);
            condition = itemAccess.GetDataWithTime("1", "Condition", year, month);
            remark = itemAccess.GetDataWithTime("1", "Remark", year, month);
            date = itemAccess.GetDataWithTime("1", "ManipulateTime", year, month);

            //在查询结果条目数为0时弹出提示并终止操作
            if (name[0] == "fail")
            {
                MessageBox.Show("该月份无商品入库记录，请重新选择查询时间。");
                return false;
            }

            //在查询结果条目数不为0时生成数组
            int length = name.Length;
            buyingprice = new double[length];
            sellingprice = new double[length];
            for (int i = 0; i < length; i++)
            {
                buyingprice[i] = Convert.ToDouble(strBuyingPrice[i]);
                sellingprice[i] = Convert.ToDouble(strSellingPrice[i]);
            }

            return true;
        }
        #endregion

        #region 点击“查询”按钮后对事件的操作
        private void DoQuery_Button_Click(object sender, RoutedEventArgs e)
		{
			List<dataStructForQueryByImportTime> datalist = new List<dataStructForQueryByImportTime>();

            if (!CreateData())
            {
                return;
            }

            for (int i = 0; i < name.Length; i++)
            {
                datalist.Add(new dataStructForQueryByImportTime(name[i], code[i], buyingprice[i], sellingprice[i], remark[i], date[i]));
            }

            QueryResult_DataGrid.ItemsSource = datalist;
            
        }
        #endregion

        #region 点击“导出到PDF”后对事件的操作
        private void ExportToPDF_Button_Click(object sender, RoutedEventArgs e)
        {
			string fileName = "";

            Document document = new Document();
            string fontDir = System.Environment.GetEnvironmentVariable("windir") + @"\fonts";
            System.Diagnostics.Debug.WriteLine(fontDir);

			System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
			sfd.Filter = "PDF文件 | *.pdf";
			sfd.InitialDirectory = System.Environment.CurrentDirectory;
			sfd.ShowDialog();
			fileName = sfd.FileName;
			sfd.RestoreDirectory = true;

            try
            {
				if (fileName == "")
				{
					return;
				}

                PdfWriter.getInstance(document, new FileStream(fileName, FileMode.OpenOrCreate));
                BaseFont bfont = BaseFont.createFont(fontDir + @"\simhei.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font headFont = new Font(bfont, 20);
                Font font = new Font(bfont, 12);

                document.Open();
                document.Add(new Paragraph("商品入库时间报表", headFont));

                Table toadd = new Table(6);
                toadd.DefaultVerticalAlignment = Element.ALIGN_CENTER;
                toadd.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
                toadd.AutoFillEmptyCells = true;
                toadd.addCell(new Paragraph("商品名称", font));
                toadd.addCell(new Paragraph("商品编码", font));
                toadd.addCell(new Paragraph("进价", font));
                toadd.addCell(new Paragraph("售价", font));
                toadd.addCell(new Paragraph("备注", font));
                toadd.addCell(new Paragraph("入库时间", font));

                for (int i = 0; i < name.Length; i++)
                {
                    toadd.addCell(new Paragraph(name[i], font));
                    toadd.addCell(new Paragraph(code[i], font));
                    toadd.addCell(new Paragraph(Convert.ToString(buyingprice[i]), font));
                    toadd.addCell(new Paragraph(Convert.ToString(sellingprice[i]), font));
                    toadd.addCell(new Paragraph(remark[i], font));
                    toadd.addCell(new Paragraph(date[i], font));
                }

                document.Add(toadd);

				document.Add(new Paragraph("制表人：" + MainWindow.currUserName, font));
				document.Add(new Paragraph(DateTime.Now.Date.ToString("yyyy-MM-dd")));
                document.Close();
            }
            catch (DocumentException de)
            {
                MessageBox.Show("无法写入PDF文件！" + de.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("无法写入PDF文件！" + ioe.Message);
            }

            MessageBox.Show("PDF文件已生成至" + fileName);
        }
        #endregion
    }

    #region 定义储存数据的结构体数组
    struct dataStructForQueryByImportTime
	{
		private string name;
		private string code;
		private double buyingprice;
		private double sellingprice;
		private string remark;
        private string date;

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

        public string pDate
        {
            get { return date; }
        }

		public dataStructForQueryByImportTime(string _name, string _code, double _buyingprice, double _sellingprice,string _remark, string _date)
		{
			name = _name;
			code = _code;
			buyingprice = _buyingprice;
			sellingprice = _sellingprice;
			remark = _remark;
            date = _date;
		}
	}
    #endregion
}
