using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAD
{
    public class UserInfoActiveDirectoryViewModel
    {
        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Еmail Адрес пользователя
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Givenname { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Sn { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// // Уникальное имя - Полное имя + путь
        /// </summary>
        public string DistinguishedName { get; set; }
    }
}
