//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerState.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class CustomerStateInfo
	{
		#region Data

		/// <summary>
		/// 状态Id
		/// </summary>
		private int stateId;
		
		/// <summary>
		/// 状态名称
		/// </summary>
		private string name;
		
		/// <summary>
		/// 备注
   
		/// </summary>
		private string remark;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 状态Id
		/// </summary>
		public int StateId
		{
			get 
			{
				return this.stateId;
			}
			set 
			{
				this.stateId = value;
			}
		}

		/// <summary>
		/// 状态名称
		/// </summary>
		public string Name
		{
			get 
			{
				return this.name;
			}
			set 
			{
				this.name = value;
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
	
		#endregion
	}
}
