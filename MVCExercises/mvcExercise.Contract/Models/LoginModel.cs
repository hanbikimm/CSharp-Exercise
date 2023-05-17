using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcExercise.Contract.Entities;

namespace mvcExercise.Contract.Models
{
    public class LoginModel
    {
        #region Entity
        public LoginEntity loginEntity { get; set; } = new LoginEntity();

        #endregion
    }
}
