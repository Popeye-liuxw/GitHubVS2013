//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：User.cs
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
    public class User
    {
		/// <summary>
        /// 插入用户表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.UserInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@LoginName",info.LoginName),
					new SqlParameter("@Password",info.Password),
					new SqlParameter("@Status",info.Status),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@CnName",info.CnName),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@IsAdmin",info.IsAdmin),
					new SqlParameter("@DeptId",info.DeptId),
					new SqlParameter("@Post",info.Post),
					new SqlParameter("@WorkPhone",info.WorkPhone),
					new SqlParameter("@HomePhone",info.HomePhone),
					new SqlParameter("@MobilePhone",info.MobilePhone),
					new SqlParameter("@Fax",info.Fax),
					new SqlParameter("@Email1",info.Email1),
					new SqlParameter("@Email2",info.Email2),
					new SqlParameter("@IM",info.IM),
					new SqlParameter("@IdCard",info.IdCard),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@AreaId",info.AreaId),
					new SqlParameter("@Address",info.Address),
                    new SqlParameter("@RoleId",info.RoleId)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertUser", param);
        }
		
		/// <summary>
        /// 修改用户表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.UserInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@UserId",info.UserId),
					new SqlParameter("@LoginName",info.LoginName),
					new SqlParameter("@Password",info.Password),
					new SqlParameter("@Status",info.Status),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@CnName",info.CnName),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@IsAdmin",info.IsAdmin),
					new SqlParameter("@DeptId",info.DeptId),
					new SqlParameter("@Post",info.Post),
					new SqlParameter("@WorkPhone",info.WorkPhone),
					new SqlParameter("@HomePhone",info.HomePhone),
					new SqlParameter("@MobilePhone",info.MobilePhone),
					new SqlParameter("@Fax",info.Fax),
					new SqlParameter("@Email1",info.Email1),
					new SqlParameter("@Email2",info.Email2),
					new SqlParameter("@IM",info.IM),
					new SqlParameter("@IdCard",info.IdCard),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@AreaId",info.AreaId),
					new SqlParameter("@Address",info.Address),
                    new SqlParameter("@RoleId",info.RoleId)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateUser", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.UserInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.UserInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_User"),
				new SqlParameter("@Where","UserId = " + infoId),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.UserInfo();

					model.UserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["UserId"].ToString());
					model.LoginName = rdr["LoginName"].ToString();
					model.Password = rdr["Password"].ToString();
					model.Status = EAPP.CRM.Common.MyConvert.GetInt32(rdr["Status"].ToString());
					model.EnterDate = EAPP.CRM.Common.MyConvert.GetDateTime(rdr["EnterDate"].ToString());
                    model.ModifyDate = rdr["ModifyDate"].ToString();
					model.EnterUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["EnterUserId"].ToString());
					model.ModifyUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ModifyUserId"].ToString());
					model.CnName = rdr["CnName"].ToString();
					model.EnName = rdr["EnName"].ToString();
					model.IsAdmin = Convert.ToBoolean(rdr["IsAdmin"].ToString());
					model.DeptId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["DeptId"].ToString());
					model.Post = rdr["Post"].ToString();
					model.WorkPhone = rdr["WorkPhone"].ToString();
					model.HomePhone = rdr["HomePhone"].ToString();
					model.MobilePhone = rdr["MobilePhone"].ToString();
					model.Fax = rdr["Fax"].ToString();
					model.Email1 = rdr["Email1"].ToString();
					model.Email2 = rdr["Email2"].ToString();
					model.IM = rdr["IM"].ToString();
					model.IdCard = rdr["IdCard"].ToString();
					model.Remark = rdr["Remark"].ToString();
					model.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AreaId"].ToString());
					model.Address = rdr["Address"].ToString();
                    model.RoleId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["RoleId"].ToString());
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
           return Utils.Delete("crm_User","UserId in ("+ infoIds +")");		
        }


        /// <summary>
        /// 根据登陆名获取实体对象
        /// </summary>
        /// <param name="userName">登录名</param>
        /// <returns>返回用户信息实体</returns>
        public EAPP.CRM.Model.UserInfo GetItem(string userName)
        {
            EAPP.CRM.Model.UserInfo model = null;

            if (string.IsNullOrEmpty(userName)) return model;

            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_User"),
				new SqlParameter("@Where","LoginName = '" + userName + "'"),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.UserInfo();

                    model.UserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["UserId"].ToString());
                    model.LoginName = rdr["LoginName"].ToString();
                    model.Password = rdr["Password"].ToString();
                    model.Status = EAPP.CRM.Common.MyConvert.GetInt32(rdr["Status"].ToString());
                    model.EnterDate = EAPP.CRM.Common.MyConvert.GetDateTime(rdr["EnterDate"].ToString());
                    model.ModifyDate = rdr["ModifyDate"].ToString();
                    model.EnterUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["EnterUserId"].ToString());
                    model.ModifyUserId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ModifyUserId"].ToString());
                    model.CnName = rdr["CnName"].ToString();
                    model.EnName = rdr["EnName"].ToString();
                    model.IsAdmin = Convert.ToBoolean(rdr["IsAdmin"].ToString());
                    model.DeptId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["DeptId"].ToString());
                    model.Post = rdr["Post"].ToString();
                    model.WorkPhone = rdr["WorkPhone"].ToString();
                    model.HomePhone = rdr["HomePhone"].ToString();
                    model.MobilePhone = rdr["MobilePhone"].ToString();
                    model.Fax = rdr["Fax"].ToString();
                    model.Email1 = rdr["Email1"].ToString();
                    model.Email2 = rdr["Email2"].ToString();
                    model.IM = rdr["IM"].ToString();
                    model.IdCard = rdr["IdCard"].ToString();
                    model.Remark = rdr["Remark"].ToString();
                    model.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AreaId"].ToString());
                    model.Address = rdr["Address"].ToString();
                    model.RoleId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["RoleId"].ToString());
                }
            }
            return model; 
        }

        /// <summary>
        /// 返回所有用户信息
        /// </summary>
        /// <returns>返回所有用户信息</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_User", "", "");
        }
    }
}
