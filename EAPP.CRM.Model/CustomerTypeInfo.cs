//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerType.cs
// author: EAPP
// create date：2010-11-18 14:32:59
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class CustomerTypeInfo
	{
		#region Data

		/// <summary>
		/// 分类Id
		/// </summary>
		private int typeId;
		
		/// <summary>
		/// 分类名称
		/// </summary>
		private string typeName;
		
		/// <summary>
		/// 备注
		/// </summary>
		private string remark;
		
		/// <summary>
		/// 排序Id
		/// </summary>
		private int orderId;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 分类Id
		/// </summary>
		public int TypeId
		{
			get 
			{
				return this.typeId;
			}
			set 
			{
				this.typeId = value;
			}
		}

		/// <summary>
		/// 分类名称
		/// </summary>
		public string TypeName
		{
			get 
			{
				return this.typeName;
			}
			set 
			{
				this.typeName = value;
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			get 
			{
				return this.remark;
			}
			set 
			{
				this.remark = value;
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
