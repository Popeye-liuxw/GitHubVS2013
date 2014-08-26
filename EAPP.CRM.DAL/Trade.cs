//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Trade.cs
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
    public class Trade
    {
		/// <summary>
        /// 插入行业表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.TradeInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@TradeName",info.TradeName),
					new SqlParameter("@FlagName",info.FlagName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertTrade", param);
        }
		
		/// <summary>
        /// 修改行业表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.TradeInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@TradeId",info.TradeId),
					new SqlParameter("@TradeName",info.TradeName),
					new SqlParameter("@FlagName",info.FlagName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@OrderId",info.OrderId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateTrade", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.TradeInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.TradeInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Trade"),
				new SqlParameter("@Where","TradeId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.TradeInfo();

					model.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["TradeId"].ToString());
					model.TradeName = rdr["TradeName"].ToString();
					model.FlagName = rdr["FlagName"].ToString();
					model.ParentId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ParentId"].ToString());
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
           return Utils.Delete("crm_Trade","TradeId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回客户类型类表
        /// </summary>
        /// <returns>返回客户类型列表</returns>
        public DataTable GetList()
        {
            return Utils.ExecuteTable("crm_Trade", "", "");
        }
    }
}
