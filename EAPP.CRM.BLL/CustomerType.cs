//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// author: EAPP
// create date：2010-11-18 14:32:59
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace EAPP.CRM.BLL
{
    public class CustomerType
    {
		private static readonly EAPP.CRM.DAL.CustomerType DAL = new EAPP.CRM.DAL.CustomerType();
		
        /// <summary>
        /// 添加客户分类表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerTypeInfo info)
        {
			if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改客户分类表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerTypeInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.CustomerTypeInfo  GetItem(int infoId)
        {
			if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoId)
        {
			if (string.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 返回所有客户列表
        /// </summary>
        /// <returns>返回所有客户列表</returns>
        public DataTable GetList()
        {
            return DAL.GetList();
        }
    }
}
