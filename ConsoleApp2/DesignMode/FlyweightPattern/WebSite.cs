using ConsoleApp2.DesignMode.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DesignMode.FlyweightPattern
{
    class User
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        private int _age;

        public User(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    class WebSite
    {
        public string webSiteName;
        public IList<User> userList = new List<User>();
        public void AddUser(User user)
        {
            userList.Add(user);
        }

        public int GetUserCount => userList.Count;

        public WebSite(string name)
        {
            this.webSiteName = name;
        }
    }

    class ConcreteWebSite : WebSite
    {
        public ConcreteWebSite(string name) : base(name)
        {
        }
    }

    class Factory
    {
        private static Factory _factory = new Factory();

        private Factory()
        {

        }

        public static Factory GetInstance()
        {
            return _factory;
        }

        private static Dictionary<string, WebSite> webSiteDic = new Dictionary<string, WebSite>();

        public void AddNewWebSite(string name, WebSite webSite)
        {
            if (!webSiteDic.ContainsKey(name))
            {
                webSiteDic.Add(name, null);
            }
            webSiteDic[name] = webSite;
        }

        public void GetWebSite(string name)
        {
            if (webSiteDic.ContainsKey(name))
            {

                Console.WriteLine(webSiteDic[name].webSiteName);

                if (webSiteDic[name].userList != null && webSiteDic[name].userList.Count > 0)
                {
                    foreach (var item in webSiteDic[name].userList)
                    {
                        Console.WriteLine($"name is {item.Name}, age is {item.Age}");

                    }
                }

            }
        }
    }

    public class TestFlyweight : BaseSingleton<TestFlyweight>
    {
        public override void Test()
        {
            ConcreteWebSite webSite = new ConcreteWebSite("网站1");
            webSite.userList = new List<User>();
            webSite.userList.Add(new User("shelley", 19));
            webSite.userList.Add(new User("meng", 19));
            Factory.GetInstance().AddNewWebSite(webSite.webSiteName, webSite);
            ConcreteWebSite webSite2 = new ConcreteWebSite("网站2");
            webSite2.userList = new List<User>();
            webSite2.userList.Add(new User("shelley2", 19));
            webSite2.userList.Add(new User("meng2", 19));
            Factory.GetInstance().AddNewWebSite(webSite2.webSiteName, webSite2);

            Factory.GetInstance().GetWebSite(webSite.webSiteName);
            Factory.GetInstance().GetWebSite(webSite2.webSiteName);
        }
    }
}
