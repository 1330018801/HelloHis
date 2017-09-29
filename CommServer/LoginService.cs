using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommContracts;

namespace CommServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“LoginService”。
    public class LoginService : ILoginService
    {
        private MainWindow hostApp;
        public LoginService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }

        public bool UserAuthenticate(LoginUser l)
        {
            // 这里调用BLL中的逻辑
            BLL.Login login = new BLL.Login(l.Username, l.Password);
            return login.Authenticate();
        }
    }
}
