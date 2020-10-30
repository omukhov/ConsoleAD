using System.Diagnostics;
using System;
using System.DirectoryServices;

namespace ConsoleAD
{
    class ControllerUserInfoActiveDirectory
    {

        /// <summary>
        /// Запрос у сервера LDAP строки подключения
        /// </summary>
        private string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");

            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();

        }

        /// <summary>
        /// Создание объекта и заполнение списка свойств, которые нужно получить для пользователя Active Directory
        /// </summary>
        private DirectorySearcher BuildUserSearcher(DirectoryEntry de)
        {
            DirectorySearcher ds = null;

            ds = new DirectorySearcher(de);

            // Полное имя пользователя
            ds.PropertiesToLoad.Add("name");

            // Еmail Адрес пользователя
            ds.PropertiesToLoad.Add("mail");

            // Имя пользователя
            ds.PropertiesToLoad.Add("givenname");

            // Фамилия пользователя
            ds.PropertiesToLoad.Add("sn");

            // Логин пользователя
            ds.PropertiesToLoad.Add("userPrincipalName");

            // Уникальное имя - Полное имя + путь
            ds.PropertiesToLoad.Add("distinguishedName");

            return ds;
        }

        /// <summary>
        /// Получение необходимого пользователя
        /// </summary>
        public void GetOneUser(string userName)
        {
            DirectorySearcher ds = null;
            DirectoryEntry de = new DirectoryEntry(GetCurrentDomainPath());
            SearchResult sr;

            ds = BuildUserSearcher(de);

            // Установка фильтра для поиска конкретного пользователя
            ds.Filter = "(&(objectCategory=User)(objectClass=person)(userPrincipalName=" + userName + ")";

            sr = ds.FindOne();

            if (sr != null)
            {
                var model = new UserInfoActiveDirectoryViewModel
                {
                    Name = sr.GetPropertyValue("name"),
                    Mail = sr.GetPropertyValue("mail"),
                    Givenname = sr.GetPropertyValue("givenname"),
                    Sn = sr.GetPropertyValue("sn"),
                    UserPrincipalName = sr.GetPropertyValue("userPrincipalName"),
                    DistinguishedName = sr.GetPropertyValue("distinguishedName"),
                };

                Console.WriteLine(model);
            }
            
        }
    }
}
