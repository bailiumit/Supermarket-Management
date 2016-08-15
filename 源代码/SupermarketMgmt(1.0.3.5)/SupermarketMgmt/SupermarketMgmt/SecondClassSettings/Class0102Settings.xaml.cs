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
	/// Class0102Settings.xaml 的交互逻辑
	/// </summary>
	public partial class Class0102Settings : UserControl
	{
		public Class0102Settings(Class0102 householdAppliance)
		{
			InitializeComponent();

			Binding itemNameBind = new Binding();
			itemNameBind.Source = householdAppliance;
			itemNameBind.Path = new PropertyPath("pItemName");
			this.ItemName_TextBox.SetBinding(TextBox.TextProperty, itemNameBind);

			Binding codeBinding = new Binding();
			codeBinding.Source = householdAppliance;
			codeBinding.Path = new PropertyPath("pCode");
			this.Code_TextBox.SetBinding(TextBox.TextProperty, codeBinding);

			Condition_ComboBox.DataContext = householdAppliance;

			Binding buyingPriceBinding = new Binding();
			buyingPriceBinding.Source = householdAppliance;
			buyingPriceBinding.Path = new PropertyPath("pBuyingPrice");
			this.BuyingPrice_TextBox.SetBinding(TextBox.TextProperty, buyingPriceBinding);

			Binding sellingPriceBinding = new Binding();
			sellingPriceBinding.Source = householdAppliance;
			sellingPriceBinding.Path = new PropertyPath("pSellingPrice");
			this.SellingPrice_TextBox.SetBinding(TextBox.TextProperty, sellingPriceBinding);

			Binding remarkBinding = new Binding();
			remarkBinding.Source = householdAppliance;
			remarkBinding.Path = new PropertyPath("pRemark");
			this.Remark_TextBox.SetBinding(TextBox.TextProperty, remarkBinding);

			Binding guaranteeBinding = new Binding();
			guaranteeBinding.Source = householdAppliance;
			guaranteeBinding.Path = new PropertyPath("pGuarantee");
			this.Guarantee_TextBox.SetBinding(TextBox.TextProperty, guaranteeBinding);

			Binding energyEfficiencyBinding = new Binding();
			energyEfficiencyBinding.Source = householdAppliance;
			energyEfficiencyBinding.Path = new PropertyPath("pEnergyEfficiency");
			this.EnergyEfficiency_TextBox.SetBinding(TextBox.TextProperty, energyEfficiencyBinding);
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
