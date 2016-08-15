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
using System.Diagnostics;
using GUI.Miscellaneous;
using GUI.Window;
using LogicLib;
using System.Collections;
using System.Text.RegularExpressions;

namespace GUI.FunctionBlock.Operation
{
	/// <summary>
	/// ItemManagement.xaml 的交互逻辑
	/// </summary>
	public partial class ItemManagement : UserControl
	{
		public ComboBoxWatcher FirstClassComboBoxWatcher;
		public ComboBoxWatcher SecondClassComboBoxWatcher;
		private ComboBoxItem firstClassSelectedItem;

		public static string firstClassSelectedItemString = null;
		public static int firstClassSelectedItemIndex = -1;

		public static string secondClassSelectedItemString = null;
		public static int secondClassSelectedItemIndex = -1;

		public ComboBoxItem[][] SecondClassItemList = new ComboBoxItem[4][];

        private Class0101 computerAppliance;
        private Class0102 householdAppliance;
        private Class0103 mobileAppliance;
        private Class0201 commodityArticle;
        private Class0202 toyArticle;
        private Class0203 sportArticle;
        private Class0301 freshFood;
        private Class0302 vegeFood;
        private Class0303 dryFood;
        private Class0401 parentingBook;
        private Class0402 beautyBook;
        private Class0403 literatureBook;
        private Class0404 historyBook;
      
		public ItemManagement()
		{
			InitializeComponent();
			FirstClassComboBoxWatcher = new ComboBoxWatcher(FirstClass_ComboBox);
			SecondClassComboBoxWatcher = new ComboBoxWatcher(SecondClass_ComboBox);
			FirstClassComboBoxWatcher.ComboBoxItemChanged += new ComboBoxEventHandler(firstClassComboBoxOnChange);
			SecondClassComboBoxWatcher.ComboBoxItemChanged += new ComboBoxEventHandler(secondClassComboBoxOnChange);

			SecondClassItemList[0] = new ComboBoxItem[3];
			SecondClassItemList[1] = new ComboBoxItem[3];
			SecondClassItemList[2] = new ComboBoxItem[3];
			SecondClassItemList[3] = new ComboBoxItem[4];
		}

