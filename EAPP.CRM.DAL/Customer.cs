//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Customer.cs
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
    public class Customer
    {
        /// <summary>
        /// 插入客户表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerInfo info)
        {
            SqlParameter customerId = new SqlParameter("@CustomerId", SqlDbType.Int);
            customerId.Direction = ParameterDirection.Output;
            SqlParameter[] param = new SqlParameter[]
            { 
                customerId,
				new SqlParameter("@Name",info.Name),
				new SqlParameter("@TypeId",info.TypeId),
				new SqlParameter("@TradeId",info.TradeId),
				new SqlParameter("@StateId",info.StateId),
				new SqlParameter("@EmployeeTotal",info.EmployeeTotal),
				new SqlParameter("@Source",info.Source),
                new SqlParameter("@SourceId",info.SourceId),
				new SqlParameter("@YearRevenue",info.YearRevenue),
				new SqlParameter("@Remark",info.Remark),
				new SqlParameter("@AreaId",info.AreaId),
				new SqlParameter("@Address",info.Address),
				new SqlParameter("@PostCode",info.PostCode),
				new SqlParameter("@Email",info.Email),
				new SqlParameter("@Tel",info.Tel),
				new SqlParameter("@Fax",info.Fax),
				new SqlParameter("@MobilePhone",info.MobilePhone),
				new SqlParameter("@HomePage",info.HomePage),
				new SqlParameter("@EnterDate",info.EnterDate),
				new SqlParameter("@ModifyDate",info.ModifyDate),
				new SqlParameter("@EnterUserId",info.EnterUserId),
				new SqlParameter("@ModifyUserId",info.ModifyUserId),
				new SqlParameter("@AssignObject",info.AssignObject),
				new SqlParameter("@AssignObjectId",info.AssignObjectId),
				new SqlParameter("@AssignDate",info.AssignDate),
				new SqlParameter("@IsShare",info.IsShare),
				new SqlParameter("@Deleted",info.Deleted),
            };

            int val = EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertCustomer", param);

            info.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(customerId.Value.ToString());

            return val;
        }

        /// <summary>
        /// 修改客户表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
				new SqlParameter("@CustomerId",info.CustomerId),
				new SqlParameter("@Name",info.Name),
				new SqlParameter("@TypeId",info.TypeId),
				new SqlParameter("@TradeId",info.TradeId),
				new SqlParameter("@StateId",info.StateId),
				new SqlParameter("@EmployeeTotal",info.EmployeeTotal),
				new SqlParameter("@Source",info.Source),
                new SqlParameter("@SourceId",info.SourceId),
				new SqlParameter("@YearRevenue",info.YearRevenue),
				new SqlParameter("@Remark",info.Remark),
				new SqlParameter("@AreaId",info.AreaId),
				new SqlParameter("@Address",info.Address),
				new SqlParameter("@PostCode",info.PostCode),
				new SqlParameter("@Email",info.Email),
				new SqlParameter("@Tel",info.Tel),
				new SqlParameter("@Fax",info.Fax),
				new SqlParameter("@MobilePhone",info.MobilePhone),
				new SqlParameter("@HomePage",info.HomePage),
				new SqlParameter("@EnterDate",info.EnterDate),
				new SqlParameter("@ModifyDate",info.ModifyDate),
				new SqlParameter("@EnterUserId",info.EnterUserId),
				new SqlParameter("@ModifyUserId",info.ModifyUserId),
				new SqlParameter("@AssignObject",info.AssignObject),
				new SqlParameter("@AssignObjectId",info.AssignObjectId),
				new SqlParameter("@AssignDate",info.AssignDate),
				new SqlParameter("@IsShare",info.IsShare),
				new SqlParameter("@Deleted",info.Deleted),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateCustomer", param);
        }


        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.CustomerInfo GetItem(int infoId)
        {
            EAPP.CRM.Model.CustomerInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Customer"),
				new SqlParameter("@Where","CustomerId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.CustomerInfo();

                    model.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["CustomerId"].ToString());
                    model.Name = rdr["Name"].ToString();
                    model.TypeId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["TypeId"].ToString());
                    model.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["TradeId"].ToString());
                    model.StateId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["StateId"].ToString());
                    model.EmployeeTotal = rdr["EmployeeTotal"].ToString();
                    model.Source = rdr["Source"].ToString();

                    model.SourceId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["SourceId"].ToString());

                    model.YearRevenue = rdr["YearRevenue"].ToString();
                    model.Remark = rdr["Remark"].ToString();
                    model.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AreaId"].ToString());
                    model.Address = rdr["Address"].ToString();
                    model.PostCode = rdr["PostCode"].ToString();
                    model.Email = rdr["Email"].ToString();
                    model.Tel = rdr["Tel"].ToString();
                    model.Fax = rdr["Fax"].ToString();
                    model.MobilePhone = rdr["MobilePhone"].ToString();
                    model.HomePage = rdr["HomePage"].ToString();
                    model.EnterDate = EAPP.CRM.Common.MyConvert.GetDateTime(rdr["EnterDate"].ToString());
                    model.ModifyDate = rdr["ModifyDate"].ToString();
                    model.EnterUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["EnterUserId"].ToString());
                    model.ModifyUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ModifyUserId"].ToString());
                    model.AssignObject = rdr["AssignObject"].ToString();
                    model.AssignObjectId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AssignObjectId"].ToString());
                    model.AssignDate = rdr["AssignDate"].ToString();


                    model.IsShare = Convert.ToBoolean(rdr["IsShare"].ToString());
                    model.Deleted = Convert.ToBoolean(rdr["Deleted"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string infoIds)
        {
            return Utils.Delete("crm_Customer", "CustomerId in (" + infoIds + ")");
        }

        /// <summary>
        /// 返回所有客户信息
        /// </summary>
        /// <returns>返回所有客户信息</returns>
        public DataTable GetList(string where)
        {
            return Utils.ExecuteTable("crm_Customer", "", where);
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="ids">所选id集合</param>
        /// <returns>影响行数</returns>
        public int DropInRecycle(string ids)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@ids",ids)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_DropInRecycleCustomer", parame);
        }

        /// <summary>
        /// 共享客户
        /// </summary>
        /// <param name="ids">所选客户Id集合</param>
        /// <returns>影响行数</returns>
        public int ShareCustomers(string ids)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@ids",ids)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_ShareCustomer", parame);
        }

        /// <summary>
        /// 从回收站恢复客户
        /// </summary>
        /// <param name="ids">客户编号</param>
        /// <returns>影响行数</returns>
        public int BackFromInRecycle(string ids)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@ids",ids)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_BackFromRecycleCustomer", parame);

        }

        /// <summary>
        /// 客户高级查询
        /// </summary>
        /// <param name="param">高级查询条件</param>
        /// <returns>返回客户列表</returns>
        public DataTable Search(EAPP.CRM.Model.SearchCustomerParameter param)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@customerName",param.CustomerName),
                new SqlParameter("@customerTypeId",param.TypeId),
                new SqlParameter("@areaId",param.AreaId),
                new SqlParameter("@customerTradeId",param.TradeId),
                new SqlParameter("@sourceId",param.SourceId),
                new SqlParameter("@customerContacts",param.Contacts),
                new SqlParameter("@customerAddress",param.Address),
                new SqlParameter("@customerTel",param.Tel),
                new SqlParameter("@customerMobilePhone",param.Mobile),
                new SqlParameter("@customerStateId",param.StateId),
                new SqlParameter("@curUserId",param.CurUserId),
                new SqlParameter("@fields",param.Fields),
                new SqlParameter("@otherWhere",param.OtherWhere),
                new SqlParameter("@cntimeStart",param.NearTiemStart),
                new SqlParameter("@cntimeEnd",param.NearTimeEnd),
                new SqlParameter("@nxtmStart",param.NextTimeStart),
                new SqlParameter("@nxtmEnd",param.NextTimeEnd),
                new SqlParameter("@assignStart",param.AssignDateStart),
                new SqlParameter("@assignEnd",param.AssignDateEnd)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_SearchCustomer", parame);
        }

        /// <summary>
        /// 分配客户
        /// </summary>
        /// <param name="parm">数组中，0为要分配的客户Id集合。index 1 为 分配类型(dept,user)。 index 2 分配给谁(用户编号，或者部门编号).</param>
        /// <returns>影响行数</returns>
        public int Assign(string[] parm)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@ids",parm[0]),
                new SqlParameter("@AssignObject",parm[1]),
                new SqlParameter("@AssignObjectId",parm[2])
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_AssignCustomer", parame);
        }

        public DataTable AnalyseByArea(string areaId)
        {
            SqlParameter[] parame = new SqlParameter[] 
            { 
                new SqlParameter("@AreaId", areaId) 
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_AnalyseByArea", parame);
        }

        public DataTable AnalyseByTrend(DateTime dateTime)
        {
            SqlParameter[] parame = new SqlParameter[] 
            { 
                new SqlParameter("@date", dateTime) 
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_AnalyseByTrend", parame);
        }

        public DataTable AnalyseByTrend(DateTime dateTime, string userId)
        {
            SqlParameter[] parame = new SqlParameter[]
            { 
                new SqlParameter("@UserId", userId)
                ,new SqlParameter("@date", dateTime)
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_AnalyseByTrend", parame);
        }

        public DataTable AnalyseByArea(string AreaId, string userId)
        {
            SqlParameter[] parame = new SqlParameter[] 
            { 
                new SqlParameter("@UserId", userId)
                ,new SqlParameter("@AreaId", AreaId)
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_AnalyseByArea", parame);
        }

        /// <summary>
        /// 根据用户编号和分析类型，获取分析结果
        /// </summary>
        public DataTable Analyse(EAPP.CRM.Model.AnalyseCondition condition)
        {
            SqlParameter[] parame = new SqlParameter[] 
            { 
                new SqlParameter("@AssignObjectId", condition.AssignObjectId) 
                ,new SqlParameter("@Type",(int)condition.AnalyseType)
                ,new SqlParameter("@AssignObject",condition.AssignObject)
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_Analyse", parame);
        }

        public DataTable AnalyseByAssign()
        {
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_AnalyseByAssign", null);
        }

        public DataTable ImportData(int userId)
        {
            SqlParameter[] parame = new SqlParameter[] 
            { 
                new SqlParameter("@UserId", userId)
            };
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_ImportCustomerData", parame);
        }
    }
}