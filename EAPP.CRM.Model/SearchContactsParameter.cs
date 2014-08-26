using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.Model
{
    public class SearchContactsParameter
    {
        private string contactName;

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        private int stateId;

        public int StateId
        {
            get { return stateId; }
            set { stateId = value; }
        }
        private int tradeId;

        public int TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }
        private string otherWhere;

        public string OtherWhere
        {
            get { return otherWhere; }
            set { otherWhere = value; }
        }
        private string fields;

        public string Fields
        {
            get { return fields; }
            set { fields = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
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
    }
}
