using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class04，表示历史类书籍（0404）类商品
	/// </summary>
	sealed public class Class0404 : Class04
	{
		public Class0404()
		{
			FirstCategory = "04";
			SecondCategory = "0404";
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
