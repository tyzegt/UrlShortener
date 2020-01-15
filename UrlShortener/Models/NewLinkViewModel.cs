using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Web.Models
{
    public class NewLinkViewModel
    {
        [Required(ErrorMessage = "Введите ссылку")]
        [RegularExpression(@"https?:\/\/[a-zA-Z0-9.\/]+.[a-z]*[a-zA-Z0-9.\/_?=%\-\&]*", ErrorMessage = "Введите корректный Url")]
        public string LinkToAdd { get; set; }
    }
}
