using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcEducation.Contract.Entities;

namespace mvcEducation.Contract.Models
{
    public class AccountModel
    {
        #region Entity, List<Entity>
        public AccountEntity accountEntity { get; set; } = new AccountEntity();

        public List<AccountEntity> accountEntities { get; set; }

        #endregion
    }
}
