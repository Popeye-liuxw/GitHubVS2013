using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace EAPP.CRM.Web
{
    public class Ajax
    {
        /// <summary>
        /// 根据父编号获取地区列表
        /// </summary>
        /// <param name="areaId">父编号</param>
        /// <returns>地区列表</returns>
        public static DataTable GetAreaList(string areaId)
        {
            EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();
            return areaBLL.GetItemByParentId(areaId);
        }

        /// <summary>
        /// 根据userOrDept的值返回用户列表或者部门列表
        /// </summary>
        /// <param name="userOrDept">只能为user或者dept</param>
        /// <returns>根据userOrDept的值返回用户列表或者部门列表</returns>
        public static DataTable GetUserDataOrDeptData(string userOrDept)
        {
            userOrDept = userOrDept.ToLower();

            DataTable table = new DataTable();
            switch (userOrDept)
            {
                case "user":
                    EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
                    table = userBLL.GetList();
                    break;
                case "dept":
                    EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();
                    table = deptBLL.GetList();
                    break;
                default:
                    break;
            }

            return table;
            

        }

        /// <summary>
        /// 根据地区编号获取地区信息
        /// </summary>
        public static string[] GetArea(string areaId)
        {
            //index 0 自身编号 index 1 地区名称 index 2 该地区父地区编号
            string []result = new string[3]{"-1","请选择…","0"};

            EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();
            if (!string.IsNullOrEmpty(areaId))
            {
                Model.AreaInfo info = areaBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(areaId));
                if (info != null)
                {
                    result[0] = info.AreaId.ToString();
                    result[1] = info.AreaName;
                    result[2] = info.ParentId.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// 批量删除客户
        /// </summary>
        /// <param name="ids">需要删除的客户编号</param>
        /// <returns>返回影响行数</returns>
        public static int Delete(string ids)
        {
            EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
            return customerBLL.Delete(ids);
        }

        public static string CheckLoginName(string userName)
        {
            string res = "";
            EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
            if (userBLL.GetItem(userName) == null) 
            {
                res = "1";
            }
            return res;
        }
    }
}
