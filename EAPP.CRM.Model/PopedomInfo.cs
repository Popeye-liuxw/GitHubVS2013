//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Popedom.cs
// author: EAPP
// create date：2009-12-2 18:34:55
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class PopedomInfo
	{
		#region Data

		/// <summary>
		/// 权限信息Id
		/// </summary>
		private int popedomId;
		
		/// <summary>
		/// 权限项(以唯一的表示代表一个操作)
		/// </summary>
		private string popedomItem;
		
		/// <summary>
		/// 是否允许（0：不允许，1：允许）
		/// </summary>
		private short isAllow;
		
		/// <summary>
		/// 角色Id
		/// </summary>
		private int roleId;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 权限信息Id
		/// </summary>
		public int PopedomId
		{
			get 
			{
				return this.popedomId;
			}
			set 
			{
				this.popedomId = value;
			}
		}

		/// <summary>
		/// 权限项(以唯一的表示代表一个操作)
		/// </summary>
		public string PopedomItem
		{
			get 
			{
				return this.popedomItem;
			}
			set 
			{
				this.popedomItem = value;
			}
		}

		/// <summary>
		/// 是否允许（0：不允许，1：允许）
		/// </summary>
		public short IsAllow
		{
			get 
			{
				return this.isAllow;
			}
			set 
			{
				this.isAllow = value;
			}
		}

		/// <summary>
		/// 角色Id
		/// </summary>
		public int RoleId
		{
			get 
			{
				return this.roleId;
			}
			set 
			{
				this.roleId = value;
			}
		}
	
		#endregion
	}
}
