using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Logic;
using UrlShortener.Web.DbModels;

namespace UrlShortener.Web.DbService
{
    public class Repository : IRepository
    {
        public List<Link> GetAllLinks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var links = db.Links.ToList();
                return links;
            }
        }

        public Link GetLongUrl(string key)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var link = db.Links.Where(x => x.Key == key).FirstOrDefault();
                if (link != null) return link;
                else return null;
            }
        }

        public void CreateNewLink(string url)
        {            
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Links.Where(x => x.Url == url).Any()) 
                    return;

                Link link = new Link()
                {
                    ClicksCount = 0,
                    Url = url,
                    Key = CreateKey(), 
                    CreationDate = DateTime.Now
                };
                db.Links.Add(link);
                db.SaveChanges();
            }
        }

        public void DeleteLink(string key)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var link = db.Links.Where(x => x.Key == key).FirstOrDefault();
                if (link != null) {
                    db.Remove(link);
                    db.SaveChanges();
                }
            }
        }

        public void IncreaseClickCounter(string key)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var link = db.Links.Where(x => x.Key == key).FirstOrDefault();
                if (link != null)
                {
                    link.ClicksCount++;
                    db.SaveChanges();
                }
            }
        }

        string CreateKey()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var key = KeyGenerator.GetRandomKey();
                if (db.Links.Where(x => x.Key == key).Any())
                    return CreateKey();
                else
                    return key;
            }
        }
    }
}
