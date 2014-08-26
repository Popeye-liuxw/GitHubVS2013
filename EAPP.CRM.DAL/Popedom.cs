//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Popedom.cs
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
    public class Popedom
    {
		/// <summary>
        /// 插入权限表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.PopedomInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@PopedomId",info.PopedomId),
					new SqlParameter("@PopedomItem",info.PopedomItem),
					new SqlParameter("@IsAllow",info.IsAllow),
					new SqlParameter("@RoleId",info.RoleId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertPopedom", param);
        }
		
		/// <summary>
        /// 修改权限表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.PopedomInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@PopedomId",info.PopedomId),
					new SqlParameter("@PopedomItem",info.PopedomItem),
					new SqlParameter("@IsAllow",info.IsAllow),
					new SqlParameter("@RoleId",info.RoleId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdatePopedom", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.PopedomInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.PopedomInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Popedom"),
				new SqlParameter("@Where","PopedomId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.PopedomInfo();

					model.PopedomId = Convert.ToInt32(rdr["PopedomId"].ToString());
					model.PopedomItem = rdr["PopedomItem"].ToString();
					model.IsAllow = Convert.ToInt16(rdr["IsAllow"].ToString());
					model.RoleId = Convert.ToInt32(rdr["RoleId"].ToString());
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
           return Utils.Delete("crm_Popedom","PopedomId in ("+ infoIds +")");		
        }
		
		public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_Popedom", "", "");
        }

        public DataTable GetList(string rid)
        {
            return Utils.ExecuteTable("crm_Popedom", "", "RoleId=" + rid);
        }

        public int DeleteByRoleId(string rid)
        {
            return Utils.Delete("crm_Popedom", "RoleId=" + rid);
        }

        public IDictionary<string, bool> GetUserPopedom(EAPP.CRM.Model.UserInfo userInfo)
        {
            System.Collections.Generic.Dictionary<string, bool> popedom = new Dictionary<string, bool>();

            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@RoleId",userInfo.RoleId)
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_SelectUserPopedom", Parame))
            {
                while (rdr.Read())
                {
                    popedom.Add(rdr["PopedomItem"].ToString(), rdr["IsAllow"].ToString() == "0" ? false : true);
                }
            }
            return popedom;
        }
    }
}
