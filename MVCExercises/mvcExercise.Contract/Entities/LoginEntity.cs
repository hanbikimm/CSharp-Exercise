using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcExercise.Contract.Entities
{
    public class LoginEntity
    {
        /// <summary>
        /// 로그인 아이디
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 로그인 패스워드
        /// </summary>
        public string Password { get; set; }
    }
}
