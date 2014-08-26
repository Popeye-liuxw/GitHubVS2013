//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CustomerType.cs
// author: EAPP
// create date：2010-11-18 14:32:59
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
    public class CustomerType
    {
		/// <summary>
        /// 插入客户分类表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerTypeInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@TypeName",info.TypeName),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertCustomerType", param);
        }
		
		/// <summary>
        /// 修改客户分类表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerTypeInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@TypeId",info.TypeId),
					new SqlParameter("@TypeName",info.TypeName),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateCustomerType", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.CustomerTypeInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.CustomerTypeInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_CustomerType"),
				new SqlParameter("@Where","TypeId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.CustomerTypeInfo();

					model.TypeId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["TypeId"].ToString());
					model.TypeName = rdr["TypeName"].ToString();
					model.Remark = rdr["Remark"].ToString();
					model.OrderId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["OrderId"].ToString());
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
           return Utils.Delete("crm_CustomerType","TypeId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回客户类型类表
        /// </summary>
        /// <returns>返回客户类型列表</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_CustomerType", "", "");
        }
    }
}
