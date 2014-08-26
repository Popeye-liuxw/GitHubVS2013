//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：BankAccount.cs
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
    public class BankAccount
    {
		/// <summary>
        /// 插入银行账户
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.BankAccountInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@AccountId",info.AccountId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@BankName",info.BankName),
					new SqlParameter("@AccountNumber",info.AccountNumber),
					new SqlParameter("@AccountName",info.AccountName),
					new SqlParameter("@RatepayingNumber",info.RatepayingNumber),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertBankAccount", param);
        }
		
		/// <summary>
        /// 修改银行账户
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.BankAccountInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@AccountId",info.AccountId),
					new SqlParameter("@CustomerId",info.CustomerId),
					new SqlParameter("@BankName",info.BankName),
					new SqlParameter("@AccountNumber",info.AccountNumber),
					new SqlParameter("@AccountName",info.AccountName),
					new SqlParameter("@RatepayingNumber",info.RatepayingNumber),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateBankAccount", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.BankAccountInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.BankAccountInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_BankAccount"),
				new SqlParameter("@Where","AccountId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.BankAccountInfo();

					model.AccountId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AccountId"].ToString());
					model.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["CustomerId"].ToString());
					model.BankName = rdr["BankName"].ToString();
					model.AccountNumber = rdr["AccountNumber"].ToString();
					model.AccountName = rdr["AccountName"].ToString();
					model.RatepayingNumber = rdr["RatepayingNumber"].ToString();
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
           return Utils.Delete("crm_BankAccount","AccountId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有银行账户
        /// </summary>
        /// <returns>返回所有银行账户</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_BankAccount", "", "");
        }
    }
}
