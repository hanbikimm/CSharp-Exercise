using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Contract.Entities
{
    public class DetailEntity
    {
        /// <summary>
        /// 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 본문
        /// </summary>
        public string Content { get; set; }
    }
}
