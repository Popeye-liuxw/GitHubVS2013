//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// author: EAPP
// create date：2010-11-17 16:59:34
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace EAPP.CRM.BLL
{
    public class Customer
    {
		private static readonly EAPP.CRM.DAL.Customer DAL = new EAPP.CRM.DAL.Customer();
		
        /// <summary>
        /// 添加客户表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.CustomerInfo info)
        {
			if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改客户表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.CustomerInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }
        
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.CustomerInfo  GetItem(int infoId)
        {
			if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string  infoId)
        {
			if (string.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 根据条件返回客户列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>返回客户列表</returns>
        public DataTable GetList(string strWhere)
        {
            return DAL.GetList(strWhere);
        }

        /// <summary>
        /// 返回所有客户列表
        /// </summary>
        public DataTable Getlist() 
        {
            return GetList("");
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="ids">所选ID</param>
        /// <returns>返回影响行数</returns>
        public int DropInRecycle(string ids)
        {
            return DAL.DropInRecycle(ids);
        }

        /// <summary>
        /// 共享集合ids中的客户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ShareCustomers(string ids)
        {
            return DAL.ShareCustomers(ids);
        }

        /// <summary>
        /// 恢复回收站中的客户Id在Ids中的客户
        /// </summary>
        public int BackFromInRecycle(string ids)
        {
            return DAL.BackFromInRecycle(ids);
        }

        /// <summary>
        /// 客户高级查询
        /// </summary>
        /// <param name="param">高级查询条件</param>
        /// <returns>返回客户列表</returns>
        public DataTable Search(EAPP.CRM.Model.SearchCustomerParameter param)
        {
            return DAL.Search(param);
        }

        /// <summary>
        /// 分配客户
        /// </summary>
        /// <param name="parm">数组中，0为要分配的客户Id集合。index 1 为 分配类型(dept,user)。 index 2 分配给谁(用户编号，或者部门编号).</param>
        /// <returns>影响行数</returns>
        public int Assign(string[] parm)
        {
            return DAL.Assign(parm);
        }

        /// <summary>
        /// 根据所选地区进行分析统计
        /// </summary>
        /// <param name="areaId">所选地区ID</param>
        /// <returns>返回所选地区客户的分布数量级分布区域</returns>
        public DataTable AnalyseByArea(string areaId)
        {
            return DAL.AnalyseByArea(areaId);
        }

        public DataTable AnalyseByTrend(DateTime dateTime)
        {
            return DAL.AnalyseByTrend(dateTime);
        }

        public DataTable AnalyseByTrend(DateTime dateTime, string userId)
        {
            return DAL.AnalyseByTrend(dateTime, userId);
        }

        public DataTable AnalyseByArea(string AreaId, string userId)
        {
            return DAL.AnalyseByArea(AreaId, userId);
        }

        public DataTable Analyse(EAPP.CRM.Model.AnalyseCondition condition)
        {
            return DAL.Analyse(condition);
        }

        public DataTable AnalysebyAssign()
        {
            return DAL.AnalyseByAssign();
        }

        public DataTable ImportData(int userId)
        {
            return DAL.ImportData(userId);
        }
    }
}
