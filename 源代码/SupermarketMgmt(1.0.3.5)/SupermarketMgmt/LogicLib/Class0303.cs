using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class03，表示干货食品（0303）类商品
	/// </summary>
	public sealed class Class0303 : Class03
	{
		public Class0303()
		{
			FirstCategory = "03";
			SecondCategory = "0303";
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
