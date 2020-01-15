using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Web.DbModels
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Key { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClicksCount { get; set; }
    }
}
