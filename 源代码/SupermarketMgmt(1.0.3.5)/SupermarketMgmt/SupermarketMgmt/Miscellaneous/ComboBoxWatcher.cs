using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GUI.Miscellaneous
{
	public delegate void ComboBoxEventHandler(ComboBoxItem selectedItem);

	/// <summary>
	/// 检测ComboBox选中的Item改变的类，主要为了实现ComboBoxItemChanged事件
	/// </summary>
	public class ComboBoxWatcher
	{
		public event ComboBoxEventHandler ComboBoxItemChanged;

		private DispatcherTimer MyTimer = new DispatcherTimer();
		private ComboBox watchedObj;
		private ComboBoxItem oldSelect;
		private ComboBoxItem currentSelect;

		/// <param name="watched">
		/// 表示被监视的Combobox
		/// </param>
		public ComboBoxWatcher(ComboBox watched)
		{
			MyTimer.Interval = new TimeSpan(1000);	//	每1000毫微秒检测watchedObj下哪一项被选中
			watchedObj = watched;
			currentSelect = SelfDefControls.CreateComboBoxItemWithContent("empty");
			MyTimer.Tick += new EventHandler(onTimeTick);	//	超时时，调用onTimeTick方法
			MyTimer.Start();
		}

		/// <summary>
		/// 轮询的方法检测watchedObj下哪一项被选中，并判断被选中项有无改变
		/// </summary>
		private void onTimeTick(object sender, EventArgs e)
		{
			foreach (ComboBoxItem item in watchedObj.Items)
			{
				if (item.IsSelected)
				{
					oldSelect = currentSelect;
					currentSelect = item;
				}
			}
			if (oldSelect != null && currentSelect != null)
			{
				if ((!oldSelect.Equals(currentSelect)) && (ComboBoxItemChanged != null))
				{
					ComboBoxItemChanged(currentSelect);
				}
			}
		}
	}
}
