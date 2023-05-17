using mvcExercise.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcExercise.Contract.Models
{
    public class TestModel
    {
        #region Entity
        public TestEntity testEntity { get; set; } = new TestEntity();

        #endregion
    }
}
