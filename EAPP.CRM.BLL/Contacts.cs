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
    public class Contacts
    {
		private static readonly EAPP.CRM.DAL.Contacts DAL = new EAPP.CRM.DAL.Contacts();
		
        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.ContactsInfo info)
        {
			if (info == null) return 0;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.ContactsInfo info)
        {
			if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.ContactsInfo  GetItem(int infoId)
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
        /// 根据条件获取联系人列表
        /// </summary>
        /// <param name="strWhere">获取条件</param>
        /// <returns>联系人列表</returns>
        public DataTable GetList(string strWhere)
        {
            return DAL.GetList(strWhere);
        }

        /// <summary>
        ///  获取所有联系人
        /// </summary>
        /// <returns>返回所有联系人列表</returns>
        public DataTable GetList() 
        {
            return GetList("");
        }

        /// <summary>
        /// 联系人高级查询
        /// </summary>
        /// <param name="param">高级查询条件</param>
        /// <returns>返回联系人列表</returns>
        public DataTable Search(EAPP.CRM.Model.SearchContactsParameter parm)
        {
            return DAL.Search(parm);
        }

        public DataTable GetList(int p)
        {
            return DAL.GetList("");
        }
    }
}
