using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tasks
{
    internal class SetReadOnly
{
        private const string MESSAGE_CONST = "Const 입니다.";
        private readonly string MESSAGE_READONLY = "Read only 입니다.";
        public SetReadOnly()
        {
            Debug.WriteLine("기본 생성자입니다.");
            Debug.WriteLine(MESSAGE_CONST);
            Debug.WriteLine(MESSAGE_READONLY);
        }

        public SetReadOnly(String message)
        {
            MESSAGE_READONLY = message;

            Debug.WriteLine("Read Only를 세팅하는 생성자입니다.");
            Debug.WriteLine(MESSAGE_CONST);
            Debug.WriteLine(MESSAGE_READONLY);

        }
    }
}
