using System.DirectoryServices;

namespace ConsoleAD
{
    /// <summary>
    /// Класс расширения метода доступа к Active Directory
    /// </summary>
    public static class ADExtensionMethods
    {
        /// <summary>
        /// Получить значение свойства
        /// </summary>
        public static string GetPropertyValue(this SearchResult sr, string propertyName)
        {
            string ret = string.Empty;

            if (sr.Properties[propertyName].Count > 0)
                ret = sr.Properties[propertyName][0].ToString();

            return ret;
        }
    }
}
