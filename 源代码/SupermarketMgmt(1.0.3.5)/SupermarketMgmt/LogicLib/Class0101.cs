using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace LogicLib
{
	/// <summary>
	/// 继承自Class01，表示电脑（0101）类商品
	/// </summary>
	sealed public class Class0101 : Class01
	{
		/// <summary>
		/// CPU主频
		/// </summary>
		private double CpuFreq;			//	CPU主频（GHz）

		/// <summary>
		/// 内存大小（GB）
		/// </summary>
		private int Ram;				//	内存大小（GB）

		public double pCpuFreq
		{
			get { return CpuFreq; }
			set { CpuFreq = value; }
		}

		public int pRam
		{
			get { return Ram; }
			set { Ram = value; }
		}


		public Class0101()
		{
			FirstCategory = "01";
			SecondCategory = "0101";
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
			res[11] = Convert.ToString(CpuFreq);
			res[12] = Convert.ToString(Ram);

			return res;
		}
	}
}
