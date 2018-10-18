using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPeaton.Tools.Exceptions
{
    public class ClientCodeHandler
    {
        private static ClientCodeHandler _handler;
        private ClientCodeHandler() { }

        private ClientCodeHandler ExceptionHandler;

        private Dictionary<int, string> codeExceptions;

        public Dictionary<int, string> CodeExceptions
        {
            get
            {
                if (codeExceptions == null)
                    FillCodeExceptions();
                return codeExceptions;
            }

            set
            {
                codeExceptions = value;
            }
        }

        public static ClientCodeHandler GetInstance()
        {
            if (_handler == null)
                _handler = new ClientCodeHandler();
            return _handler;
        }

        private void FillCodeExceptions()
        {
            codeExceptions = new Dictionary<int,string>();
            #region Juan 1 to 10000 
            codeExceptions.Add(2525, "pepe");
            codeExceptions.Add(0001, "txtusername");
            codeExceptions.Add(0002, "Username");
            codeExceptions.Add(0003, "Email");
            codeExceptions.Add(0004, "dni");
            codeExceptions.Add(0005, "");
            codeExceptions.Add(0006, "");
            codeExceptions.Add(0007, "");
            codeExceptions.Add(0008, "OldPassword");
            codeExceptions.Add(0009, "cuitcuilcdi");
            codeExceptions.Add(0010, "");
            codeExceptions.Add(0011, "");
            codeExceptions.Add(0012, "address");
            codeExceptions.Add(0013, "cuitcuilcdi");
            codeExceptions.Add(0014, "OldPassword");
            codeExceptions.Add(0015, "email");
            codeExceptions.Add(0016, "");
            codeExceptions.Add(0017, "");
            codeExceptions.Add(0018, "");
            codeExceptions.Add(0019, "");

















































            #endregion

            #region Develop1 = Nahuel 10001 20000
            //115
            codeExceptions.Add(10001, "Name");











































            //160
            #endregion

            #region Develop2 = Wilson Develop 20001 30000
            //164















































            //212
            #endregion

            #region Develop3 = Manu  30001 40000
            //216
            codeExceptions.Add(30001, "name");
            codeExceptions.Add(30002, "name");
            codeExceptions.Add(30003, "name");
            codeExceptions.Add(30004, "name");
            codeExceptions.Add(30005, "name");
            codeExceptions.Add(30006, "username");
            codeExceptions.Add(30007, "username");
            codeExceptions.Add(30008, "address");
            codeExceptions.Add(30009, "address");
            codeExceptions.Add(30005, "idbusinessconfiguration");
            codeExceptions.Add(30005, "address");
            codeExceptions.Add(30005, "address");
            codeExceptions.Add(30005, "username");
            codeExceptions.Add(30005, "username");











































            //274
            #endregion

            #region Develop4 = Pradel  40001 50000
            //278














































            //325
            #endregion

            #region Develop5 = Juli 50001 60000
            //329















































            //377
            #endregion
        }

    }
}