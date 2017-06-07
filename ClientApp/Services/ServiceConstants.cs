using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class ServiceConstants
    {
        //Kogu see sodi võiks põmst olla ka service's, aga nii on elegantsem :D
        private static string getKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static string NoticeServiceUrl
        {
            get
            {
                return getKey("NoticeServiceUrl");
            }
        }

        public static string PersonServiceUrl
        {
            get
            {
                return getKey("PersonServiceUrl");
            }
        }

        public static string VotingServiceUrl
        {
            get
            {
                return getKey("VotingServiceUrl");
            }
        }
    }
}
