using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace YH_CRS
{
    class Program
    {
        static User[] a;
        static User u;
        static void Main(string[] args)
        {
            hello();
        }
        //开户
        static void account()
        {
            Console.WriteLine("请输入你的姓名");
            string name = Console.ReadLine();
            u.UserName = name;
            Console.WriteLine("请输入你的开户账号");
            string account1 = Console.ReadLine();
            u.Uuid = long.Parse(account1);
            Console.WriteLine("请输入您要开户的密码");
            bool flag;
            for(int i=1; i <= 3; i++)
            {
                flag = true;
                string passwd = Console.ReadLine();
                if (passwd.Length != 6)
                {
                    Console.WriteLine("您输入的密码不是6位，请重新输入");
                    flag = false;
                }
                else
                {
                    for (int j = 0; j < passwd.Length; j++)
                    {
                        if (!Char.IsNumber(passwd, j))
                        {
                            Console.WriteLine("密码只能是数字类型,请再次尝试输入");
                            flag = false;
                            break;
                        }

                    }
                }
                if (flag)
                {
                    Console.WriteLine("您输入的密码有效");
                    Console.WriteLine("请再次输入您要开户的密码");
                    string password2 = Console.ReadLine();
                    while (passwd != password2)
                    {
                        Console.WriteLine("两次密码不一致，请再次尝试");
                        password2 = Console.ReadLine();
                    }
                    Console.WriteLine("密码已成功设置，请继续注册");
                    u.UserPassword = passwd;
                    break;
                }
                if (i == 3)
                {
                    Console.WriteLine("您尝试的次数已经3次，请重新设置密码");
                    i = 0;
                }
            }
            Console.WriteLine("请输入你的开户金额");
            string money1 = Console.ReadLine();
            u.Money = double.Parse(money1);
            Console.WriteLine("这是你的开户信息");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("姓名:" + u.UserName);
            Console.WriteLine("开户账号:" + u.Uuid);
            Console.WriteLine("开户金额:" + u.Money);
            Console.WriteLine("-------------------------------------------");
        }
        //菜单
        static void menu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t尊敬的"+u.UserName+"欢迎使用本系统");
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t请选择操作:");
            Console.WriteLine("\t1.存款");
            Console.WriteLine("\t2.取款");
            Console.WriteLine("\t3.查看余额");
            Console.WriteLine("\t4.转账");
            Console.WriteLine("\t5.修改密码");
            Console.WriteLine("\t6.查询所有账户");
            Console.WriteLine("\t7.退出");
            Console.WriteLine("请选择你需要操作的编号，按回车结束");
            string i = Console.ReadLine();
            int b = int.Parse(i);
            switch (b)
            {
                case 1:
                    deposit();
                    menu();
                    break;
                case 2:
                    withdraw();
                    menu();
                    break;
                case 3:
                    Console.WriteLine("您的余额剩余"+u.Money);
                    menu();
                    break;
                case 4:
                    transfer();
                    menu();
                    break;
                case 5:
                    updatePasswd();
                    hello();
                    break;
                case 6:
                    select();
                    menu();
                    return;
                case 7:
                    Console.WriteLine("欢迎下次使用");
                    Process.GetCurrentProcess().Kill();
                    return;
            }
        }
        //登陆
        static bool login()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t\t登录界面");
            Console.WriteLine("*******************************************");
            Console.WriteLine("请输入您的用户名");
            string name = Console.ReadLine();
            if(name == u.UserName)
            {
                Console.WriteLine("请输入您的密码");
                string password = Console.ReadLine();
                if (password == u.UserPassword)
                {
                    Console.WriteLine("恭喜您登录成功");
                    menu();
                    return true;
                }
                else
                {
                    Console.WriteLine("密码错误，请重新输入");
                    return false;
                }
               
            }
            else
            {
                Console.WriteLine("用户名不对，请重新登录");
                return false;
            }

        }
        //欢迎
        static void hello()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("中国银行CRS存取款一体机\t用户第一 服务至上");
            Console.WriteLine("*******************************************");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t1.开户");
            Console.WriteLine("\t\t2.登录");
            Console.WriteLine("\t\t3.批量开户");
            Console.WriteLine("\t\t4.查询所有");
            Console.WriteLine("\t\t5.退出");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("请选择你需要操作的编号，按回车结束");
            string i = Console.ReadLine();
            int b = int.Parse(i);
            switch (b)
            {
                case 1:
                    account();
                    hello();
                    break;
                case 2:
                    if (login())
                    {
                        menu();
                    }
                    else
                    {
                        login();
                    }
                    break;
                case 3:
                    batch();
                    hello();
                    break;
                case 4:
                    select();
                    hello();
                    break;
                case 5:
                    Console.WriteLine("期待您的再次使用");
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }
        //存款
        static void deposit()
        {
            Console.WriteLine("请输入你要存款的金额");
            try
            {
                double d = double.Parse(Console.ReadLine());
                u.Money += d;
                Console.WriteLine("存款成功,你的余额为" + u.Money);
            }
            catch
            {
                Console.WriteLine("请输入正确的数字");
                deposit();
            }
            
        }
        //取款
        static void withdraw()
        {
            Console.WriteLine("请输入你要存款的金额");
            double d = double.Parse(Console.ReadLine());
            if(u.Money < d)
            {
                Console.WriteLine("取款失败，卡内余额不足");
            }
            else
            {
                u.Money -= d;
                Console.WriteLine("取款成功，请拿好你的现金");
            }
        }
        //转账
        static void transfer()
        {
            Console.WriteLine("请输入您要转账的金额");
            double d = double.Parse(Console.ReadLine());
            if (u.Money < d)
            {
                Console.WriteLine("转账失败，卡内余额不足");
            }
            else
            {
                u.Money -= d;
                Console.WriteLine("转账成功，你的余额剩余"+u.Money);
            }
        }
        //更改密码
        static void updatePasswd()
        {
            Console.WriteLine("请输入您的原密码");
            string passwd = Console.ReadLine();
            if (passwd == u.UserPassword)
            {
                Console.WriteLine("请输入新的密码");
                bool flag;
                for (int i = 0; i < 3; i++)
                {
                    flag = true;
                    string passwdNew = Console.ReadLine();
                    if(passwdNew != passwd)
                    {
                        if (passwdNew.Length != 6)
                        {
                            Console.WriteLine("您输入的密码不是6位，请重新输入");
                            flag = false;
                        }
                        else
                        {
                            for (int j = 0; j < passwdNew.Length; j++)
                            {
                                if (!Char.IsNumber(passwdNew, j))
                                {
                                    Console.WriteLine("密码只能是数字类型,请再次尝试输入");
                                    flag = false;
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("新密码不能和旧密码一致，请重新输入");
                        flag = false;
                    }
                    if (flag)
                    {
                        Console.WriteLine("您输入的新密码有效");
                        Console.WriteLine("请再次输入您要更改的密码");
                        string password2 = Console.ReadLine();
                        while (passwdNew != password2)
                        {
                            Console.WriteLine("两次密码不一致，请再次尝试");
                            password2 = Console.ReadLine();
                        }
                        u.UserPassword = passwdNew;
                        Console.WriteLine("密码修改成功，请重新登陆");
                        break;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("原密码不一致");
                updatePasswd();
            }
        }
        //批量
        static void batch()
        {
            
            Console.WriteLine("请输入你要开几个账户");
            int sum = Convert.ToInt32(Console.ReadLine());
            if (sum == 1)
            {
                Console.WriteLine("已自动跳转至普通开户");
                account();
            }else
            {
                a = new User[sum];
                for(int i = 0; i < sum; i++)
                {
                    Console.WriteLine("你正在创建第{0}个账户",i);
                    u = new User();
                    Console.WriteLine("请输入你的姓名");
                    string name = Console.ReadLine();
                    u.UserName=name;
                    Console.WriteLine("请输入你的开户账号");
                    string account1 = Console.ReadLine();
                    u.Uuid = long.Parse(account1);
                    Console.WriteLine("请输入您要开户的密码");
                    bool flag;
                    for (int j = 1; j <= 3; j++)
                    {
                        flag = true;
                        string passwd = Console.ReadLine();
                        if (passwd.Length != 6)
                        {
                            Console.WriteLine("您输入的密码不是6位，请重新输入");
                            flag = false;
                        }
                        else
                        {
                            for (int z = 0; z < passwd.Length; z++)
                            {
                                if (!Char.IsNumber(passwd, z))
                                {
                                    Console.WriteLine("密码只能是数字类型,请再次尝试输入");
                                    flag = false;
                                    break;
                                }

                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("您输入的密码有效");
                            Console.WriteLine("请再次输入您要开户的密码");
                            string password2 = Console.ReadLine();
                            while (passwd != password2)
                            {
                                Console.WriteLine("两次密码不一致，请再次尝试");
                                password2 = Console.ReadLine();
                            }
                            Console.WriteLine("密码已成功设置，请继续注册");
                            u.UserPassword = passwd;
                            break;
                        }
                        if (j == 3)
                        {
                            Console.WriteLine("您尝试的次数已经3次，请重新设置密码");
                            j = 0;
                        }
                    }
                    Console.WriteLine("请输入你的开户金额");
                    string money1 = Console.ReadLine();
                    u.Money = double.Parse(money1);
                    Console.WriteLine("这是你的开户信息");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("姓名:" + u.UserName);
                    Console.WriteLine("开户账号:" + u.Uuid);
                    Console.WriteLine("开户金额:" + u.Money);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("已成功存入数组中");
                    a[i] = u;
                }
            }
        }
        //查询所有账户
        static void select()
        {
            for(int i=0;i<a.Length;i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        
    }
    class User
    {
        private static string userName;
        private static string userPassword;
        private static long uuid;
        private static double money;

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public  string UserPassword
        {
            get => userPassword;
            set => userPassword = value;
        }

        public  long Uuid
        {
            get => uuid;
            set => uuid = value;
        }

        public  double Money
        {
            get => money;
            set => money = value;
        }

        public override string ToString()
        {
            return "开户的名称："+userName+",账户id："+Uuid+",密码："+Md5Encrypt64(UserPassword)+",所剩余额："+Money;
        }
        public static string Md5Encrypt64(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            var hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            return tmp.ToString();
        }
    }
}
