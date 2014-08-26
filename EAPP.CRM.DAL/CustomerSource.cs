//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerSource.cs
// author: EAPP
// create date：2010-11-18 14:32:58
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
    public class CustomerSource
    {
		/// <summary>
        /// 插入客户来源
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerSourceInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@Source",info.Source),
					new SqlParameter("@Remark",info.Remark),
            };            
            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertCustomerSource", param);
        }
		
		/// <summary>
        /// 修改客户来源
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerSourceInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@SourceId",info.SourceId),
					new SqlParameter("@Source",info.Source),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateCustomerSource", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.CustomerSourceInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.CustomerSourceInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_CustomerSource"),
				new SqlParameter("@Where","SourceId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.CustomerSourceInfo();

					model.SourceId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["SourceId"].ToString());
					model.Source = rdr["Source"].ToString();
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
           return Utils.Delete("crm_CustomerSource","SourceId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有客户来源数据
        /// </summary>
        /// <returns>返回所有客户来源数据</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_CustomerSource", "", "");
        }
    }
}
