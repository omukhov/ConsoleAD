using System;

namespace ConsoleAD
{
    class Program
    {
        /// <summary>
        /// Ввод логина
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите логин: ");
            string userName = Console.ReadLine();
            ControllerUserInfoActiveDirectory user = new ControllerUserInfoActiveDirectory();
            user.GetOneUser(userName);
        }

    }
}
