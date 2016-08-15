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
	/// StuffManagementt_MenuItem.xaml 的交互逻辑
	/// </summary>
	public partial class StuffManagementt : UserControl
	{
        public string positionChoice = "0";

		public StuffManagementt()
		{
			InitializeComponent();
		}

        #region “新建员工资料”栏对事件的操作
        //定义“新建员工资料”栏中“新建”按钮被按下后的事件操作
        private void neNew_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要新建该员工资料？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Stuff stuff = new Stuff(neStuffNumber_TextBox.Text, neStuffName_TextBox.Text, positionChoice,
                    neStuffPassword_TextBox.Text);
                StuffAccess stuffAccess = new StuffAccess();

                if (neStuffNumber_TextBox.Text == "")
                {
                    MessageBox.Show("工号不能为空，请您输入工号。");
                    return;
                }
                if (neStuffName_TextBox.Text == "")
                {
                    MessageBox.Show("姓名不能为空，请您输入姓名。");
                    return;
                }
                if (positionChoice == "0")
                {
                    MessageBox.Show("职务不能为空，请您选择职务。");
                    return;
                }
                if (neStuffPassword_TextBox.Text == "")
                {
                    MessageBox.Show("密码不能为空，请您输入密码。");
                    return;
                }
                if (stuffAccess.SingleQueryStuff(neStuffNumber_TextBox.Text)[1] != "fail")
                {
                    MessageBox.Show("您输入的工号已存在。为确保工号的唯一，请您重新输入工号。");
                    return;
                }
                if (!IsNumber(neStuffNumber_TextBox.Text))
                {
                    MessageBox.Show("检测到非法输入，请确保您输入的工号为数字。");
                    return;
                }

                stuffAccess.AddStuff(stuff);
            }
        }

        private void neLV1_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "1";
        }

        private void neLV2_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "2";
        }

        private void neLV3_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "3";
        }
        #endregion

        #region “修改员工资料”栏对事件的操作
        //定义“修改员工资料”栏中“查找”按钮被按下后的事件操作
        private void upSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            string n_number = upStuffNumberSearch_TextBox.Text;
            string[] queryResult = new string[5];
            StuffAccess stuffAccess = new StuffAccess();

            if (n_number == "")
            {
                MessageBox.Show("请输入工号。");
                return;
            }
            if (!IsNumber(n_number))
            {
                MessageBox.Show("检测到非法输入，请确保您输入的工号为数字。");
                return;
            }

            queryResult = stuffAccess.SingleQueryStuff(n_number);
            if (queryResult[1] == "fail")
            {
                MessageBox.Show("您要查找的数据不存在，请重新输入！");
            }
            else
            {
                upStuffNumber_TextBox.Text = queryResult[1];
                upStuffName_TextBox.Text = queryResult[2];
                switch (queryResult[3])
                {
                    case "1":
                        upLV1_RadioButton.IsChecked = true;
                        break;
                    case "2":
                        upLV2_RadioButton.IsChecked = true;
                        break;
                    case "3":
                        upLV3_RadioButton.IsChecked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        //定义“修改员工资料”栏中“修改”按钮被按下后的事件操作
        private void upChange_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要更新该员工信息？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string[] upCommand = new string[4];
                StuffAccess stuffAccess = new StuffAccess();

                upCommand[0] = upStuffNumberSearch_TextBox.Text;
                upCommand[1] = upStuffNumber_TextBox.Text;
                upCommand[2] = upStuffName_TextBox.Text;
                upCommand[3] = positionChoice;

                if (upCommand[1] == "")
                {
                    MessageBox.Show("工号不能为空，请您输入工号。");
                    return;
                }
                if (upCommand[2] == "")
                {
                    MessageBox.Show("姓名不能为空，请您输入姓名。");
                    return;
                }
                if ((stuffAccess.SingleQueryStuff(upCommand[1])[1]) != "fail" && upCommand[0] != upCommand[1])
                {
                    MessageBox.Show("您输入的工号已存在。为确保工号的唯一，请您重新输入工号。");
                    return;
                }
                if (!IsNumber(upCommand[1]))
                {
                    MessageBox.Show("检测到非法输入，请确保您输入的工号为数字。");
                    return;
                }

                stuffAccess.UpdateStuff(upCommand);
                upStuffNumberSearch_TextBox.Text = upStuffNumber_TextBox.Text; //更新搜索框的ID信息
            }
        }

        private void upLV1_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "1";
        }

        private void upLV2_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "2";
        }

        private void upLV3_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            positionChoice = "3";
        }
        #endregion
        
        #region “删除员工资料”栏对事件的操作
        //定义“删除员工资料”栏中“查找”按钮被按下后的事件操作
        private void deSearch_TextBox_Click(object sender, RoutedEventArgs e)
        {
            string n_number = deStuffNumberSearch_TextBox.Text;
            string[] queryResult = new string[5];
            StuffAccess stuffAccess = new StuffAccess();

            if (n_number == "")
            {
                MessageBox.Show("请输入工号。");
                return;
            }
            if (!IsNumber(n_number))
            {
                MessageBox.Show("检测到非法输入，请确保您输入的工号为数字。");
                return;
            }

            queryResult = stuffAccess.SingleQueryStuff(n_number);
            if (queryResult[1] == "fail")
            {
                MessageBox.Show("您要查找的数据不存在，请重新输入！");
            }
            else
            {
                deStuffNumber_TextBox.Text = queryResult[1];
                deStuffName_TextBox.Text = queryResult[2];
                switch (queryResult[3])
                {
                    case "1":
                        deStuffPosition_TextBox.Text = "仓库管理员";
                        break;
                    case "2":
                        deStuffPosition_TextBox.Text = "会计";
                        break;
                    case "3":
                        deStuffPosition_TextBox.Text = "经理";
                        break;
                    default:
                        break;
                }
            }
        }

        //定义“删除员工资料”栏中“删除”按钮被按下后的事件操作
        private void deDelete_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要删除该员工资料？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                string n_number = deStuffNumberSearch_TextBox.Text;
                StuffAccess stuffAccess = new StuffAccess();
                stuffAccess.DeleteStuff(n_number);

                //删除后将查询窗口信息置空
                deStuffNumber_TextBox.Text = "";
                deStuffName_TextBox.Text = "";
                deStuffPosition_TextBox.Text = "";
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
