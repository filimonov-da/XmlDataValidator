using System;
using System.Configuration;
using System.Globalization;
using XmlDataValidator.BLL.Interfaces;

namespace XmlDataValidator.BLL.BusinessModels
{
    public class Configuration
    {
        #region [GetAppSetting]

        public static object GetAppSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            try
            {
                if (expectedType == typeof(int))
                    return int.Parse(value);

                if (expectedType == typeof(string))
                    return value;

                if (expectedType == typeof(bool))
                    return bool.Parse(value);

                if (expectedType == typeof(DateTime))
                    return DateTime.Parse(value);

                if (expectedType == typeof(TimeSpan))
                    return TimeSpan.Parse(value, CultureInfo.InvariantCulture);

                throw new Exception("Тип не поддерживается");
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Ключ {0} должен иметь тип {1}", key, expectedType), ex);
            }
        }

        #endregion
    }
}
