//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Role.cs
// author: EAPP
// create date：2009-12-2 18:34:54
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
    public class Role
    {
		/// <summary>
        /// 插入角色表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.RoleInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@RoleId",info.RoleId),
					new SqlParameter("@RoleName",info.RoleName),
					new SqlParameter("@PerentId",info.PerentId),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertRole", param);
        }
		
		/// <summary>
        /// 修改角色表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.RoleInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@RoleId",info.RoleId),
					new SqlParameter("@RoleName",info.RoleName),
					new SqlParameter("@PerentId",info.PerentId),
					new SqlParameter("@Remark",info.Remark),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateRole", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.RoleInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.RoleInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Role"),
				new SqlParameter("@Where","RoleId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.RoleInfo();

					model.RoleId = Convert.ToInt32(rdr["RoleId"].ToString());
					model.RoleName = rdr["RoleName"].ToString();
					model.PerentId = Convert.ToInt32(rdr["PerentId"].ToString());
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
           return Utils.Delete("crm_Role","RoleId in ("+ infoIds +")");		
        }
		
		public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_Role", "", "");
        }
    }
}
