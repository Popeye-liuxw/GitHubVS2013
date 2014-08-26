//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Contacts.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class ContactsInfo
	{
		#region Data

		/// <summary>
		/// 联系人Id
		/// </summary>
		private int contactId;
		
		/// <summary>
		/// 所属客户Id
		/// </summary>
		private int customerId;
		
		/// <summary>
		/// 中文名称
		/// </summary>
		private string cnName;
		
		/// <summary>
		/// 
		/// </summary>
		private string enName;
		
		/// <summary>
		/// 昵称
		/// </summary>
		private string nickName;
		
		/// <summary>
		/// 称呼（先生小姐等）
		/// </summary>
		private string salutation;
		
		/// <summary>
		/// 性别（men：男，sales：女士）
		/// </summary>
		private string sex;
		
		/// <summary>
		/// 电子邮件1
		/// </summary>
		private string email1;
		
		/// <summary>
		/// 电子邮件2
		/// </summary>
		private string email2;
		
		/// <summary>
		/// 电话，多个之间用逗号隔开
		/// </summary>
		private string tel;
		
		/// <summary>
		/// 手机
		/// </summary>
		private string mobilePhone;
		
		/// <summary>
		/// 传真
		/// </summary>
		private string fax;
		
		/// <summary>
		/// 是否是主要联系人
		/// </summary>
		private bool isMainContact;
		
		/// <summary>
		/// 即时工具信息（如：QQ：1111111）
		/// </summary>
		private string iM;
		
		/// <summary>
		/// 职务
		/// </summary>
		private string post;
		
		/// <summary>
		/// 所在地区Id
		/// </summary>
		private int areaId;
		
		/// <summary>
		/// 详细地址
		/// </summary>
		private string address;
		
		/// <summary>
		/// 备注
		/// </summary>
		private string remark;
		
		/// <summary>
		/// 录入人Id
		/// </summary>
		private int enterUserId;
		
		/// <summary>
		/// 修改人Id
		/// </summary>
		private int modifyUserId;
		
		/// <summary>
		/// 录入日期
		/// </summary>
		private DateTime enterDate;
		
		/// <summary>
		/// 编辑日期
		/// </summary>
		private string modifyDate;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 联系人Id
		/// </summary>
		public int ContactId
		{
			get 
			{
				return this.contactId;
			}
			set 
			{
				this.contactId = value;
			}
		}

		/// <summary>
		/// 所属客户Id
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
		/// 中文名称
		/// </summary>
		public string CnName
		{
			get 
			{
				return this.cnName;
			}
			set 
			{
				this.cnName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string EnName
		{
			get 
			{
				return this.enName;
			}
			set 
			{
				this.enName = value;
			}
		}

		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName
		{
			get 
			{
				return this.nickName;
			}
			set 
			{
				this.nickName = value;
			}
		}

		/// <summary>
		/// 称呼（先生小姐等）
		/// </summary>
		public string Salutation
		{
			get 
			{
				return this.salutation;
			}
			set 
			{
				this.salutation = value;
			}
		}

		/// <summary>
		/// 性别（men：男，sales：女士）
		/// </summary>
		public string Sex
		{
			get 
			{
				return this.sex;
			}
			set 
			{
				this.sex = value;
			}
		}

		/// <summary>
		/// 电子邮件1
		/// </summary>
		public string Email1
		{
			get 
			{
				return this.email1;
			}
			set 
			{
				this.email1 = value;
			}
		}

		/// <summary>
		/// 电子邮件2
		/// </summary>
		public string Email2
		{
			get 
			{
				return this.email2;
			}
			set 
			{
				this.email2 = value;
			}
		}

		/// <summary>
		/// 电话，多个之间用逗号隔开
		/// </summary>
		public string Tel
		{
			get 
			{
				return this.tel;
			}
			set 
			{
				this.tel = value;
			}
		}

		/// <summary>
		/// 手机
		/// </summary>
		public string MobilePhone
		{
			get 
			{
				return this.mobilePhone;
			}
			set 
			{
				this.mobilePhone = value;
			}
		}

		/// <summary>
		/// 传真
		/// </summary>
		public string Fax
		{
			get 
			{
				return this.fax;
			}
			set 
			{
				this.fax = value;
			}
		}

		/// <summary>
		/// 是否是主要联系人
		/// </summary>
		public bool IsMainContact
		{
			get 
			{
				return this.isMainContact;
			}
			set 
			{
				this.isMainContact = value;
			}
		}

		/// <summary>
		/// 即时工具信息（如：QQ：1111111）
		/// </summary>
		public string IM
		{
			get 
			{
				return this.iM;
			}
			set 
			{
				this.iM = value;
			}
		}

		/// <summary>
		/// 职务
		/// </summary>
		public string Post
		{
			get 
			{
				return this.post;
			}
			set 
			{
				this.post = value;
			}
		}

		/// <summary>
		/// 所在地区Id
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
		/// 详细地址
		/// </summary>
		public string Address
		{
			get 
			{
				return this.address;
			}
			set 
			{
				this.address = value;
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
		/// 录入人Id
		/// </summary>
		public int EnterUserId
		{
			get 
			{
				return this.enterUserId;
			}
			set 
			{
				this.enterUserId = value;
			}
		}

		/// <summary>
		/// 修改人Id
		/// </summary>
		public int ModifyUserId
		{
			get 
			{
				return this.modifyUserId;
			}
			set 
			{
				this.modifyUserId = value;
			}
		}

		/// <summary>
		/// 录入日期
		/// </summary>
		public DateTime EnterDate
		{
			get 
			{
				return this.enterDate;
			}
			set 
			{
				this.enterDate = value;
			}
		}

		/// <summary>
		/// 编辑日期
		/// </summary>
		public string ModifyDate
		{
			get 
			{
				return this.modifyDate;
			}
			set 
			{
				this.modifyDate = value;
			}
		}
	
		#endregion
	}
}
