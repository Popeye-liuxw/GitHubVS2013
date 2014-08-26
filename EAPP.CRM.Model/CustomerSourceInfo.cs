//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerSource.cs
// author: EAPP
// create date：2010-11-18 14:32:59
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class CustomerSourceInfo
	{
		#region Data

		/// <summary>
		/// 来源信息Id
		/// </summary>
		private int sourceId;
		
		/// <summary>
		/// 来源简述
		/// </summary>
		private string source;
		
		/// <summary>
		/// 备注信息
		/// </summary>
		private string remark;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 来源信息Id
		/// </summary>
		public int SourceId
		{
			get 
			{
				return this.sourceId;
			}
			set 
			{
				this.sourceId = value;
			}
		}

		/// <summary>
		/// 来源简述
		/// </summary>
		public string Source
		{
			get 
			{
				return this.source;
			}
			set 
			{
				this.source = value;
			}
		}

		/// <summary>
		/// 备注信息
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
