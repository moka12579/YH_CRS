using System;

namespace YH_CRS
{
    class Program
    {
        static string userName;
        static string userPassword;
        static long uuid;
        static double money;
        static void Main(string[] args)
        {
            hello();
        }
        static void account()
        {
            Console.WriteLine("请输入你的姓名");
            string name = Console.ReadLine();
            userName = name;
            Console.WriteLine("请输入你的开户账号");
            string account1 = Console.ReadLine();
            uuid = long.Parse(account1);
            Console.WriteLine("请输入您要开户的密码");
            string password = Console.ReadLine();
            userPassword = password;
            Console.WriteLine("请输入你的开户金额");
            string money1 = Console.ReadLine();
            money = double.Parse(money1);
            Console.WriteLine("这是你的开户信息");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("姓名:" + userName);
            Console.WriteLine("开户账号:" + uuid);
            Console.WriteLine("开户金额:" + money);
            Console.WriteLine("-------------------------------------------");

        }
        static void menu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t尊敬的"+userName+"欢迎使用本系统");
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t请选择操作:");
            Console.WriteLine("\t1.存款");
            Console.WriteLine("\t2.取款");
            Console.WriteLine("\t3.查看余额");
            Console.WriteLine("\t4.转账");
            Console.WriteLine("\t5.退出");
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
                    Console.WriteLine("您的余额剩余"+money);
                    menu();
                    break;
                case 4:
                    transfer();
                    menu();
                    break;
                case 5:
                    break;
            }
        }
        static bool login()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("\t\t登录界面");
            Console.WriteLine("*******************************************");
            Console.WriteLine("请输入您的用户名");
            string name = Console.ReadLine();
            if(name == userName)
            {
                Console.WriteLine("请输入您的密码");
                string password = Console.ReadLine();
                if (password == userPassword)
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
        static void hello()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("中国银行CRS存取款一体机\t用户第一 服务至上");
            Console.WriteLine("*******************************************");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t1.开户");
            Console.WriteLine("\t\t2.登录");
            Console.WriteLine("\t\t3.退出");
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
                    Console.WriteLine("期待您的再次使用");
                    break;
                case 4:
                    Console.WriteLine(userName);
                    break;
            }
        }
        static void deposit()
        {
            Console.WriteLine("请输入你要存款的金额");
            try
            {
                double d = double.Parse(Console.ReadLine());
                money += d;
                Console.WriteLine("存款成功,你的余额为" + money);
            }
            catch
            {
                Console.WriteLine("请输入正确的数字");
                deposit();
            }
            
        }
        static void withdraw()
        {
            Console.WriteLine("请输入你要存款的金额");
            double d = double.Parse(Console.ReadLine());
            if(money < d)
            {
                Console.WriteLine("取款失败，卡内余额不足");
            }
            else
            {
                money -= d;
                Console.WriteLine("取款成功，请拿好你的现金");
            }
        }
        static void transfer()
        {
            Console.WriteLine("请输入您要转账的金额");
            double d = double.Parse(Console.ReadLine());
            if (money < d)
            {
                Console.WriteLine("转账失败，卡内余额不足");
            }
            else
            {
                money -= d;
                Console.WriteLine("转账成功，你的余额剩余"+money);
            }
        }
    }
}
