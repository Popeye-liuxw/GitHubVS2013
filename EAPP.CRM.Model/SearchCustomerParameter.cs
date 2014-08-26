using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.Model
{
    public class SearchCustomerParameter
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        private string customerName = "";

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        /// <summary>
        /// 客户类型编号
        /// </summary>
        private int typeId = 0;

        /// <summary>
        /// 客户类型编号
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        /// <summary>
        /// 区域编号
        /// </summary>
        private int areaId = 0;

        /// <summary>
        /// 区域编号
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        
        /// <summary>
        /// 行业编号
        /// </summary>
        private int tradeId = 0;

        /// <summary>
        /// 行业编号
        /// </summary>
        public int TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }

        /// <summary>
        /// 客户来源编号
        /// </summary>
        private int sourceId = 0;

        /// <summary>
        /// 客户来源编号
        /// </summary>
        public int SourceId
        {
            get { return sourceId; }
            set { sourceId = value; }
        }

        /// <summary>
        /// 联系人中文姓名
        /// </summary>
        private string contacts = "";

        /// <summary>
        /// 联系人中文姓名
        /// </summary>
        public string Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        /// <summary>
        /// 客户地址
        /// </summary>
        private string address = "";

        /// <summary>
        /// 客户地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// 客户电话
        /// </summary>
        private string tel = "";

        /// <summary>
        /// 客户电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// 客户手机
        /// </summary>
        private string mobile = "";

        /// <summary>
        /// 客户手机
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        /// <summary>
        /// 客户状态
        /// </summary>
        private int stateId = 0;

        /// <summary>
        /// 客户状态
        /// </summary>
        public int StateId
        {
            get { return stateId; }
            set { stateId = value; }
        }

        /// <summary>
        /// 当前登录用户编号
        /// </summary>
        private int curUserId;

        /// <summary>
        /// 当前登录用户编号
        /// </summary>
        public int CurUserId
        {
            get { return curUserId; }
            set { curUserId = value; }
        }

        /// <summary>
        ///所要获取的字段，多个字段用"," 隔开，默认为"*"。
        /// </summary>
        private string fields = "*";

        /// <summary>
        ///所要获取的字段，多个字段用"," 隔开，默认为"*"。
        /// </summary>
        public string Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        /// <summary>
        /// 其他条件
        /// </summary>
        private string otherWhere = "";

        /// <summary>
        /// 其他条件
        /// </summary>
        public string OtherWhere
        {
            get { return otherWhere; }
            set { otherWhere = value; }
        }
      
        /// <summary>
        /// 负责起始日期
        /// </summary>
        private string assignDateStart;

        /// <summary>
        /// 负责起始日期
        /// </summary>
        public string AssignDateStart
        {
            get { return assignDateStart; }
            set { assignDateStart = value; }
        }

        /// <summary>
        /// 负责结束日期
        /// </summary>
        private string assignDateEnd;

        /// <summary>
        /// 负责结束日期
        /// </summary>
        public string AssignDateEnd
        {
            get { return assignDateEnd; }
            set { assignDateEnd = value; }
        }

        /// <summary>
        /// 最近联系起始时间
        /// </summary>
        private string nearTiemStart;

        /// <summary>
        /// 最近联系起始时间
        /// </summary>
        public string NearTiemStart
        {
            get { return nearTiemStart; }
            set { nearTiemStart = value; }
        }

        /// <summary>
        /// 最近联系结束时间
        /// </summary>
        private string nearTimeEnd;

        /// <summary>
        /// 最近联系结束时间
        /// </summary>
        public string NearTimeEnd
        {
            get { return nearTimeEnd; }
            set { nearTimeEnd = value; }
        }

        /// <summary>
        /// 下次联系起始时间
        /// </summary>
        private string nextTimeStart;

        /// <summary>
        /// 下次联系起始时间
        /// </summary>
        public string NextTimeStart
        {
            get { return nextTimeStart; }
            set { nextTimeStart = value; }
        }

        /// <summary>
        /// 下次联系结束时间
        /// </summary>
        private string nextTimeEnd;

        /// <summary>
        /// 下次联系结束时间
        /// </summary>
        public string NextTimeEnd
        {
            get { return nextTimeEnd; }
            set { nextTimeEnd = value; }
        }
    }
}
