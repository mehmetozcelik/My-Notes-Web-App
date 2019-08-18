using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Common.Helpers
{
    // Webconfig dosyasındaki 'AppSettings' verilerini key değerini vererek çekmeyi sağlar.

    public class ConfigHelper
    {
        public static T Get<T>(string key)
        {
            // ConfigurationManager için: dll eklendi.            
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
        }
    }
}
