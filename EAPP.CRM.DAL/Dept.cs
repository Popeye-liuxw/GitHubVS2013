//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Dept.cs
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
    public class Dept
    {
		/// <summary>
        /// 插入部门信息表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.DeptInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@DeptName",info.DeptName),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertDept", param);
        }
		
		/// <summary>
        /// 修改部门信息表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.DeptInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@DeptId",info.DeptId),
					new SqlParameter("@DeptName",info.DeptName),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateDept", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.DeptInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.DeptInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Dept"),
				new SqlParameter("@Where","DeptId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.DeptInfo();

					model.DeptId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["DeptId"].ToString());
					model.DeptName = rdr["DeptName"].ToString();
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
           return Utils.Delete("crm_Dept","DeptId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有部门信息
        /// </summary>
        /// <returns>返回所有部门信息</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_Dept", "", "");
        }
    }
}
