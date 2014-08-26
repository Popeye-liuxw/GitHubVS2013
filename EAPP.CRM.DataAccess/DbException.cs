using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.DataAccess
{
    public class DbException:Exception
    {
        public DbException(string message)
            : base(message)
        {
        }

        public int Number
        {
            get { return 0; }
        }
    }
}
