using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Residencia
{
    public static class Extensions
    {
        public static string GetConnectionStringBD()
        {
#pragma warning disable CS0618 // 'ConfigurationSettings.AppSettings' está obsoleto: 'This method is obsolete, it has been replaced by System.Configuration!System.Configuration.ConfigurationManager.AppSettings'
            var title =ConfigurationSettings.AppSettings.GetValues(Constants.KeyConnection);
#pragma warning restore CS0618 // 'ConfigurationSettings.AppSettings' está obsoleto: 'This method is obsolete, it has been replaced by System.Configuration!System.Configuration.ConfigurationManager.AppSettings'

            return title[0];
        }
    }
}