        #region 大轮子
        private void firstClassComboBoxOnChange(ComboBoxItem selectedItem)
        {
            firstClassSelectedItem = selectedItem;
            firstClassSelectedItemIndex = FirstClass_ComboBox.SelectedIndex;
            firstClassSelectedItemString = selectedItem.ToString();
            SecondClass_ComboBox.Items.Clear();
            PropertyPad.Content = null;
            #region selectedItem == Class01
            if (selectedItem == Class01)
            {
                Debug.WriteLine(firstClassSelectedItemString);
                SecondClassItemList[0][0] = SelfDefControls.CreateComboBoxItemWithContent("电脑（0101）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[0][0]);
                SecondClassItemList[0][1] = SelfDefControls.CreateComboBoxItemWithContent("家用电器（0102）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[0][1]);
                SecondClassItemList[0][2] = SelfDefControls.CreateComboBoxItemWithContent("移动电子产品（0103）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[0][2]);
            }
            #endregion
            #region selectedItem == Class02
            if (selectedItem == Class02)
            {
                SecondClassItemList[1][0] = SelfDefControls.CreateComboBoxItemWithContent("日用品（0201）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[1][0]);
                SecondClassItemList[1][1] = SelfDefControls.CreateComboBoxItemWithContent("玩具（0202）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[1][1]);
                SecondClassItemList[1][2] = SelfDefControls.CreateComboBoxItemWithContent("体育用品（0203）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[1][2]);
            }
            #endregion
            #region selectedItem == Class03
            if (selectedItem == Class03)
            {
                SecondClassItemList[2][0] = SelfDefControls.CreateComboBoxItemWithContent("生鲜食品（0301）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[2][0]);
                SecondClassItemList[2][1] = SelfDefControls.CreateComboBoxItemWithContent("果蔬食品（0302）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[2][1]);
                SecondClassItemList[2][2] = SelfDefControls.CreateComboBoxItemWithContent("干货食品（0303）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[2][2]);
            }
            #endregion
            #region selectedItem == Class04
            if (selectedItem == Class04)
            {
                SecondClassItemList[3][0] = SelfDefControls.CreateComboBoxItemWithContent("育儿（0401）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[3][0]);
                SecondClassItemList[3][1] = SelfDefControls.CreateComboBoxItemWithContent("美容（0402）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[3][1]);
                SecondClassItemList[3][2] = SelfDefControls.CreateComboBoxItemWithContent("文学（0403）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[3][2]);
                SecondClassItemList[3][3] = SelfDefControls.CreateComboBoxItemWithContent("历史（0404）");
                SecondClass_ComboBox.Items.Add(SecondClassItemList[3][3]);
            }
            #endregion
        }

        private void secondClassComboBoxOnChange(ComboBoxItem selectedItem)
        {
            secondClassSelectedItemIndex = SecondClass_ComboBox.SelectedIndex;
            secondClassSelectedItemString = selectedItem.ToString();
            PropertyPad.Content = null;
            #region firstClassSelectedItem == Class01
            if (firstClassSelectedItem == Class01)
            {
                if (selectedItem == SecondClassItemList[0][0])
                {
                    Debug.WriteLine("Class0101 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    computerAppliance = new Class0101();
                    PropertyPad.Content = new SecondClassSettings.Class0101Settings(computerAppliance);
                }
                if (selectedItem == SecondClassItemList[0][1])
                {
                    Debug.WriteLine("Class0102 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    householdAppliance = new Class0102();
                    PropertyPad.Content = new SecondClassSettings.Class0102Settings(householdAppliance);
                }
                if (selectedItem == SecondClassItemList[0][2])
                {
                    Debug.WriteLine("Class0103 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    mobileAppliance = new Class0103();
                    PropertyPad.Content = new SecondClassSettings.Class0103Settings(mobileAppliance);
                }
            }
            #endregion
            #region firstClassSelectedItem == Class02
            if (firstClassSelectedItem == Class02)
            {
                if (selectedItem == SecondClassItemList[1][0])
                {
                    Debug.WriteLine("Class0201 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    commodityArticle = new Class0201();
                    PropertyPad.Content = new SecondClassSettings.Class0201Settings(commodityArticle);
                }
                if (selectedItem == SecondClassItemList[1][1])
                {
                    Debug.WriteLine("Class0202 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    toyArticle = new Class0202();
                    PropertyPad.Content = new SecondClassSettings.Class0202Settings(toyArticle);
                }
                if (selectedItem == SecondClassItemList[1][2])
                {
                    Debug.WriteLine("Class0203 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    sportArticle = new Class0203();
                    PropertyPad.Content = new SecondClassSettings.Class0203Settings(sportArticle);
                }
            }
            #endregion
            #region firstClassSelectedItem == Class03
            if (firstClassSelectedItem == Class03)
            {
                if (selectedItem == SecondClassItemList[2][0])
                {
                    Debug.WriteLine("Class0301 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    freshFood = new Class0301();
                    PropertyPad.Content = new SecondClassSettings.Class0301Settings(freshFood);
                }
                if (selectedItem == SecondClassItemList[2][1])
                {
                    Debug.WriteLine("Class0302 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    vegeFood = new Class0302();
                    PropertyPad.Content = new SecondClassSettings.Class0302Settings(vegeFood);
                }
                if (selectedItem == SecondClassItemList[2][2])
                {
                    Debug.WriteLine("Class0303 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    dryFood = new Class0303();
                    PropertyPad.Content = new SecondClassSettings.Class0303Settings(dryFood);
                }
            }
            #endregion
            #region firstClassSelectedItem == Class04
            if (firstClassSelectedItem == Class04)
            {
                if (selectedItem == SecondClassItemList[3][0])
                {
                    Debug.WriteLine("Class0401 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    parentingBook = new Class0401();
                    PropertyPad.Content = new SecondClassSettings.Class04Settings(parentingBook);
                }
                if (selectedItem == SecondClassItemList[3][1])
                {
                    Debug.WriteLine("Class0402 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    beautyBook = new Class0402();
                    PropertyPad.Content = new SecondClassSettings.Class04Settings(beautyBook);
                }
                if (selectedItem == SecondClassItemList[3][2])
                {
                    Debug.WriteLine("Class0403 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    literatureBook = new Class0403();
                    PropertyPad.Content = new SecondClassSettings.Class04Settings(literatureBook);
                }
                if (selectedItem == SecondClassItemList[3][3])
                {
                    Debug.WriteLine("Class0404 selected.");
                    Debug.WriteLine(secondClassSelectedItemString);
                    historyBook = new Class0404();
                    PropertyPad.Content = new SecondClassSettings.Class04Settings(historyBook);
                }
            }
            #endregion
        }
        #endregion

        #region “新建商品”栏对事件的操作
        //定义“新建商品”栏中“新建”按钮被按下后的事件操作
        private void neNew_Button_Click(object sender, RoutedEventArgs e)
        {
            ItemAccess itemAccess = new ItemAccess();
            string[] n_commandArray = new string[13];

            MessageBoxResult result = MessageBox.Show("确定要新建该商品信息？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                //在用户未选择商品类别时弹出提示并终止程序，保证程序的容错性
                if (firstClassSelectedItemIndex == -1)
                {
                    MessageBox.Show("请选择商品类别。");
                    return;
                }
                if (secondClassSelectedItemIndex == -1)
                {
                    MessageBox.Show("请选择商品类别。");
                    return;
                }

                //根据用户选择商品的种类的不同调用不同的函数
                switch (firstClassSelectedItemIndex)
                {
                    case 0:
                        switch (secondClassSelectedItemIndex)
                        {
                            case 0:
                                n_commandArray = computerAppliance.GetAllFields();
                                break;
                            case 1:
                                n_commandArray = householdAppliance.GetAllFields();
                                break;
                            case 2:
                                n_commandArray = mobileAppliance.GetAllFields();
                                break;
                            default:
                                MessageBox.Show("选取商品类别的功能出现故障！");
                                break;
                        }
                        break;
                    case 1:
                        switch (secondClassSelectedItemIndex)
                        {
                            case 0:
                                n_commandArray = commodityArticle.GetAllFields();
                                break;
                            case 1:
                                n_commandArray = toyArticle.GetAllFields();
                                break;
                            case 2:
                                n_commandArray = sportArticle.GetAllFields();
                                break;
                            default:
                                MessageBox.Show("选取商品类别的功能出现故障！");
                                break;
                        }
                        break;
                    case 2:
                        switch (secondClassSelectedItemIndex)
                        {
                            case 0:
                                n_commandArray = freshFood.GetAllFields();
                                break;
                            case 1:
                                n_commandArray = vegeFood.GetAllFields();
                                break;
                            case 2:
                                n_commandArray = dryFood.GetAllFields();
                                break;
                            default:
                                MessageBox.Show("选取商品类别的功能出现故障！");
                                break;
                        }
                        break;
                    case 3:
                        switch (secondClassSelectedItemIndex)
                        {
                            case 0:
                                n_commandArray = parentingBook.GetAllFields();
                                break;
                            case 1:
                                n_commandArray = beautyBook.GetAllFields();
                                break;
                            case 2:
                                n_commandArray = literatureBook.GetAllFields();
                                break;
                            case 3:
                                n_commandArray = historyBook.GetAllFields();
                                break;
                            default:
                                MessageBox.Show("选取商品类别的功能出现故障！");
                                break;
                        }
                        break;
                    default:
                        MessageBox.Show("选取商品类别的功能出现故障！");
                        break;
                }

                //在用户非法输入时弹出提示并终止程序，保证程序的容错性
                if (n_commandArray[3] == null)
                {
                    MessageBox.Show("请输入商品名称。");
                    return;
                }
                if (n_commandArray[2] == null)
                {
                    MessageBox.Show("请输入商品编码。");
                    return;
                }
                if (itemAccess.SingleQueryItem(n_commandArray[2])[1] != "fail")
                {
                    MessageBox.Show("商品编码与数据库中已有编码冲突，为保证商品编码的唯一性，请重新输入商品编码。");
                    return;
                }
                if (n_commandArray[4] == "0")
                {
                    MessageBox.Show("请选择商品状态。");
                    return;
                }
                if (n_commandArray[4] == "4" && n_commandArray[8] == null)
                {
                    MessageBox.Show("当商品状态为 退回 时要求填写退货原因，请填写退货原因。");
                    return;
                }
                if (!IsNumber(n_commandArray[2]))
                {
                    MessageBox.Show("检测到非法输入信息，请您确保商品编码、进价、售价的输入信息均为数字。");
                    return;
                }

                itemAccess.AddItem(n_commandArray);
            }
        }
        #endregion

        #region “更新商品信息”栏对事件的操作
        //定义“更新商品信息”栏中“查询”按钮被按下后的事件操作
        private void upSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            string n_code = upCodeSearch_TextBox.Text;
            ItemAccess itemAccess = new ItemAccess();

            if (n_code == "")
            {
                MessageBox.Show("请输入商品编码");
                return;
            }
            if (!IsNumber(n_code))
            {
                MessageBox.Show("检测到非法输入，请您确保商品编码为数字。");
                return;
            }

            string[] queryResult = itemAccess.SingleQueryItem(n_code);
            if (queryResult[1] == "fail")
            {
                MessageBox.Show("您要查找的数据不存在，请重新输入。");
            }
            else
            {
                upFirstCategory_TextBox.Text = queryResult[1];
                upSecondCategory_TextBox.Text = queryResult[2];
                upCode_TextBox.Text = queryResult[3];
                upItemName_TextBox.Text = queryResult[4];
                if (Convert.ToInt16(queryResult[5]) == 1)
                {
                    upCondition1_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 2)
                {
                    upCondition2_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 3)
                {
                    upCondition3_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 4)
                {
                    upCondition4_ComboBoxItem.IsSelected = true;
                }
                upBuyingPrice_TextBox.Text = queryResult[6];
                upSellingPrice_TextBox.Text = queryResult[7];
                upRemark_TextBox.Text = queryResult[9];
            }
        }

        //定义“更新”按钮被按下后的事件操作
        private void upChange_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要更新该商品信息？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string[] upCommand = new string[7];
                ItemAccess itemAccess = new ItemAccess();
                int exception = 0;

                upCommand[0] = upCodeSearch_TextBox.Text;
                upCommand[1] = upCode_TextBox.Text;
                upCommand[2] = upItemName_TextBox.Text;
                if (upCondition1_ComboBoxItem.IsSelected == true)
                {
                    upCommand[3] = "1";
                }
                if (upCondition2_ComboBoxItem.IsSelected == true)
                {
                    upCommand[3] = "2";
                }
                if (upCondition3_ComboBoxItem.IsSelected == true)
                {
                    upCommand[3] = "3";
                }
                if (upCondition4_ComboBoxItem.IsSelected == true)
                {
                    upCommand[3] = "4";
                }
                upCommand[4] = upBuyingPrice_TextBox.Text;
                upCommand[5] = upSellingPrice_TextBox.Text;
                upCommand[6] = upRemark_TextBox.Text;

                //当用户进行非法操作时，显示警告并终止程序，提升程序的容错性
                if (upCommand[1] == "")
                {
                    MessageBox.Show("商品编号不能为空，请您输入商品编号。");
                    return;
                }
                if (upCommand[2] == "")
                {
                    MessageBox.Show("商品名称不能为空，请您输入商品名称。");
                    return;
                }
                if ((itemAccess.SingleQueryItem(upCommand[1])[1]) != "fail" && exception != 1 && exception != 2 && upCommand[0] != upCommand[1])
                {
                    MessageBox.Show("您输入的商品编号已存在。为确保商品编号的唯一，请您重新输入商品编号。");
                    return;
                }
                if (upCommand[3] == "4" && upRemark_TextBox.Text == "")
                {
                    MessageBox.Show("退货原因不能为空，请填写在“备注”一栏填写退货原因。");
                    return;
                }
                if (!IsNumber(upCommand[1]))
                {
                    MessageBox.Show("检测到非法输入信息，请您确保商品编码、进价、售价的输入信息均为数字。");
                    return;
                }

                //当用户进行操作合法时，执行相关数据库操作语句
                itemAccess.UpdateItem(upCommand);
                upCodeSearch_TextBox.Text = upCode_TextBox.Text; //更新搜索框的ID信息
            }
        }
        #endregion

        #region “删除商品”栏对事件的操作
        //定义“删除商品”栏中“查询”按钮被按下后的事件操作
        private void deSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            string n_code = deCodeSearch_TextBox.Text;
            ItemAccess itemAccess = new ItemAccess();

            if (n_code == "")
            {
                MessageBox.Show("请输入商品编码。");
                return;
            }
            if (!IsNumber(n_code))
            {
                MessageBox.Show("检测到非法输入，请您确保商品编码为数字。");
                return;
            }

            string[] queryResult = itemAccess.SingleQueryItem(n_code);
            if (queryResult[1] == "fail")
            {
                MessageBox.Show("您要查找的数据不存在，请重新输入。");
            }
            else
            {
                deItemName_TextBox.Text = queryResult[4];
                if (Convert.ToInt16(queryResult[5]) == 1)
                {
                    deCondition1_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 2)
                {
                    deCondition2_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 3)
                {
                    deCondition3_ComboBoxItem.IsSelected = true;
                }
                if (Convert.ToInt16(queryResult[5]) == 4)
                {
                    deCondition4_ComboBoxItem.IsSelected = true;
                }
                deBuyingPrice_TextBox.Text = queryResult[6];
                deSellingPrice_TextBox.Text = queryResult[7];
                deRemark_TextBox.Text = queryResult[9];
            }
        }

        //定义“删除”按钮被按下后的事件操作
        private void deDelete_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要删除该商品信息？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string n_code = deCodeSearch_TextBox.Text;
                ItemAccess itemAccess = new ItemAccess();

                //删除后将查询窗口信息置空
                itemAccess.DeleteItem(n_code);
                deItemName_TextBox.Text = "";
                deCondition1_ComboBoxItem.IsSelected = false;
                deCondition2_ComboBoxItem.IsSelected = false;
                deCondition3_ComboBoxItem.IsSelected = false;
                deCondition4_ComboBoxItem.IsSelected = false;
                deBuyingPrice_TextBox.Text = "";
                deSellingPrice_TextBox.Text = "";
                deRemark_TextBox.Text = "";
            }
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
}
