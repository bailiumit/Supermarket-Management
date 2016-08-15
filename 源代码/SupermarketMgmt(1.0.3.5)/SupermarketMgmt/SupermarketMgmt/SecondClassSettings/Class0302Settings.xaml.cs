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

namespace GUI.SecondClassSettings
{
	/// <summary>
	/// Class0302Settings.xaml 的交互逻辑
	/// </summary>
	public partial class Class0302Settings : UserControl
	{
		public Class0302Settings(Class0302 vegeFood)
		{
			InitializeComponent();

			Binding itemNameBind = new Binding();
			itemNameBind.Source = vegeFood;
			itemNameBind.Path = new PropertyPath("pItemName");
			this.ItemName_TextBox.SetBinding(TextBox.TextProperty, itemNameBind);

			Binding codeBinding = new Binding();
			codeBinding.Source = vegeFood;
			codeBinding.Path = new PropertyPath("pCode");
			this.Code_TextBox.SetBinding(TextBox.TextProperty, codeBinding);

			Condition_ComboBox.DataContext = vegeFood;

			Binding buyingPriceBinding = new Binding();
			buyingPriceBinding.Source = vegeFood;
			buyingPriceBinding.Path = new PropertyPath("pBuyingPrice");
			this.BuyingPrice_TextBox.SetBinding(TextBox.TextProperty, buyingPriceBinding);

			Binding sellingPriceBinding = new Binding();
			sellingPriceBinding.Source = vegeFood;
			sellingPriceBinding.Path = new PropertyPath("pSellingPrice");
			this.SellingPrice_TextBox.SetBinding(TextBox.TextProperty, sellingPriceBinding);

			Binding remarkBinding = new Binding();
			remarkBinding.Source = vegeFood;
			remarkBinding.Path = new PropertyPath("pRemark");
			this.Remark_TextBox.SetBinding(TextBox.TextProperty, remarkBinding);

			Binding qualityPeriodBinding = new Binding();
			qualityPeriodBinding.Source = vegeFood;
			qualityPeriodBinding.Path = new PropertyPath("pQualityPeriod");
			this.QualityPeriod_TextBox.SetBinding(TextBox.TextProperty, qualityPeriodBinding);

			Binding valuedNutritionBinding = new Binding();
			valuedNutritionBinding.Source = vegeFood;
			valuedNutritionBinding.Path = new PropertyPath("pValuedNutrition");
			this.ValuedNutrition_TextBox.SetBinding(TextBox.TextProperty, valuedNutritionBinding);
		}

		private void Condition_ComboBox_Loaded(object sender, RoutedEventArgs e)
		{
			List<_Condition> conditions = new List<_Condition>();

			conditions.Add(_Condition.入库);
			conditions.Add(_Condition.上架);
			conditions.Add(_Condition.售出);
			conditions.Add(_Condition.退回);

			ComboBox box = sender as ComboBox;
			box.ItemsSource = conditions;
		}
	}
}