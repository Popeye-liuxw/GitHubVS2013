//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Customer.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class CustomerInfo
	{
		#region Data

		/// <summary>
		/// 客户Id
		/// </summary>
		private int customerId;
		
		/// <summary>
		/// 客户名称
		/// </summary>
		private string name;
		
		/// <summary>
		/// 客户分类Id
		/// </summary>
		private int typeId;
		
		/// <summary>
		/// 所在行业
		/// </summary>
		private int tradeId;
		
		/// <summary>
		/// 状态
		/// </summary>
		private int stateId;
		
		/// <summary>
		/// 员工人数
		/// </summary>
		private string employeeTotal;
		
		/// <summary>
		/// 客户来源
		/// </summary>
		private string source;

        /// <summary>
        /// 客户来源编号
        /// </summary>
        private int sourceId;

		/// <summary>
		/// 年收入
		/// </summary>
		private string yearRevenue;
		
		/// <summary>
		/// 备注
		/// </summary>
		private string remark;
		
		/// <summary>
		/// 地区Id
		/// </summary>
		private int areaId;
		
		/// <summary>
		/// 详细地址
		/// </summary>
		private string address;
		
		/// <summary>
		/// 
		/// </summary>
		private string postCode;
		
		/// <summary>
		/// 电子邮件
		/// </summary>
		private string email;
		
		/// <summary>
		/// 电话
		/// </summary>
		private string tel;
		
		/// <summary>
		/// 传真
		/// </summary>
		private string fax;
		
		/// <summary>
		/// 手机
		/// </summary>
		private string mobilePhone;
		
		/// <summary>
		/// 主页
		/// </summary>
		private string homePage;
		
		/// <summary>
		/// 录入时间
		/// </summary>
		private DateTime enterDate;
		
		/// <summary>
		/// 修改日期
		/// </summary>
		private string modifyDate;
		
		/// <summary>
		/// 录入人Id
		/// </summary>
		private int enterUserId;
		
		/// <summary>
		/// 修改人Id
		/// </summary>
		private int modifyUserId;
		
		/// <summary>
		/// 负责对象类型（user:用户，dept:部门）
		/// </summary>
		private string assignObject;
		
		/// <summary>
		/// 负责部门或用户Id
		/// </summary>
		private int assignObjectId;
		
		/// <summary>
		/// 开始负责日期
		/// </summary>
		private string assignDate;
		
		/// <summary>
		/// 是否共享
		/// </summary>
		private bool isShare;
		
		/// <summary>
		/// 是否已删除（放入回收站）
		/// </summary>
		private bool deleted;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 客户Id
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
		/// 客户名称
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
		/// 客户分类Id
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
		/// 所在行业
		/// </summary>
		public int TradeId
		{
			get 
			{
				return this.tradeId;
			}
			set 
			{
				this.tradeId = value;
			}
		}

		/// <summary>
		/// 状态
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
		/// 员工人数
		/// </summary>
		public string EmployeeTotal
		{
			get 
			{
				return this.employeeTotal;
			}
			set 
			{
				this.employeeTotal = value;
			}
		}

		/// <summary>
		/// 客户来源
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
        /// 客户来源编号
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
		/// 年收入
		/// </summary>
		public string YearRevenue
		{
			get 
			{
				return this.yearRevenue;
			}
			set 
			{
				this.yearRevenue = value;
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
		/// 地区Id
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
		/// 
		/// </summary>
		public string PostCode
		{
			get 
			{
				return this.postCode;
			}
			set 
			{
				this.postCode = value;
			}
		}

		/// <summary>
		/// 电子邮件
		/// </summary>
		public string Email
		{
			get 
			{
				return this.email;
			}
			set 
			{
				this.email = value;
			}
		}

		/// <summary>
		/// 电话
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
		/// 主页
		/// </summary>
		public string HomePage
		{
			get 
			{
				return this.homePage;
			}
			set 
			{
				this.homePage = value;
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
		/// 负责对象类型（user:用户，dept:部门）
		/// </summary>
		public string AssignObject
		{
			get 
			{
				return this.assignObject;
			}
			set 
			{
				this.assignObject = value;
			}
		}

		/// <summary>
		/// 负责部门或用户Id
		/// </summary>
		public int AssignObjectId
		{
			get 
			{
				return this.assignObjectId;
			}
			set 
			{
				this.assignObjectId = value;
			}
		}

		/// <summary>
		/// 开始负责日期
		/// </summary>
		public string AssignDate
		{
			get 
			{
				return this.assignDate;
			}
			set 
			{
				this.assignDate = value;
			}
		}

		/// <summary>
		/// 是否共享
		/// </summary>
		public bool IsShare
		{
			get 
			{
				return this.isShare;
			}
			set 
			{
				this.isShare = value;
			}
		}

		/// <summary>
		/// 是否已删除（放入回收站）
		/// </summary>
		public bool Deleted
		{
			get 
			{
				return this.deleted;
			}
			set 
			{
				this.deleted = value;
			}
		}
	
		#endregion
	}
}
