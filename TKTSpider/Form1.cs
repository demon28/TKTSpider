using DotnetSpider.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKTSpider.Spider;

namespace TKTSpider
{
    public partial class Form1 : BaseForm.BaseFrom
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_star_Click(object sender, EventArgs e)
        {
            CustmizeProcessorAndPipeline();
        }

        private void CustmizeProcessorAndPipeline()
        {
            var site = new Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            string url = this.tb_url.Text;

            site.AddStartUrl(url);

            Spider spider = Spider.Create(site,
                // use memoery queue scheduler. 使用内存调度
                new QueueDuplicateRemovedScheduler(),
                // use custmize processor for youku 为优酷自定义的 Processor
                new TouTiaoPageProcessor())
                // use custmize pipeline for youku 为优酷自定义的 Pipeline
                .AddPipeline(new YoukuPipeline());
            spider.Downloader = new HttpClientDownloader();
            spider.ThreadNum = 1;
            spider.EmptySleepTime = 3000;

            // Start crawler 启动爬虫
            spider.Run();

        }
    }
}
