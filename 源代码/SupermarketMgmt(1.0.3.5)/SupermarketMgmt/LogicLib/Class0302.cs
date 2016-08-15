using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class03，表示果蔬食品（0302）类商品
	/// </summary>

	sealed public class Class0302 : Class03
	{
		/// <summary>
		/// 该种果蔬富含的营养元素
		/// </summary>
		private string ValuedNutrition;			//	该种果蔬富含的营养元素

		public string pValuedNutrition
		{
			get { return ValuedNutrition; }
			set { ValuedNutrition = value; }
		}

		public Class0302()
		{
			FirstCategory = "03";
			SecondCategory = "0302";
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

			res[11] = Convert.ToString(ValuedNutrition);
			res[12] = "";

			return res;
		}
	}
}
