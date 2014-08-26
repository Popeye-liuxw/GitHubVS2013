//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Contacts.cs
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
    public class Contacts
    {
        /// <summary>
        /// 插入联系人
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.ContactsInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@ContactId",info.ContactId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@CnName",info.CnName),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@NickName",info.NickName),
					new SqlParameter("@Salutation",info.Salutation),
					new SqlParameter("@Sex",info.Sex),
					new SqlParameter("@Email1",info.Email1),
					new SqlParameter("@Email2",info.Email2),
					new SqlParameter("@Tel",info.Tel),
					new SqlParameter("@MobilePhone",info.MobilePhone),
					new SqlParameter("@Fax",info.Fax),
					new SqlParameter("@IsMainContact",info.IsMainContact),
					new SqlParameter("@IM",info.IM),
					new SqlParameter("@Post",info.Post),
					new SqlParameter("@AreaId",info.AreaId),
					new SqlParameter("@Address",info.Address),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertContacts", param);
        }

        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.ContactsInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@ContactId",info.ContactId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@CnName",info.CnName),
					new SqlParameter("@EnName",info.EnName),
					new SqlParameter("@NickName",info.NickName),
					new SqlParameter("@Salutation",info.Salutation),
					new SqlParameter("@Sex",info.Sex),
					new SqlParameter("@Email1",info.Email1),
					new SqlParameter("@Email2",info.Email2),
					new SqlParameter("@Tel",info.Tel),
					new SqlParameter("@MobilePhone",info.MobilePhone),
					new SqlParameter("@Fax",info.Fax),
					new SqlParameter("@IsMainContact",info.IsMainContact),
					new SqlParameter("@IM",info.IM),
					new SqlParameter("@Post",info.Post),
					new SqlParameter("@AreaId",info.AreaId),
					new SqlParameter("@Address",info.Address),
					new SqlParameter("@Remark",info.Remark),
					new SqlParameter("@EnterUserId",info.EnterUserId),
					new SqlParameter("@ModifyUserId",info.ModifyUserId),
					new SqlParameter("@EnterDate",info.EnterDate),
					new SqlParameter("@ModifyDate",info.ModifyDate),
            };

            info.ContactId = EAPP.CRM.Common.MyConvert.GetInt32(param[0].Value.ToString());

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateContacts", param);
        }


        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.ContactsInfo GetItem(int infoId)
        {
            EAPP.CRM.Model.ContactsInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Contacts"),
				new SqlParameter("@Where","ContactId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.ContactsInfo();

                    model.ContactId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ContactId"].ToString());
                    model.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["CustomerId"].ToString());
                    model.CnName = rdr["CnName"].ToString();
                    model.EnName = rdr["EnName"].ToString();
                    model.NickName = rdr["NickName"].ToString();
                    model.Salutation = rdr["Salutation"].ToString();
                    model.Sex = rdr["Sex"].ToString();
                    model.Email1 = rdr["Email1"].ToString();
                    model.Email2 = rdr["Email2"].ToString();
                    model.Tel = rdr["Tel"].ToString();
                    model.MobilePhone = rdr["MobilePhone"].ToString();
                    model.Fax = rdr["Fax"].ToString();
                    model.IsMainContact = Convert.ToBoolean(rdr["IsMainContact"].ToString());
                    model.IM = rdr["IM"].ToString();
                    model.Post = rdr["Post"].ToString();
                    model.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AreaId"].ToString());
                    model.Address = rdr["Address"].ToString();
                    model.Remark = rdr["Remark"].ToString();
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
        public int Delete(string infoIds)
        {
            return Utils.Delete("crm_Contacts", "ContactId in (" + infoIds + ")");
        }

        /// <summary>
        /// 返回所有联系人信息
        /// </summary>
        /// <returns>返回所有联系人信息</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_Contacts", "", "");
        }

        public DataTable GetList(string strWhere)
        {
            return Utils.ExecuteTable("crm_Contacts", "", strWhere);
        }


        /// <summary>
        /// 联系人高级查询
        /// </summary>
        /// <param name="param">高级查询条件</param>
        /// <returns>返回联系人列表</returns>
        public DataTable Search(EAPP.CRM.Model.SearchContactsParameter param)
        {
            SqlParameter[] parame = new SqlParameter[] 
            {
                new SqlParameter("@name",param.ContactName),
                new SqlParameter("@customerName",param.CustomerName),
                new SqlParameter("@tel",param.Tel),
                new SqlParameter("@state",param.StateId),
                new SqlParameter("@trade",param.TradeId),
                new SqlParameter("@email",param.Email),
                new SqlParameter("@fields",param.Fields),
                new SqlParameter("@otherWhere",param.OtherWhere),
                new SqlParameter("@UserId",param.CurUserId)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "proc_SearchContacts", parame);
        }
    }
}
