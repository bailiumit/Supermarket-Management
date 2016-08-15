using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace GUI.Miscellaneous
{
	public class SelfDefControls
	{
		public static ComboBoxItem CreateComboBoxItemWithContent(string content)
		{
			ComboBoxItem newItem = new ComboBoxItem();
			newItem.Content = content;

			return newItem;
		}
	}
}
