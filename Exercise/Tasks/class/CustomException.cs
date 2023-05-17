using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tasks
{
    internal class CustomException : Exception
{
            public CustomException()
            {
            }



            public CustomException(string message) : base(message)
            {
                Debug.WriteLine(message);
            }



            public CustomException(string message, Exception innerException) : base(message, innerException)
            {
            }



            public int CustomErrorCode { get; set; }
        }
}
