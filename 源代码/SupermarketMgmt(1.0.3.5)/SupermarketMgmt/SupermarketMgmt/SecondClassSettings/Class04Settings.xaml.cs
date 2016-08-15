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
	/// Class04Settings.xaml 的交互逻辑
	/// </summary>
	public partial class Class04Settings : UserControl
	{
		public Class04Settings(Class04 book)
		{
			InitializeComponent();

			Binding itemNameBind = new Binding();
			itemNameBind.Source = book;
			itemNameBind.Path = new PropertyPath("pItemName");
			this.ItemName_TextBox.SetBinding(TextBox.TextProperty, itemNameBind);

			Binding codeBinding = new Binding();
			codeBinding.Source = book;
			codeBinding.Path = new PropertyPath("pCode");
			this.Code_TextBox.SetBinding(TextBox.TextProperty, codeBinding);

			Condition_ComboBox.DataContext = book;

			Binding buyingPriceBinding = new Binding();
			buyingPriceBinding.Source = book;
			buyingPriceBinding.Path = new PropertyPath("pBuyingPrice");
			this.BuyingPrice_TextBox.SetBinding(TextBox.TextProperty, buyingPriceBinding);

			Binding sellingPriceBinding = new Binding();
			sellingPriceBinding.Source = book;
			sellingPriceBinding.Path = new PropertyPath("pSellingPrice");
			this.SellingPrice_TextBox.SetBinding(TextBox.TextProperty, sellingPriceBinding);

			Binding remarkBinding = new Binding();
			remarkBinding.Source = book;
			remarkBinding.Path = new PropertyPath("pRemark");
			this.Remark_TextBox.SetBinding(TextBox.TextProperty, remarkBinding);

			Binding authorBinding = new Binding();
			authorBinding.Source = book;
			authorBinding.Path = new PropertyPath("pAuthor");
			this.Author_TextBox.SetBinding(TextBox.TextProperty, authorBinding);

			Binding publicHouseBinding = new Binding();
			publicHouseBinding.Source = book;
			publicHouseBinding.Path = new PropertyPath("pPublicHouse");
			this.PublicHouse_TextBox.SetBinding(TextBox.TextProperty, publicHouseBinding);
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