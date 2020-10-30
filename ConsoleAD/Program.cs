using System.Diagnostics;
using System;
using System.DirectoryServices;

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
            Program p = new Program();
            p.GetAUser(userName);            
        }

        /// <summary>
        /// Запрос у сервера LDAP строки подключения
        /// </summary>
        private string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");

            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();

        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        private DirectorySearcher GetAdditionalUserInfo(DirectoryEntry de)
        {
            DirectorySearcher ds = null;

            ds = new DirectorySearcher(de);

            /// <summary>
            /// Полное имя пользователя
            /// </summary>
            ds.PropertiesToLoad.Add("name");

            /// <summary>
            /// Еmail Адрес пользователя
            /// </summary>
            ds.PropertiesToLoad.Add("mail");

            /// <summary>
            /// Имя пользователя
            /// </summary>
            ds.PropertiesToLoad.Add("givenname");

            /// <summary>
            /// Фамилия пользователя
            /// </summary>
            ds.PropertiesToLoad.Add("sn");

            /// <summary>
            /// Логин пользователя
            /// </summary>
            ds.PropertiesToLoad.Add("userPrincipalName");

            /// <summary>
            /// Уникальное имя - Полное имя + путь
            /// </summary>
            ds.PropertiesToLoad.Add("distinguishedName");

            return ds;
        }

        /// <summary>
        /// Получение одного пользователя
        /// </summary>
        public void GetAUser(string userName)
        {
            DirectorySearcher ds = null;
            DirectoryEntry de = new DirectoryEntry(GetCurrentDomainPath());
            SearchResult sr;

            ds = GetAdditionalUserInfo(de);

            /// <summary>
            /// Установка фильтра для поиска конкретного пользователя
            /// </summary>
            ds.Filter = "(&(objectCategory=User)(objectClass=person)(userPrincipalName=" + userName + ")";

            sr = ds.FindOne();

            if (sr != null)
            {
                Debug.WriteLine(sr.GetPropertyValue("name"));
                Debug.WriteLine(sr.GetPropertyValue("mail"));
                Debug.WriteLine(sr.GetPropertyValue("givenname"));
                Debug.WriteLine(sr.GetPropertyValue("sn"));
                Debug.WriteLine(sr.GetPropertyValue("userPrincipalName"));
                Debug.WriteLine(sr.GetPropertyValue("distinguishedName"));
            }

        }

    }
}
