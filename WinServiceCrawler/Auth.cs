using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums;
namespace WinServiceCrawler
{
    class Auth
    {
        private readonly int appID = xxx;

        //public Auth() { }

        public VkApi DoAuthorization(string userEmail, string userPassword)
        {
            var api = new VkApi();
            api.Authorize(appID, userEmail, userPassword, Settings.All);
            return api;
        }
    }
}
