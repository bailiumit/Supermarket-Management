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
using LogicLib;
using GUI.Window;
using System.Text.RegularExpressions;

namespace GUI.FunctionBlock.Query
{
	/// <summary>
	/// QueryBySingleItem.xaml 的交互逻辑
	/// </summary>
	public partial class QueryBySingleItem : UserControl
	{
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

		public QueryBySingleItem()
		{
			InitializeComponent();
		}

        #region 点击“查询”按钮后对事件的操作
        private void DoQuery_Button_Click(object sender, RoutedEventArgs e)
		{
            string n_code = ItemCode_TextBox.Text;
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
                return;
            }

			string firstClassCategory = queryResult[1];
			string secondClassCategory = queryResult[2];

            if (firstClassCategory == "01")
            {
                #region 显示电脑类信息
                if (secondClassCategory == "0101")
				{
					computerAppliance = new Class0101();

                    //获取数据
                    computerAppliance.pFirstCategory = firstClassCategory;
                    computerAppliance.pSecondCategory = secondClassCategory;
                    computerAppliance.pCode = queryResult[3];
                    computerAppliance.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            computerAppliance.pCondition = _Condition.入库;
                            break;
                        case "2":
                            computerAppliance.pCondition = _Condition.上架;
                            break;
                        case "3":
                            computerAppliance.pCondition = _Condition.售出;
                            break;
                        case "4":
                            computerAppliance.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    computerAppliance.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    computerAppliance.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    computerAppliance.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        computerAppliance.pGuarantee = Convert.ToInt16(queryResult[10]);
                    }
                    if (queryResult[12] != "")
                    {
                        computerAppliance.pCpuFreq = Convert.ToDouble(queryResult[12]);
                    }
                    if (queryResult[13] != "")
                    {
                        computerAppliance.pRam = Convert.ToInt16(queryResult[13]);
                    }

					/*向界面传参*/
					SecondClassSettings.Class0101Settings tempContent = new SecondClassSettings.Class0101Settings(computerAppliance);

					/*设置界面不可改动*/
					tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Guarantee_TextBox.IsEnabled = false;
                    tempContent.CpuFreq_TextBox.IsEnabled = false;
                    tempContent.RAM_TextBox.IsEnabled = false;

					QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示家用电器类信息
                if (secondClassCategory == "0102")
                {
                    householdAppliance = new Class0102();

                    //获取数据
                    householdAppliance.pFirstCategory = firstClassCategory;
                    householdAppliance.pSecondCategory = secondClassCategory;
                    householdAppliance.pCode = queryResult[3];
                    householdAppliance.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            householdAppliance.pCondition = _Condition.入库;
                            break;
                        case "2":
                            householdAppliance.pCondition = _Condition.上架;
                            break;
                        case "3":
                            householdAppliance.pCondition = _Condition.售出;
                            break;
                        case "4":
                            householdAppliance.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    householdAppliance.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    householdAppliance.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    householdAppliance.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        householdAppliance.pGuarantee = Convert.ToInt16(queryResult[10]);
                    }
                    if (queryResult[12] != "")
                    {
                        householdAppliance.pEnergyEfficiency = Convert.ToInt16(queryResult[12]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0102Settings tempContent = new SecondClassSettings.Class0102Settings(householdAppliance);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Guarantee_TextBox.IsEnabled = false;
                    tempContent.EnergyEfficiency_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示移动电子产品类信息
                if (secondClassCategory == "0103")
                {
                    mobileAppliance = new Class0103();

                    //获取数据
                    mobileAppliance.pFirstCategory = firstClassCategory;
                    mobileAppliance.pSecondCategory = secondClassCategory;
                    mobileAppliance.pCode = queryResult[3];
                    mobileAppliance.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            mobileAppliance.pCondition = _Condition.入库;
                            break;
                        case "2":
                            mobileAppliance.pCondition = _Condition.上架;
                            break;
                        case "3":
                            mobileAppliance.pCondition = _Condition.售出;
                            break;
                        case "4":
                            mobileAppliance.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    mobileAppliance.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    mobileAppliance.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    mobileAppliance.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        mobileAppliance.pGuarantee = Convert.ToInt16(queryResult[10]);
                    }
                    if (queryResult[12] != "")
                    {
                        mobileAppliance.pLaunchedYear = Convert.ToInt16(queryResult[12]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0103Settings tempContent = new SecondClassSettings.Class0103Settings(mobileAppliance);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Guarantee_TextBox.IsEnabled = false;
                    tempContent.LaunchedYear_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion
            }

            if (firstClassCategory == "02")
            {
                #region 显示日用品类信息
                if (secondClassCategory == "0201")
                {
                    commodityArticle = new Class0201();

                    //获取数据
                    commodityArticle.pFirstCategory = firstClassCategory;
                    commodityArticle.pSecondCategory = secondClassCategory;
                    commodityArticle.pCode = queryResult[3];
                    commodityArticle.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            commodityArticle.pCondition = _Condition.入库;
                            break;
                        case "2":
                            commodityArticle.pCondition = _Condition.上架;
                            break;
                        case "3":
                            commodityArticle.pCondition = _Condition.售出;
                            break;
                        case "4":
                            commodityArticle.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    commodityArticle.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    commodityArticle.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    commodityArticle.pRemark = queryResult[9];
                    commodityArticle.pNationality = queryResult[10];

                    /*向界面传参*/
                    SecondClassSettings.Class0201Settings tempContent = new SecondClassSettings.Class0201Settings(commodityArticle);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Nationality_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示玩具类信息
                if (secondClassCategory == "0202")
                {
                    toyArticle = new Class0202();

                    //获取数据
                    toyArticle.pFirstCategory = firstClassCategory;
                    toyArticle.pSecondCategory = secondClassCategory;
                    toyArticle.pCode = queryResult[3];
                    toyArticle.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            toyArticle.pCondition = _Condition.入库;
                            break;
                        case "2":
                            toyArticle.pCondition = _Condition.上架;
                            break;
                        case "3":
                            toyArticle.pCondition = _Condition.售出;
                            break;
                        case "4":
                            toyArticle.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    toyArticle.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    toyArticle.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    toyArticle.pRemark = queryResult[9];
                    toyArticle.pNationality = queryResult[10];
                    if (queryResult[12] != "")
                    {
                        toyArticle.pAgeAdapt = Convert.ToInt16(queryResult[12]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0202Settings tempContent = new SecondClassSettings.Class0202Settings(toyArticle);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Nationality_TextBox.IsEnabled = false;
                    tempContent.AgeAdapt_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示体育用品类信息
                if (secondClassCategory == "0203")
                {
                    sportArticle = new Class0203();

                    //获取数据
                    sportArticle.pFirstCategory = firstClassCategory;
                    sportArticle.pSecondCategory = secondClassCategory;
                    sportArticle.pCode = queryResult[3];
                    sportArticle.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            sportArticle.pCondition = _Condition.入库;
                            break;
                        case "2":
                            sportArticle.pCondition = _Condition.上架;
                            break;
                        case "3":
                            sportArticle.pCondition = _Condition.售出;
                            break;
                        case "4":
                            sportArticle.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    sportArticle.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    sportArticle.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    sportArticle.pRemark = queryResult[9];
                    sportArticle.pNationality = queryResult[10];
                    sportArticle.pBrand = queryResult[12];

                    /*向界面传参*/
                    SecondClassSettings.Class0203Settings tempContent = new SecondClassSettings.Class0203Settings(sportArticle);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Nationality_TextBox.IsEnabled = false;
                    tempContent.Brand_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion
            }

            if (firstClassCategory == "03")
            {
                #region 显示生鲜食品类信息
                if (secondClassCategory == "0301")
                {
                    freshFood = new Class0301();

                    //获取数据
                    freshFood.pFirstCategory = firstClassCategory;
                    freshFood.pSecondCategory = secondClassCategory;
                    freshFood.pCode = queryResult[3];
                    freshFood.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            freshFood.pCondition = _Condition.入库;
                            break;
                        case "2":
                            freshFood.pCondition = _Condition.上架;
                            break;
                        case "3":
                            freshFood.pCondition = _Condition.售出;
                            break;
                        case "4":
                            freshFood.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    freshFood.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    freshFood.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    freshFood.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        freshFood.pQualityPeriod = Convert.ToInt16(queryResult[10]);
                    }
                    if (queryResult[12] != "")
                    {
                        freshFood.pKeepTemperature = Convert.ToInt16(queryResult[12]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0301Settings tempContent = new SecondClassSettings.Class0301Settings(freshFood);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.QualityPeriod_TextBox.IsEnabled = false;
                    tempContent.KeepTemperature_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示果蔬食品类信息
                if (secondClassCategory == "0302")
                {
                    vegeFood = new Class0302();

                    //获取数据
                    vegeFood.pFirstCategory = firstClassCategory;
                    vegeFood.pSecondCategory = secondClassCategory;
                    vegeFood.pCode = queryResult[3];
                    vegeFood.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            vegeFood.pCondition = _Condition.入库;
                            break;
                        case "2":
                            vegeFood.pCondition = _Condition.上架;
                            break;
                        case "3":
                            vegeFood.pCondition = _Condition.售出;
                            break;
                        case "4":
                            vegeFood.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    vegeFood.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    vegeFood.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    vegeFood.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        vegeFood.pQualityPeriod = Convert.ToInt16(queryResult[10]);
                    }
                    if (queryResult[12] != "")
                    {
                        vegeFood.pValuedNutrition = Convert.ToString(queryResult[12]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0302Settings tempContent = new SecondClassSettings.Class0302Settings(vegeFood);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.QualityPeriod_TextBox.IsEnabled = false;
                    tempContent.ValuedNutrition_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示干货食品类信息
                if (secondClassCategory == "0303")
                {
                    dryFood = new Class0303();

                    //获取数据
                    dryFood.pFirstCategory = firstClassCategory;
                    dryFood.pSecondCategory = secondClassCategory;
                    dryFood.pCode = queryResult[3];
                    dryFood.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            dryFood.pCondition = _Condition.入库;
                            break;
                        case "2":
                            dryFood.pCondition = _Condition.上架;
                            break;
                        case "3":
                            dryFood.pCondition = _Condition.售出;
                            break;
                        case "4":
                            dryFood.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    dryFood.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    dryFood.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    dryFood.pRemark = queryResult[9];
                    if (queryResult[10] != "")
                    {
                        dryFood.pQualityPeriod = Convert.ToInt16(queryResult[10]);
                    }

                    /*向界面传参*/
                    SecondClassSettings.Class0303Settings tempContent = new SecondClassSettings.Class0303Settings(dryFood);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.QualityPeriod_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion
            }

            if (firstClassCategory == "04")
            {
                #region 显示育儿书籍类信息
                if (secondClassCategory == "0401")
                {
                    parentingBook = new Class0401();

                    //获取数据
                    parentingBook.pFirstCategory = firstClassCategory;
                    parentingBook.pSecondCategory = secondClassCategory;
                    parentingBook.pCode = queryResult[3];
                    parentingBook.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            parentingBook.pCondition = _Condition.入库;
                            break;
                        case "2":
                            parentingBook.pCondition = _Condition.上架;
                            break;
                        case "3":
                            parentingBook.pCondition = _Condition.售出;
                            break;
                        case "4":
                            parentingBook.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    parentingBook.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    parentingBook.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    parentingBook.pRemark = queryResult[9];
                    parentingBook.pAuthor = queryResult[10];
                    parentingBook.pPublicHouse = queryResult[11];

                    /*向界面传参*/
                    SecondClassSettings.Class04Settings tempContent = new SecondClassSettings.Class04Settings(parentingBook);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Author_TextBox.IsEnabled = false;
                    tempContent.PublicHouse_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示美容书籍类信息
                if (secondClassCategory == "0402")
                {
                    beautyBook = new Class0402();

                    //获取数据
                    beautyBook.pFirstCategory = firstClassCategory;
                    beautyBook.pSecondCategory = secondClassCategory;
                    beautyBook.pCode = queryResult[3];
                    beautyBook.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            beautyBook.pCondition = _Condition.入库;
                            break;
                        case "2":
                            beautyBook.pCondition = _Condition.上架;
                            break;
                        case "3":
                            beautyBook.pCondition = _Condition.售出;
                            break;
                        case "4":
                            beautyBook.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    beautyBook.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    beautyBook.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    beautyBook.pRemark = queryResult[9];
                    beautyBook.pAuthor = queryResult[10];
                    beautyBook.pPublicHouse = queryResult[11];

                    /*向界面传参*/
                    SecondClassSettings.Class04Settings tempContent = new SecondClassSettings.Class04Settings(beautyBook);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Author_TextBox.IsEnabled = false;
                    tempContent.PublicHouse_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示文学书籍类信息
                if (secondClassCategory == "0403")
                {
                    literatureBook = new Class0403();

                    //获取数据
                    literatureBook.pFirstCategory = firstClassCategory;
                    literatureBook.pSecondCategory = secondClassCategory;
                    literatureBook.pCode = queryResult[3];
                    literatureBook.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            literatureBook.pCondition = _Condition.入库;
                            break;
                        case "2":
                            literatureBook.pCondition = _Condition.上架;
                            break;
                        case "3":
                            literatureBook.pCondition = _Condition.售出;
                            break;
                        case "4":
                            literatureBook.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    literatureBook.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    literatureBook.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    literatureBook.pRemark = queryResult[9];
                    literatureBook.pAuthor = queryResult[10];
                    literatureBook.pPublicHouse = queryResult[11];

                    /*向界面传参*/
                    SecondClassSettings.Class04Settings tempContent = new SecondClassSettings.Class04Settings(literatureBook);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Author_TextBox.IsEnabled = false;
                    tempContent.PublicHouse_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion

                #region 显示历史书籍类信息
                if (secondClassCategory == "0404")
                {
                    historyBook = new Class0404();

                    //获取数据
                    historyBook.pFirstCategory = firstClassCategory;
                    historyBook.pSecondCategory = secondClassCategory;
                    historyBook.pCode = queryResult[3];
                    historyBook.pItemName = queryResult[4];
                    switch (queryResult[5])
                    {
                        case "1":
                            historyBook.pCondition = _Condition.入库;
                            break;
                        case "2":
                            historyBook.pCondition = _Condition.上架;
                            break;
                        case "3":
                            historyBook.pCondition = _Condition.售出;
                            break;
                        case "4":
                            historyBook.pCondition = _Condition.退回;
                            break;
                        default:
                            break;
                    }
                    historyBook.pBuyingPrice = Convert.ToDecimal(queryResult[6]);
                    historyBook.pSellingPrice = Convert.ToDecimal(queryResult[7]);
                    historyBook.pRemark = queryResult[9];
                    historyBook.pAuthor = queryResult[10];
                    historyBook.pPublicHouse = queryResult[11];

                    /*向界面传参*/
                    SecondClassSettings.Class04Settings tempContent = new SecondClassSettings.Class04Settings(historyBook);

                    /*设置界面不可改动*/
                    tempContent.ItemName_TextBox.IsEnabled = false;
                    tempContent.Code_TextBox.IsEnabled = false;
                    tempContent.Condition_ComboBox.IsEnabled = false;
                    tempContent.BuyingPrice_TextBox.IsEnabled = false;
                    tempContent.SellingPrice_TextBox.IsEnabled = false;
                    tempContent.Remark_TextBox.IsEnabled = false;
                    tempContent.Author_TextBox.IsEnabled = false;
                    tempContent.PublicHouse_TextBox.IsEnabled = false;

                    QueryResultPad.Content = tempContent;
                }
                #endregion
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
