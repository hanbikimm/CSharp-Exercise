using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace mvcExercise.Contract.Entities
{
    public class TestEntity
    {
        /// <summary>
        /// 비밀글 아이디(히든)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [DisplayName("글 제목")]
        public string Title { get; set; }

        /// <summary>
        /// 주제
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 성별
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 비밀글 여부
        /// </summary>
        public bool IsSecret { get; set; }


    }
}
