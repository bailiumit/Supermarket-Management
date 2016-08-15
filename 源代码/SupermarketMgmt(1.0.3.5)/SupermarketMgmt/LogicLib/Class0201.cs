using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{	
	/// <summary>
	/// 继承自Class02，表示日用品（0201）类商品
	/// </summary>
	sealed public class Class0201 : Class02
	{
		public Class0201()
		{
			FirstCategory = "02";
			SecondCategory = "0201";
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
