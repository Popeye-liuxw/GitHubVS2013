//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：FollowUpPlan.cs
// author: EAPP
// create date：2010-11-17 16:59:34
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EAPP.CRM.DAL
{
    public class FollowUpPlan
    {
		/// <summary>
        /// 插入客户跟进计划
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.FollowUpPlanInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@PlanId",info.PlanId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@ContactTime",info.ContactTime),
					new SqlParameter("@ContactId",info.ContactId),
					new SqlParameter("@ContactInfo",info.ContactInfo),
					new SqlParameter("@Interest",info.Interest),
					new SqlParameter("@Dissent",info.Dissent),
					new SqlParameter("@PlanState",info.PlanState),
					new SqlParameter("@CustomerStateId",info.CustomerStateId),
					new SqlParameter("@Result",info.Result),
					new SqlParameter("@NextTime",info.NextTime),
					new SqlParameter("@NextTiming",info.NextTiming),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertFollowUpPlan", param);
        }
		
		/// <summary>
        /// 修改客户跟进计划
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.FollowUpPlanInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@PlanId",info.PlanId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@ContactTime",info.ContactTime),
					new SqlParameter("@ContactId",info.ContactId),
					new SqlParameter("@ContactInfo",info.ContactInfo),
					new SqlParameter("@Interest",info.Interest),
					new SqlParameter("@Dissent",info.Dissent),
					new SqlParameter("@PlanState",info.PlanState),
					new SqlParameter("@CustomerStateId",info.CustomerStateId),
					new SqlParameter("@Result",info.Result),
					new SqlParameter("@NextTime",info.NextTime),
					new SqlParameter("@NextTiming",info.NextTiming),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateFollowUpPlan", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.FollowUpPlanInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.FollowUpPlanInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_FollowUpPlan"),
				new SqlParameter("@Where","PlanId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.FollowUpPlanInfo();

					model.PlanId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["PlanId"].ToString());
					model.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["CustomerId"].ToString());
					model.ContactTime = EAPP.CRM.Common.MyConvert.GetDateTime(rdr["ContactTime"].ToString());
					model.ContactId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ContactId"].ToString());
					model.ContactInfo = rdr["ContactInfo"].ToString();
					model.Interest = rdr["Interest"].ToString();
					model.Dissent = rdr["Dissent"].ToString();
					model.PlanState = rdr["PlanState"].ToString();
					model.CustomerStateId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["CustomerStateId"].ToString());
					model.Result = rdr["Result"].ToString();
					model.NextTime = rdr["NextTime"].ToString();
					model.NextTiming = rdr["NextTiming"].ToString();
					model.EnterUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["EnterUserId"].ToString());
					model.ModifyUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ModifyUserId"].ToString());
					model.EnterDate = EAPP.CRM.Common.MyConvert.GetDateTime(rdr["EnterDate"].ToString());
					model.ModifyDate = rdr["ModifyDate"].ToString();
                }
            }
            return model;
        }
		
		/// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoIds)
        {
           return Utils.Delete("crm_FollowUpPlan","PlanId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有用户跟进计划
        /// </summary>
        /// <returns>返回所有用户跟进计划</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_FollowUpPlan", "", "");
        }


        public DataTable GetList(string strWhere)
        {
            return Utils.ExecuteTable("crm_FollowUpPlan", "", strWhere);
        }
    }
}
