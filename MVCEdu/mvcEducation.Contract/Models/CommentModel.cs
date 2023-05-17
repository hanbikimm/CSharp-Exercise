using mvcEducation.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEducation.Contract.Models
{
    public class CommentModel
    {
        #region Entity, List<Entity>
        public List<CommentEntity> commentEntities { get; set; } = new List<CommentEntity>();
        #endregion
    }
}
