using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums;
namespace WinServiceCrawler
{
    class CrawlerStatistic
    {
        private readonly VkApi vkapi;

        public CrawlerStatistic(VkApi api)
        {
            vkapi = api;
        }

        public void ParsingStatisticGroup(int groupID)
        {
            using (UserContext db = new UserContext())
            {
                int totalCountFollowers, totalCountPosts;
                vkapi.Wall.Get(-@groupID, out totalCountPosts, 50, 1, WallFilter.All);
                vkapi.Groups.GetMembers(groupID, out totalCountFollowers);
                Statistic statistic = new Statistic
                {
                    date = Convert.ToDateTime(DateTime.Now),
                    countFollowers = totalCountFollowers,
                    countPosts = totalCountPosts,
                };
                db.Statistic.Add(statistic);
                db.SaveChanges();
            };
        }
    }
}
