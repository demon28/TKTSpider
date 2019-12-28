using DotnetSpider.Core;
using DotnetSpider.Core.Downloader;
using DotnetSpider.Core.Scheduler;
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

            DotnetSpider.Core.Spider spider = DotnetSpider.Core.Spider.Create(site, new QueueDuplicateRemovedScheduler(), new TouTiaoPageProcessor());
            spider.AddPipeline(new TotiaoPipeline());
            spider.Downloader = new HttpClientDownloader();
            spider.ThreadNum = 1;
            spider.EmptySleepTime = 3000;

            // Start crawler 启动爬虫
            spider.Run();

        }
    }
}
