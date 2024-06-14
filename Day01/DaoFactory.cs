using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day01
{
    /// <summary>
    /// 数据访问对象工厂
    /// </summary>
    public abstract class DaoFactory
    {
        //public static IUserDao UserDao
        //{
        //    get
        //    {
        //        if (GameMain.Type == "Client")
        //        {
        //            return new UserClientDao();
        //        }
        //        else
        //        {
        //            return new UserServerDao();
        //        }
        //    }
        //}

        public abstract IUserDao UserDao { get; }

        public abstract IRoleDao RoleDao { get; }

        public static DaoFactory Instance
        {
            get
            {
                //选择儿子
                if (GameMain.Type == "Client")
                {
                    return new ClientDaoFactory();
                }
                else
                {
                    return new ServerDaoFactory();
                }
            }
        }
    }
}