using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CommContracts
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool UserAuthenticate(LoginUser login);

        [OperationContract]
        bool UserLogout(LoginUser login);
    }
}
