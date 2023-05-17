using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Contract.Entities
{
    public class CommentEntity
    {
        /// <summary>
        /// 댓글 Relation
        /// </summary>
        public string Relation { get; set; }
        /// <summary>
        /// 작성자
        /// </summary>
        public string Writer { get; set; }

        /// <summary>
        /// 댓글 본문
        /// </summary>
        public string Content { get; set; }

        
    }
}
