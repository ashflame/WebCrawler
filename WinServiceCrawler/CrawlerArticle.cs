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
using System.Threading;
namespace WinServiceCrawler
{
    class CrawlerArticle
    {
        private readonly int stepOffset = 50;
        private static int processedPosts = 0;
        private readonly VkApi vkapi;
        private readonly int totalCountPosts = 21166;

        public CrawlerArticle(VkApi api)
        {
            vkapi = api;
        }

        public void ParsingArticleGroup(int groupID)
        {
            double requestPause = 0;
            int totalCountPosts;
            //vkapi.Wall.Get(-@groupID, out totalCountPosts, 50, 1, WallFilter.All); // рефакторить, думаю вынести в отдельный класс группы!
            int offset = 0;
            //int processedPosts = 0;
            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(requestPause));
                try
                {
                    var dataPost = vkapi.Wall.Get(-@groupID, out totalCountPosts, 50, offset, WallFilter.All);
                    // вынести в отдельную процедуру запись в бд
                    using (UserContext db = new UserContext())
                    {
                        for (int i = 0; i < dataPost.Count; i++)
                        {
                            Post post = new Post
                            {
                                postID = dataPost[i].Id,
                                countOfComments = dataPost[i].Comments.Count,
                                text = dataPost[i].Text,
                                likes = dataPost[i].Likes.Count,
                                reposts = dataPost[i].Reposts.Count,
                                date = Convert.ToDateTime(dataPost[i].Date)
                            };
                            db.Post.Add(post);
                            db.SaveChanges();
                        }
                    };
                    offset += stepOffset;
                    processedPosts += stepOffset;
                }
                catch (System.Net.WebException)
                {
                    //Console.WriteLine("Соединение потеряно");
                }
                catch (VkNet.Exception.TooManyRequestsException)
                {
                    //Console.WriteLine("Увеличелось время запроса на " + requestPause);
                    requestPause += 0.100;
                };
                //offset += stepOffset;
                //processedPosts += stepOffset;
                //} while (totalCountPosts > processedPosts);
            } while (processedPosts < 50);
        }
    }
}
