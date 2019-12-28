using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;

namespace TKTSpider.Spider
{
    /// <summary>
    /// 定义数据管道,数据管道可以通过在PageProcessor中指定的唯一Key，取出需要处理的数据存入想要的数据库或文件中
    /// </summary>
    public class TotiaoPipeline : BasePipeline
    {
        public override void Process(IEnumerable<ResultItems> resultItems, ISpider spider)
        {
            throw new NotImplementedException();
        }
    }
}
