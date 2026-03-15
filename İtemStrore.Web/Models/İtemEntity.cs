using Microsoft.AspNetCore.Mvc.Routing;

namespace İtemStrore.Web.Models
{
    public class İtemEntity
    {
        public Guid Id { get; set; }
        public string İtemName { get; set; } = string.Empty;
        public int İtemPrice { get; set; }
    }
}
