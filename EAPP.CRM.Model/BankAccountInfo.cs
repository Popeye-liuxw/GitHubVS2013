//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BankAccount.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class BankAccountInfo
	{
		#region Data

		/// <summary>
		/// 账户Id
		/// </summary>
		private int accountId;
		
		/// <summary>
		/// 相关客户Id
		/// </summary>
		private int customerId;
		
		/// <summary>
		/// 开户行
		/// </summary>
		private string bankName;
		
		/// <summary>
		/// 账号
		/// </summary>
		private string accountNumber;
		
		/// <summary>
		/// 开户名称
		/// </summary>
		private string accountName;
		
		/// <summary>
		/// 纳税号
		/// </summary>
		private string ratepayingNumber;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 账户Id
		/// </summary>
		public int AccountId
		{
			get 
			{
				return this.accountId;
			}
			set 
			{
				this.accountId = value;
			}
		}

		/// <summary>
		/// 相关客户Id
		/// </summary>
		public int CustomerId
		{
			get 
			{
				return this.customerId;
			}
			set 
			{
				this.customerId = value;
			}
		}

		/// <summary>
		/// 开户行
		/// </summary>
		public string BankName
		{
			get 
			{
				return this.bankName;
			}
			set 
			{
				this.bankName = value;
			}
		}

		/// <summary>
		/// 账号
		/// </summary>
		public string AccountNumber
		{
			get 
			{
				return this.accountNumber;
			}
			set 
			{
				this.accountNumber = value;
			}
		}

		/// <summary>
		/// 开户名称
		/// </summary>
		public string AccountName
		{
			get 
			{
				return this.accountName;
			}
			set 
			{
				this.accountName = value;
			}
		}

		/// <summary>
		/// 纳税号
		/// </summary>
		public string RatepayingNumber
		{
			get 
			{
				return this.ratepayingNumber;
			}
			set 
			{
				this.ratepayingNumber = value;
			}
		}
	
		#endregion
	}
}
