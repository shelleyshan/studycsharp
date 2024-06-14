using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day01
{
    /// <summary>
    /// 客户端 数据访问对象工厂
    /// </summary>
    public class ClientDaoFactory : DaoFactory
    {
        public override IUserDao UserDao
        {
            get
            { 
            return new UserClientDao(); 
            }
        }

        public override IRoleDao RoleDao
        { 
        get { return new RoleClientDao(); }
        }
    }
}