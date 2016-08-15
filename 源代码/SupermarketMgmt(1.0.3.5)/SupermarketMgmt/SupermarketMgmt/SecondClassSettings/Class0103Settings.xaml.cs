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
	/// Class0103Settings.xaml 的交互逻辑
	/// </summary>
	public partial class Class0103Settings : UserControl
	{
		public Class0103Settings(Class0103 mobileAppliance)
		{
			InitializeComponent();

			Binding itemNameBind = new Binding();
			itemNameBind.Source = mobileAppliance;
			itemNameBind.Path = new PropertyPath("pItemName");
			this.ItemName_TextBox.SetBinding(TextBox.TextProperty, itemNameBind);

			Binding codeBinding = new Binding();
			codeBinding.Source = mobileAppliance;
			codeBinding.Path = new PropertyPath("pCode");
			this.Code_TextBox.SetBinding(TextBox.TextProperty, codeBinding);

			Condition_ComboBox.DataContext = mobileAppliance;

			Binding buyingPriceBinding = new Binding();
			buyingPriceBinding.Source = mobileAppliance;
			buyingPriceBinding.Path = new PropertyPath("pBuyingPrice");
			this.BuyingPrice_TextBox.SetBinding(TextBox.TextProperty, buyingPriceBinding);

			Binding sellingPriceBinding = new Binding();
			sellingPriceBinding.Source = mobileAppliance;
			sellingPriceBinding.Path = new PropertyPath("pSellingPrice");
			this.SellingPrice_TextBox.SetBinding(TextBox.TextProperty, sellingPriceBinding);

			Binding remarkBinding = new Binding();
			remarkBinding.Source = mobileAppliance;
			remarkBinding.Path = new PropertyPath("pRemark");
			this.Remark_TextBox.SetBinding(TextBox.TextProperty, remarkBinding);

			Binding guaranteeBinding = new Binding();
			guaranteeBinding.Source = mobileAppliance;
			guaranteeBinding.Path = new PropertyPath("pGuarantee");
			this.Guarantee_TextBox.SetBinding(TextBox.TextProperty, guaranteeBinding);

			Binding launchedYearBinding = new Binding();
			launchedYearBinding.Source = mobileAppliance;
			launchedYearBinding.Path = new PropertyPath("pLaunchedYear");
			this.LaunchedYear_TextBox.SetBinding(TextBox.TextProperty, launchedYearBinding);
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
