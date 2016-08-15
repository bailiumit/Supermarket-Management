using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class01，表示移动电子产品（0103）类商品
	/// </summary>
	sealed public class Class0103 : Class01
	{
		/// <summary>
		/// 上市年份
		/// </summary>
		private int LaunchedYear;			//	上市年份

		public int pLaunchedYear
		{
			get { return LaunchedYear;}
			set { LaunchedYear = value; }
		}

		public Class0103()
		{
			FirstCategory = "01";
			SecondCategory = "0103";
		}

		new public string[] GetAllFields()
		{
			string[] res = new string[13];
			int i = 0;

			foreach (string str in base.GetAllFields())
			{
				res[i] = str;
				i++;
			}
			res[11] = Convert.ToString(LaunchedYear);
			res[12] = "";

			return res;
		}
	}
}
