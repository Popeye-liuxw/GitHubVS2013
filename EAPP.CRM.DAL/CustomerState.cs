//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerState.cs
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
    public class CustomerState
    {
		/// <summary>
        /// 插入客户状态表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerStateInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@Name",info.Name),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertCustomerState", param);
        }
		
		/// <summary>
        /// 修改客户状态表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerStateInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@StateId",info.StateId),
					new SqlParameter("@Name",info.Name),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateCustomerState", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.CustomerStateInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.CustomerStateInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_CustomerState"),
				new SqlParameter("@Where","StateId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.CustomerStateInfo();

					model.StateId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["StateId"].ToString());
					model.Name = rdr["Name"].ToString();
					model.Remark = rdr["Remark"].ToString();
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
           return Utils.Delete("crm_CustomerState","StateId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有客户状态数据
        /// </summary>
        /// <returns>返回所有客户状态数据</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_CustomerState", "", "");
        }
    }
}
