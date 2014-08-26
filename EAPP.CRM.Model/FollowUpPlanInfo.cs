//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：FollowUpPlan.cs
// author: EAPP
// create date：2010-11-17 14:23:08
//
//------------------------------------------------------------------------------
using System;
namespace EAPP.CRM.Model
{
	public class FollowUpPlanInfo
	{
		#region Data

		/// <summary>
		/// 计划信息Id
		/// </summary>
		private int planId;
		
		/// <summary>
		/// 跟进客户Id
		/// </summary>
		private int customerId;
		
		/// <summary>
		/// 联系时间
		/// </summary>
		private DateTime contactTime;
		
		/// <summary>
		/// 联系人Id
		/// </summary>
		private int contactId;
		
		/// <summary>
		/// 联系方式
		/// </summary>
		private string contactInfo;
		
		/// <summary>
		/// 兴趣点
		/// </summary>
		private string interest;
		
		/// <summary>
		/// 异议点
		/// </summary>
		private string dissent;
		
		/// <summary>
		/// 当前计划状态（Planning：计划中，Processing：进行中，end：结束）
		/// </summary>
		private string planState;
		
		/// <summary>
		/// 跟踪后客户状态
		/// </summary>
		private int customerStateId;
		
		/// <summary>
		/// 跟进结果描述
		/// </summary>
		private string result;
		
		/// <summary>
		/// 下次更近时间
		/// </summary>
		private string nextTime;
		
		/// <summary>
		/// 下次跟进时机，既跟进点描述
		/// </summary>
		private string nextTiming;
		
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
		/// 修改日期
		/// </summary>
		private string modifyDate;
		
		 
		#endregion
		
		#region Properties
		
		/// <summary>
		/// 计划信息Id
		/// </summary>
		public int PlanId
		{
			get 
			{
				return this.planId;
			}
			set 
			{
				this.planId = value;
			}
		}

		/// <summary>
		/// 跟进客户Id
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
		/// 联系时间
		/// </summary>
		public DateTime ContactTime
		{
			get 
			{
				return this.contactTime;
			}
			set 
			{
				this.contactTime = value;
			}
		}

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
		/// 联系方式
		/// </summary>
		public string ContactInfo
		{
			get 
			{
				return this.contactInfo;
			}
			set 
			{
				this.contactInfo = value;
			}
		}

		/// <summary>
		/// 兴趣点
		/// </summary>
		public string Interest
		{
			get 
			{
				return this.interest;
			}
			set 
			{
				this.interest = value;
			}
		}

		/// <summary>
		/// 异议点
		/// </summary>
		public string Dissent
		{
			get 
			{
				return this.dissent;
			}
			set 
			{
				this.dissent = value;
			}
		}

		/// <summary>
		/// 当前计划状态（Planning：计划中，Processing：进行中，end：结束）
		/// </summary>
		public string PlanState
		{
			get 
			{
				return this.planState;
			}
			set 
			{
				this.planState = value;
			}
		}

		/// <summary>
		/// 跟踪后客户状态
		/// </summary>
		public int CustomerStateId
		{
			get 
			{
				return this.customerStateId;
			}
			set 
			{
				this.customerStateId = value;
			}
		}

		/// <summary>
		/// 跟进结果描述
		/// </summary>
		public string Result
		{
			get 
			{
				return this.result;
			}
			set 
			{
				this.result = value;
			}
		}

		/// <summary>
		/// 下次更近时间
		/// </summary>
		public string NextTime
		{
			get 
			{
				return this.nextTime;
			}
			set 
			{
				this.nextTime = value;
			}
		}

		/// <summary>
		/// 下次跟进时机，既跟进点描述
		/// </summary>
		public string NextTiming
		{
			get 
			{
				return this.nextTiming;
			}
			set 
			{
				this.nextTiming = value;
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
	
		#endregion
	}
}
