using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{	
	/// <summary>
	/// 继承自Class02，表示玩具（0202）类商品
	/// </summary>
	sealed public class Class0202 : Class02
	{
		/// <summary>
		/// 该种玩具所适用的年龄
		/// </summary>
		private int AgeAdapt;			//	该种玩具所适用的年龄

		public int pAgeAdapt
		{
			get { return AgeAdapt; }
			set { AgeAdapt = value; }
		}


		public Class0202()
		{
			FirstCategory = "02";
			SecondCategory = "0202";
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

			res[11] = Convert.ToString(AgeAdapt);
			res[12] = "";

			return res;
		}
	}
}
