using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosti.Camp2023.Models
{
    public class Member
    {
        private int empSeq;
        private string name;
        private int age;
        private string address;
        private string phoneNum;
        private string profileImg;

        public int EmpSeq
        {
            get { return empSeq; }
            set { empSeq = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }
        public string ProfileImg
        {
            get { return profileImg; }
            set { profileImg = value; }
        }


    }
}
