using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tasks
{
    public static class AppConfiguration
    {
        public static void SetAppConfig(string key, string value)
        {
            string setting = ConfigurationManager.AppSettings["MostiID"];

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.AppSettings.Settings.Add("MostiIP", "127.0.0.1");

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }
    }
}
