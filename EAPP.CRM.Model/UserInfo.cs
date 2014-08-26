//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：User.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class UserInfo
	{
		#region Data

		/// <summary>
		/// 系统用户Id
		/// </summary>
		private int userId;
		
		/// <summary>
		/// 登录名称
		/// </summary>
		private string loginName;
		
		/// <summary>
		/// 登录密码（MD5加密）
		/// </summary>
		private string password;
		
		/// <summary>
		/// 账户状态（0：无效，1：有效）
		/// </summary>
		private int status;
		
		/// <summary>
		/// 录入时间
		/// </summary>
		private DateTime enterDate;
		
		/// <summary>
		/// 修改日期
		/// </summary>
		private string modifyDate;
		
		/// <summary>
		/// 录入用户Id
		/// </summary>
		private int enterUserId;
		
		/// <summary>
		/// 修改用户Id
		/// </summary>
		private int modifyUserId;
		
		/// <summary>
		/// 中文名
		/// </summary>
		private string cnName;
		
		/// <summary>
		/// 英文名称
		/// </summary>
		private string enName;
		
		/// <summary>
		/// 是否是管理账户
		/// </summary>
		private bool isAdmin = false;
		
		/// <summary>
		/// 所在部门Id
		/// </summary>
		private int deptId;
		
		/// <summary>
		/// 职位
		/// </summary>
		private string post;
		
		/// <summary>
		/// 工作电话
		/// </summary>
		private string workPhone;
		
		/// <summary>
		/// 家庭电话
		/// </summary>
		private string homePhone;
		
		/// <summary>
		/// 手机
		/// </summary>
		private string mobilePhone;
		
		/// <summary>
		/// 传真
		/// </summary>
		private string fax;
		
		/// <summary>
		/// 电子邮件1
		/// </summary>
		private string email1;
		
		/// <summary>
		/// 电子邮件2
		/// </summary>
		private string email2;
		
		/// <summary>
		/// 即时沟通工具帐号信息（如：QQ：1111111，MSN：name@mail.con）
		/// </summary>
		private string iM;
		
		/// <summary>
		/// 身份证号码
		/// </summary>
		private string idCard;
		
		/// <summary>
		/// 备注
		/// </summary>
		private string remark;
		
		/// <summary>
		/// 所在地区
		/// </summary>
		private int areaId;
		
		/// <summary>
		/// 详细地址
		/// </summary>
		private string address;

        /// <summary>
        /// 角色编号
        /// </summary>
        private int roleId;
        
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 系统用户Id
		/// </summary>
		public int UserId
		{
			get 
			{
				return this.userId;
			}
			set 
			{
				this.userId = value;
			}
		}

		/// <summary>
		/// 登录名称
		/// </summary>
		public string LoginName
		{
			get 
			{
				return this.loginName;
			}
			set 
			{
				this.loginName = value;
			}
		}

		/// <summary>
		/// 登录密码（MD5加密）
		/// </summary>
		public string Password
		{
			get 
			{
				return this.password;
			}
			set 
			{
				this.password = value;
			}
		}

		/// <summary>
		/// 账户状态（0：无效，1：有效）
		/// </summary>
		public int Status
		{
			get 
			{
				return this.status;
			}
			set 
			{
				this.status = value;
			}
		}

		/// <summary>
		/// 录入时间
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
		/// 修改日期
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

		/// <summary>
		/// 录入用户Id
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
		/// 修改用户Id
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
		/// 中文名
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
		/// 英文名称
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
		/// 是否是管理账户
		/// </summary>
		public bool IsAdmin
		{
			get 
			{
				return this.isAdmin;
			}
			set 
			{
				this.isAdmin = value;
			}
		}

		/// <summary>
		/// 所在部门Id
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
		/// 职位
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
		/// 工作电话
		/// </summary>
		public string WorkPhone
		{
			get 
			{
				return this.workPhone;
			}
			set 
			{
				this.workPhone = value;
			}
		}

		/// <summary>
		/// 家庭电话
		/// </summary>
		public string HomePhone
		{
			get 
			{
				return this.homePhone;
			}
			set 
			{
				this.homePhone = value;
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
		/// 即时沟通工具帐号信息（如：QQ：1111111，MSN：name@mail.con）
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
		/// 身份证号码
		/// </summary>
		public string IdCard
		{
			get 
			{
				return this.idCard;
			}
			set 
			{
				this.idCard = value;
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
		/// 所在地区
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
        /// 角色编号
        /// </summary>
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        } 
	
		#endregion
	}
}
