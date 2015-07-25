using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinServiceCrawler
{
    public partial class WinServiceCrawler : ServiceBase
    {
        private Auth auth;
        private CrawlerArticle crawlerArticle;
        private CrawlerStatistic crawlerStatistic;
        private readonly int groupID = 31976785;

        //private StreamWriter logFile;
        private static System.Timers.Timer timerCrawlerArticle;
        private static System.Timers.Timer timercrawlerStatistic;

        //for aethorize (сделать считывание из textbox)
        private static string userEmail = "xxx";
        private static string userPassword = "xxx";

        public WinServiceCrawler()
        {
            InitializeComponent();
            OnTime();
        }

        //private void InitializeCrawler()
        //{
        //    this.auth = new Auth();
        //    this.crawlerArticle = new CrawlerArticle(auth.DoAuthorization(userEmail, userPassword));
        //    this.crawlerArticle.ParsingArticleGroup(groupID);
        //    //Console.WriteLine("crawlerArticle");
        //}
        public void OnTime()
        {
            //logFile = new StreamWriter(new FileStream("CrawlerService.log", System.IO.FileMode.Append));
            //this.logFile.WriteLine("CrawlerService стартовал");
            //this.logFile.Flush();

            timerCrawlerArticle = new System.Timers.Timer();
            timercrawlerStatistic = new System.Timers.Timer();
            timerCrawlerArticle.Enabled = true;
            timercrawlerStatistic.Enabled = true;

            timercrawlerStatistic.Interval = 10000 * 6 * 60 * 24;// каждый день
            timerCrawlerArticle.Interval = 10000 * 6 * 60 * 12; // пол дня
            timercrawlerStatistic.Elapsed += new System.Timers.ElapsedEventHandler(DoParsingStatistic);
            //this.logFile.WriteLine("добавлена запись статистики в бд");
            timerCrawlerArticle.Elapsed += new System.Timers.ElapsedEventHandler(DoParsingArticle);
            //this.logFile.WriteLine("добавлена запись постов в бд");

            timercrawlerStatistic.AutoReset = true;
            timerCrawlerArticle.AutoReset = true;
            timercrawlerStatistic.Start();
            timerCrawlerArticle.Start();
        }

        private void DoParsingStatistic(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.auth = new Auth();
            this.crawlerStatistic = new CrawlerStatistic(auth.DoAuthorization(userEmail, userPassword));
            this.crawlerStatistic.ParsingStatisticGroup(groupID);
            Console.WriteLine("crawlerStatistic");
        }

        private void DoParsingArticle(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.auth = new Auth();
            this.crawlerArticle = new CrawlerArticle(auth.DoAuthorization(userEmail, userPassword));
            this.crawlerArticle.ParsingArticleGroup(groupID);
            Console.WriteLine("crawlerArticle");
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
