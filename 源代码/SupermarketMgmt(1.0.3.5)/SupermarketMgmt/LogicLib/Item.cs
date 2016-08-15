using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace LogicLib
{
	/// <summary>
	/// 为所有商品提供抽象基类
	/// </summary>
	abstract public class Item
	{
		#region Item基类成员变量
		/// <summary>
		/// 商品所属的一级分类
		/// </summary>
		protected string FirstCategory;		//	商品所属的一级分类

		/// <summary>
		/// 商品所属的二级分类
		/// </summary>
		protected string SecondCategory;		//	商品所属的二级分类

		/// <summary>
		/// 商品的编码
		/// </summary>
		protected string Code;					//	商品的编码

		/// <summary>
		/// 商品名
		/// </summary>
		protected string ItemName;				//	商品名

		/// <summary>
		/// 商品状态
		/// </summary>
		protected _Condition Condition;			//	商品状态

		/// <summary>
		/// 进价
		/// </summary>
		protected decimal BuyingPrice;			//	进价

		/// <summary>
		/// 售价
		/// </summary>
		protected decimal SellingPrice;			//	售价

		/// <summary>
		/// 售出季度
		/// </summary>
		protected _Quarter Quarter;				//	操作季度

		/// <summary>
		/// 备注，可填写退货信息等
		/// </summary>
		protected string Remark;				//	备注，可填写退货信息等

		protected DateTime time;
		#endregion

		protected Item()
		{
			Remark = null;
		}

		public string pFirstCategory
		{
			get { return FirstCategory; }
			set { FirstCategory = value; }
		}
		public string pSecondCategory
		{
			get { return SecondCategory; }
			set { SecondCategory = value; }
		}
		public string pCode
		{
			get { return Code; }
			set { Code = value; }
		}
		public string pItemName
		{
			get { return ItemName; }
			set { ItemName = value; }
		}
		public _Condition pCondition
		{
			get { return Condition; }
			set { Condition = value; }
		}
		public decimal pBuyingPrice
		{
			get { return BuyingPrice; }
			set { BuyingPrice = value; }
		}
		public decimal pSellingPrice
		{
			get { return SellingPrice; }
			set { SellingPrice = value; }
		}
		public _Quarter pQuarter
		{
			get { return Quarter; }
			set { Quarter = value; }
		}
		public string pRemark
		{
			get { return Remark; }
			set { Remark = value; }
		}

		#region 基类方法

		protected virtual string[] GetAllFields()
		{
			string[] res = new string[9];

			res[0] = Convert.ToString(FirstCategory);
			res[1] = Convert.ToString(SecondCategory);
			res[2] = Convert.ToString(Code);
			res[3] = Convert.ToString(ItemName);
			res[4] = Convert.ToString(Convert.ToInt32(Condition));
			res[5] = Convert.ToString(BuyingPrice);
			res[6] = Convert.ToString(SellingPrice);
			res[7] = "0";
			res[8] = Convert.ToString(Remark);

			return res;
		}
		#endregion
	}
}