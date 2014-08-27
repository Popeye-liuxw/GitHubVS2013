using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EAPP.CRM.DAL
{
    public class Utils
    {
        /// <summary>
        /// 根据表tableName以及条件vwhere删除一条或多条记录。
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="where">条件</param>
        /// <returns>受影响行数</returns>
        public static int Delete(string tableName, string where)
        {
            System.Data.SqlClient.SqlParameter []pars = new System.Data.SqlClient.SqlParameter[]
            {
                new SqlParameter("@tableName", tableName),
                new SqlParameter("@strWhere", where)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "proc_Delete", pars);
        }

        #region ExecuteTable
        /// <summary>
        /// 根据条件获取对应数据
        /// 使用提示：适用于读取小量数据，大量数据请选用其他方法
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="colums">列名</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <param name="topNumber">记录条数</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string tableName, string colums, string where, string order, int topNumber)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",topNumber),
                new SqlParameter("@Columns",colums),
                new SqlParameter("@Table",tableName),
                new SqlParameter("@Where",where),
                new SqlParameter("@Order",order)
            };

            return EAPP.CRM.DataAccess.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[proc_CommonSelect]", param);
        }

        public static DataTable ExecuteTable(string tableName, string colums, string where)
        {
            return ExecuteTable(tableName, colums, where, "", 0);
        }

        #endregion
    }
}
