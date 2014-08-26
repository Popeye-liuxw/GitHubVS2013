using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.Model
{
    public class AnalyseCondition
    {
        private string assignObject;

        public string AssignObject
        {
            get { return assignObject; }
            set { assignObject = value; }
        }

        private int assignObjectId;

        public int AssignObjectId
        {
            get { return assignObjectId; }
            set { assignObjectId = value; }
        }

        private AnalyseType analyseType;

        public AnalyseType AnalyseType
        {
            get { return analyseType; }
            set { analyseType = value; }
        }
    }
}
