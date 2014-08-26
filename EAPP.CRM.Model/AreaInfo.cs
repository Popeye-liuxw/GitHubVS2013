//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Area.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class AreaInfo
	{
		#region Data

		/// <summary>
		/// 地区id
		/// </summary>
		private int areaId;
		
		/// <summary>
		/// 地区名称
		/// </summary>
		private string areaName;
		
		/// <summary>
		/// 上级地区Id
		/// </summary>
		private int parentId;
		
		/// <summary>
		/// 排序Id
		/// </summary>
		private int orderId;
		
		/// <summary>
		/// 完整Id（包括所有父级Id和当前Id的完整Id列表，多个之间用逗号隔开，左右分别加逗号）
		/// </summary>
		private string fullId;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 地区id
		/// </summary>
		public int AreaId
		{
			get 
			{
				return this.areaId;
			}
			set 
			{
				this.areaId = value;
			}
		}

		/// <summary>
		/// 地区名称
		/// </summary>
		public string AreaName
		{
			get 
			{
				return this.areaName;
			}
			set 
			{
				this.areaName = value;
			}
		}

		/// <summary>
		/// 上级地区Id
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

		/// <summary>
		/// 完整Id（包括所有父级Id和当前Id的完整Id列表，多个之间用逗号隔开，左右分别加逗号）
		/// </summary>
		public string FullId
		{
			get 
			{
				return this.fullId;
			}
			set 
			{
				this.fullId = value;
			}
		}
	
		#endregion
	}
}
