using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class04，表示美容类书籍（0402）类商品
	/// </summary>
	sealed public class Class0402 : Class04
	{
		public Class0402()
		{
			FirstCategory = "04";
			SecondCategory = "02";
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

			res[11] = "";
			res[12] = "";

			return res;
		}

	}
}
