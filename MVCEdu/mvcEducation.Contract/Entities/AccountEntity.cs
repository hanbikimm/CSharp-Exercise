using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Contract.Entities
{
    public class AccountEntity
    {
        // 프로퍼티 설정:
        // 자동으로 private 필드 생성, get/set함수 생성
        // 데이터의 접근자는 private

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
