//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：Area.cs
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
    public class Area
    {
		/// <summary>
        /// 插入地区表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.AreaInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
					new SqlParameter("@AreaName",info.AreaName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@OrderId",info.OrderId),
					new SqlParameter("@FullId",info.FullId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_InsertArea", param);
        }
		
		/// <summary>
        /// 修改地区表
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.AreaInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@AreaId",info.AreaId),
					new SqlParameter("@AreaName",info.AreaName),
					new SqlParameter("@ParentId",info.ParentId),
					new SqlParameter("@OrderId",info.OrderId),
					new SqlParameter("@FullId",info.FullId),
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "proc_UpdateArea", param);
        }


		 /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public EAPP.CRM.Model.AreaInfo  GetItem(int infoId)
        {
            EAPP.CRM.Model.AreaInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","crm_Area"),
				new SqlParameter("@Where","AreaId = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = EAPP.CRM.DataAccess.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "proc_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new EAPP.CRM.Model.AreaInfo();

					model.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["AreaId"].ToString());
					model.AreaName = rdr["AreaName"].ToString();
					model.ParentId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["ParentId"].ToString());
					model.OrderId = EAPP.CRM.Common.MyConvert.GetInt32(rdr["OrderId"].ToString());
					model.FullId = rdr["FullId"].ToString();
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
           return Utils.Delete("crm_Area","AreaId in ("+ infoIds +")");		
        }

        /// <summary>
        /// 返回所有地区
        /// </summary>
        /// <returns>返回所有地区</returns>
        public DataTable GetList()
        {
            return GetList("", "");
        }

        /// <summary>
        /// 返回所有地区
        /// </summary>
        /// <returns>返回所有地区</returns>
        public DataTable GetList(string cols,string where)
        {
            return Utils.ExecuteTable("crm_Area", cols, where);
        }

        /// <summary>
        /// 根据地区父节点编号，获取数据列表
        /// </summary>
        /// <param name="id">父节点编号</param>
        /// <returns>返回父节点为id的所有数据</returns>
        public DataTable GetItemByParentId(string id)
        {
            return Utils.ExecuteTable("crm_Area", "", "ParentId = " + id);
        }
    }
}
