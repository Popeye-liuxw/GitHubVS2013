//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Trade.cs
// author: EAPP
// create date：2010-11-18 14:32:59
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class TradeInfo
	{
		#region Data

		/// <summary>
		/// 行业信息id
		/// </summary>
		private int tradeId;
		
		/// <summary>
		/// 行业名称
		/// </summary>
		private string tradeName;
		
		/// <summary>
		/// 标识名称
		/// </summary>
		private string flagName;
		
		/// <summary>
		/// 父级ID
		/// </summary>
		private int parentId;
		
		/// <summary>
		/// 排序Id
		/// </summary>
		private int orderId;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 行业信息id
		/// </summary>
		public int TradeId
		{
			get 
			{
				return this.tradeId;
			}
			set 
			{
				this.tradeId = value;
			}
		}

		/// <summary>
		/// 行业名称
		/// </summary>
		public string TradeName
		{
			get 
			{
				return this.tradeName;
			}
			set 
			{
				this.tradeName = value;
			}
		}

		/// <summary>
		/// 标识名称
		/// </summary>
		public string FlagName
		{
			get 
			{
				return this.flagName;
			}
			set 
			{
				this.flagName = value;
			}
		}

		/// <summary>
		/// 父级ID
		/// </summary>
		public int ParentId
		{
			get 
			{
				return this.parentId;
			}
			set 
			{
				this.parentId = value;
			}
		}

		/// <summary>
		/// 排序Id
		/// </summary>
		public int OrderId
		{
			get 
			{
				return this.orderId;
			}
			set 
			{
				this.orderId = value;
			}
		}
	
		#endregion
	}
}
