using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKTSpider.Spider
{
   public class TouTiaoPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var totalVideoElements = page.Selectable.SelectList(DotnetSpider.Core.Selector.Selectors.XPath("//div[@class='item-inner y-box']")).Nodes();

            List<TouTiaoVideo> results = new List<TouTiaoVideo>();

            foreach (var videoElement in totalVideoElements)
            {
                var video = new TouTiaoVideo();
                video.Name = videoElement.Select(DotnetSpider.Core.Selector.Selectors.XPath(".//a[@class='link title']")).GetValue();
                video.Url = videoElement.Select(DotnetSpider.Core.Selector.Selectors.XPath("@href")).GetValue();
                results.Add(video);
            }
            page.AddResultItem("VideoResult", results);
        }
    }
}
