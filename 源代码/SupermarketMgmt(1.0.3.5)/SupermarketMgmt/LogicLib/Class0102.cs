using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LogicLib
{
	/// <summary>
	/// 继承自Class01，表示家用电器（0102）类商品
	/// </summary>
	sealed public class Class0102 : Class01
	{
		/// <summary>
		/// 能效指数，范围是1~5
		/// </summary>
		private int EnergyEfficiency;			//	能效指数，范围是1~5

		public int pEnergyEfficiency
		{
			get { return EnergyEfficiency; }
			set { EnergyEfficiency = value; }
		}

		public Class0102()
		{
			FirstCategory = "01";
			SecondCategory = "0102";
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
			res[11] = Convert.ToString(EnergyEfficiency);
			res[12] = "";

			return res;
		}
	}
}
