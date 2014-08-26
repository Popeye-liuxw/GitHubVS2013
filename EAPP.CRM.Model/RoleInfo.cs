//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Role.cs
// author: EAPP
// create date：2009-12-2 18:34:55
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class RoleInfo
	{
		#region Data

		/// <summary>
		/// 角色信息Id
		/// </summary>
		private int roleId;
		
		/// <summary>
		/// 角色名称
		/// </summary>
		private string roleName;
		
		/// <summary>
		/// 父级别Id
		/// </summary>
		private int perentId;
		
		/// <summary>
		/// 
		/// </summary>
		private string remark;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 角色信息Id
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

		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			get 
			{
				return this.roleName;
			}
			set 
			{
				this.roleName = value;
			}
		}

		/// <summary>
		/// 父级别Id
		/// </summary>
		public int PerentId
		{
			get 
			{
				return this.perentId;
			}
			set 
			{
				this.perentId = value;
			}
		}

		/// <summary>
		/// 
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
	
		#endregion
	}
}
