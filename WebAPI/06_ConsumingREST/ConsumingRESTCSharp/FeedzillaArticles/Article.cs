using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedzillaArticles
{
    public class Article
    {
        // "publish_date": "Wed, 07 Aug 2013 11:38:00 +0100",
        //    "source": "Philadelphia Daily News",
        //    "source_url": "http://www.philly.com/philly_business.rss",
        //    "summary": "Intercity bus service has steadily grown nationally and in Philadelphia over\nthe last five years, industry experts say, reversing a slow half-century\ndecline across the nation.\n\n",
        //    "title": "Bus travel is picking up, aided by discount operators (Philadelphia Daily News)",
        //    "url": "http://news.feedzilla.com/en_us/stories/324482343?q=philadelphia&client_source=api&format=json"

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Url { get; set; }

        public string Source { get; set; }

        public string Summary { get; set; }
    }
}
