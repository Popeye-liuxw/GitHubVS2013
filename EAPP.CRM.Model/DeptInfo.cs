//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Dept.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class DeptInfo
	{
		#region Data

		/// <summary>
		/// 部门Id
		/// </summary>
		private int deptId;
		
		/// <summary>
		/// 部门名称
		/// </summary>
		private string deptName;
		
		/// <summary>
		/// 说明
		/// </summary>
		private string remark;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 部门Id
		/// </summary>
		public int DeptId
		{
			get 
			{
				return this.deptId;
			}
			set 
			{
				this.deptId = value;
			}
		}

		/// <summary>
		/// 部门名称
		/// </summary>
		public string DeptName
		{
			get 
			{
				return this.deptName;
			}
			set 
			{
				this.deptName = value;
			}
		}

		/// <summary>
		/// 说明
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
