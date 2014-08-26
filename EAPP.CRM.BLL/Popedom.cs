//------------------------------------------------------------------------------
//
// 说明：该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// author: EAPP
// create date：2009-12-2 18:34:55
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace EAPP.CRM.BLL
{
    public class Popedom
    {
        private static readonly EAPP.CRM.DAL.Popedom DAL = new EAPP.CRM.DAL.Popedom();

        /// <summary>
        /// 添加权限表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.PopedomInfo info)
        {
            if (info == null) return 0;

            if (info.RoleId < 1)
            {
                return 0;
            }

            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改权限表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.PopedomInfo info)
        {
            if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.PopedomInfo GetItem(int infoId)
        {
            if (infoId <= 0) return null;
            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string infoId)
        {
            if (String.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }

        public DataTable GetList()
        {
            return DAL.GetList();
        }

        public DataTable GetList(string rid)
        {
            return DAL.GetList(rid);
        }

        public int DeleteByRoleId(string rid)
        {
            return DAL.DeleteByRoleId(rid);
        }

        public IDictionary<string, bool> GetUserPopedom(EAPP.CRM.Model.UserInfo userInfo)
        {
            return DAL.GetUserPopedom(userInfo);
        }
    }
}