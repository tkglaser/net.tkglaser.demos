using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace net.tkglaser.demos.Models.TwitterFeed
{
    public class User
    {
        public string profile_image_url { get; set; }
    }

    public class Url
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class Entity
    {
        public List<Url> urls { get; set; }
    }

    public class Tweet
    {
        public string created_at { get; set; }
        public string text { get; set; }
        public User user { get; set; }
        public List<Entity> entities { get; set; }
        public string GetTextWithLinks()
        {
            var result = text;

            foreach (var entity in entities)
            {
                foreach (var url in entity.urls)
                {
                    result = result.Replace(
                      url.url,
                      string.Format("<a href='{0}'>{1}</a>",
                        url.expanded_url,
                        url.display_url));
                }
            }

            return result;
        }
    }

    public class LandingModel
    {
        public List<Tweet> Tweets { get; set; }
    }
}