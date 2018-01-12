using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Models
{
    public class LoginModel
    {
        [FromForm]
        public string grant_type { get; set; }

        [FromForm]
        public string client_id { get; set; }

        [FromForm]
        public string client_secret { get; set; }

        [FromForm]
        public string refresh_token { get; set; }
    }
}
