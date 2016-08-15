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
	/// Class0101Settings.xaml 的交互逻辑
	/// </summary>
	public partial class Class0101Settings : UserControl
	{
		public Class0101Settings(Class0101 computerAppliance)
		{
			InitializeComponent();

			Binding itemNameBind = new Binding();
			itemNameBind.Source = computerAppliance;
			itemNameBind.Path = new PropertyPath("pItemName");
			this.ItemName_TextBox.SetBinding(TextBox.TextProperty, itemNameBind);

			Binding codeBinding = new Binding();
			codeBinding.Source = computerAppliance;
			codeBinding.Path = new PropertyPath("pCode");
			this.Code_TextBox.SetBinding(TextBox.TextProperty, codeBinding);

			Condition_ComboBox.DataContext = computerAppliance;

			Binding buyingPriceBinding = new Binding();
			buyingPriceBinding.Source = computerAppliance;
			buyingPriceBinding.Path = new PropertyPath("pBuyingPrice");
			this.BuyingPrice_TextBox.SetBinding(TextBox.TextProperty, buyingPriceBinding);

			Binding sellingPriceBinding = new Binding();
			sellingPriceBinding.Source = computerAppliance;
			sellingPriceBinding.Path = new PropertyPath("pSellingPrice");
			this.SellingPrice_TextBox.SetBinding(TextBox.TextProperty, sellingPriceBinding);

			Binding remarkBinding = new Binding();
			remarkBinding.Source = computerAppliance;
			remarkBinding.Path = new PropertyPath("pRemark");
			this.Remark_TextBox.SetBinding(TextBox.TextProperty, remarkBinding);

			Binding guaranteeBinding = new Binding();
			guaranteeBinding.Source = computerAppliance;
			guaranteeBinding.Path = new PropertyPath("pGuarantee");
			this.Guarantee_TextBox.SetBinding(TextBox.TextProperty, guaranteeBinding);

			Binding cpuFreqBinding = new Binding();
			cpuFreqBinding.Source = computerAppliance;
			cpuFreqBinding.Path = new PropertyPath("pCpuFreq");
			this.CpuFreq_TextBox.SetBinding(TextBox.TextProperty, cpuFreqBinding);

			Binding ramBinding = new Binding();
			ramBinding.Source = computerAppliance;
			ramBinding.Path = new PropertyPath("pRam");
			this.RAM_TextBox.SetBinding(TextBox.TextProperty, ramBinding);
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