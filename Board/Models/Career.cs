using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosti.Camp2023.Models
{
    public class Career
    {
        private int careerSeq;
        private int empSeq;
        private string fromDT;
        private string endDT;
        private string memo;

        public int CareerSeq
        {
            get { return careerSeq; }
            set { careerSeq = value; }
        }

        public int EmpSeq
        {
            get { return empSeq; }
            set { empSeq = value; }
        }

        public string FromDT
        {
            get { return fromDT; }
            set { fromDT = value; }
        }

        public string EndDT
        {
            get { return endDT; }
            set { endDT = value; }
        }

        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }
}
