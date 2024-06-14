using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day01
{
    /// <summary>
    /// 服务端  数据访问对象工厂
    /// </summary>
    public class ServerDaoFactory : DaoFactory
    {
        public override IUserDao UserDao
        {
            get
            {
                return new UserServerDao();
            }
        }

        public override IRoleDao RoleDao
        {
            get
            { 
            return new RoleServerDao();
            }
        }
    }
}