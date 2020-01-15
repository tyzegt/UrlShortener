using System.Collections.Generic;
using UrlShortener.Web.DbModels;

namespace UrlShortener.Web.DbService
{
    public interface IRepository
    {
        public void CreateNewLink(string url);
        public Link GetLongUrl(string key);
        public void DeleteLink(string key);
        public List<Link> GetAllLinks();
        public void IncreaseClickCounter(string key);

    }
}
