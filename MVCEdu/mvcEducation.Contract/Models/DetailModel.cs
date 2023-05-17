using mvcEducation.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Contract.Models
{
    public class DetailModel
    {
        #region Entity, List<Entity>
        public DetailEntity detailEntity { get; set; } = new DetailEntity();

        #endregion

        #region 
        //public CommentEntity commentEntity { get; set; } = new CommentEntity();
        public CommentModel commentModel { get; set; } = new CommentModel();
        #endregion
    }
}
