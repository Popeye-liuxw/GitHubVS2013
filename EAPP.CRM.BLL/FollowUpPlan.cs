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
    public class FollowUpPlan
    {
		private static readonly EAPP.CRM.DAL.FollowUpPlan DAL = new EAPP.CRM.DAL.FollowUpPlan();
		
        /// <summary>
        /// 添加客户跟进计划
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.FollowUpPlanInfo info)
        {
			if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改客户跟进计划
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.FollowUpPlanInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.FollowUpPlanInfo  GetItem(int infoId)
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
        /// 根据条件获取跟进计划列表
        /// </summary>
        /// <param name="strWhere">获取条件</param>
        /// <returns>返回跟进计划列表</returns>
        public DataTable GetList(string strWhere)
        {
            return DAL.GetList(strWhere);
        }

        /// <summary>
        /// 返回所有跟进计划
        /// </summary>
        /// <returns>返回所有跟进计划</returns>
        public DataTable GetList() 
        {
            return GetList("");
        }
    }
}
