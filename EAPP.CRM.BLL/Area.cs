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
    public class Area
    {
        private static readonly EAPP.CRM.DAL.Area DAL = new EAPP.CRM.DAL.Area();

        /// <summary>
        /// 添加地区表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(EAPP.CRM.Model.AreaInfo info)
        {
            if (info == null) return 0;
            Model.AreaInfo pinfo = GetItem(info.ParentId);
            info.FullId = pinfo.FullId;
            return DAL.Insert(info);
        }

        /// <summary>
        /// 修改地区表
        /// </summary>
        /// <param name="ef">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(EAPP.CRM.Model.AreaInfo info)
        {
            if (info == null) return 0;
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="Fa_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public EAPP.CRM.Model.AreaInfo GetItem(int infoId)
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
            if (string.IsNullOrEmpty(infoId)) return 0;
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 根据父编号获取地区列表
        /// </summary>
        /// <param name="id">父编号</param>
        /// <returns>地区列表</returns>
        //public IList<EAPP.CRM.Model.AreaInfo> GetItemByParentId(string id)
        //{
        //    IList<EAPP.CRM.Model.AreaInfo> infos = new List<EAPP.CRM.Model.AreaInfo>();

        //    if (string.IsNullOrEmpty(id)) return infos;

        //    System.Data.DataTable table = DAL.GetItemByParentId(id);

        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        System.Data.DataRow row = table.Rows[i];

        //        EAPP.CRM.Model.AreaInfo info = new EAPP.CRM.Model.AreaInfo();

        //        info.AreaId = XYECOM.Core.MyConvert.GetInt32(row["AreaId"].ToString());
        //        info.AreaName = row["AreaName"].ToString();
        //        info.FullId = row["FullId"].ToString();
        //        info.OrderId = XYECOM.Core.MyConvert.GetInt32(row["OrderId"].ToString());
        //        info.ParentId = XYECOM.Core.MyConvert.GetInt32(row["ParentId"].ToString());

        //        infos.Add(info);
        //    }
        //    return infos;
        //}

        /// <summary>
        /// 根据父编号获取地区列表
        /// </summary>
        /// <param name="id">父编号</param>
        /// <returns>地区列表</returns>
        public System.Data.DataTable GetItemByParentId(string id)
        {
            if (string.IsNullOrEmpty(id)) return new System.Data.DataTable();

            return DAL.GetItemByParentId(id);
        }

        /// <summary>
        /// 根据地区编号。返回地区字符串
        /// </summary>
        /// <param name="areaId">地区编号</param>
        /// <returns>地区字符串</returns>
        public string ToStringFullName(int areaId)
        {
            string areaString = "";
            Model.AreaInfo info = GetItem(areaId);
            if (info != null)
            {
                if (info.ParentId != 0)
                {
                    areaString += ToStringFullName(info.ParentId) + "-" + info.AreaName;
                }
                else
                {
                    areaString += info.AreaName;
                }
            }
            return areaString;
        }

        /// <summary>
        /// 根据地区编号。返回地区完整编号
        /// </summary>
        /// <param name="areaId">地区编号</param>
        /// <returns>地区完整编号</returns>
        public string ToStringFullID(int areaId)
        {
            string areaString = "";
            Model.AreaInfo info = GetItem(areaId);
            if (info != null)
            {
                if (info.ParentId != 0)
                {
                    areaString += ToStringFullID(info.ParentId) + "," + info.AreaId;
                }
                else
                {
                    areaString += info.AreaId;
                }
            }
            return areaString;
        }


        /// <summary>
        /// 修改所有地区的FullID
        /// </summary>
        private void UpdateFullID()
        {
            System.Data.DataTable dt = GetList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                System.Data.DataRow dr = dt.Rows[i];

                int areaId = EAPP.CRM.Common.MyConvert.GetInt32(dr["AreaId"].ToString());
                string fullId = this.ToStringFullID(areaId);

                Model.AreaInfo info = GetItem(areaId);
                info.FullId = fullId;

                this.Update(info);
            }
        }

        /// <summary>
        /// 获取地区列表
        /// </summary>
        /// <returns>获取地区列表</returns>
        public DataTable GetList()
        {
            return DAL.GetList();
        }

        public int GetAreaDepth()
        {
            int result = 0;

            DataTable dt = DAL.GetList("FullId","");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                System.Data.DataRow dr = dt.Rows[i];
                string fullId = dr["FullId"].ToString();
                string[] ids = fullId.Split(new char[] { ',' });
                if (ids.Length > result) 
                {
                    result = ids.Length;
                }
            }
            return result;
        }
    }
}