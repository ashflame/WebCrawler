using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Delete
{
    public class VK
    {
        VkApi vk = new VkApi();
        private readonly int groupID = 31976785;
        private readonly int appID = xxx; 


        public void auth(string email, string pass)
        {               
            Settings scope = Settings.Friends;      // Приложение имеет доступ к друзьям
            vk.Authorize(appID, email, pass, scope);
        }
        
        public int group()
        {
            int totalCount;
            var ids = vk.Groups.GetMembers(this.groupID, out totalCount);
            return totalCount;
        }

        static void Main(string[] args)
        {
            VK b = new VK();
            int m = b.group();
        }
    }
}
