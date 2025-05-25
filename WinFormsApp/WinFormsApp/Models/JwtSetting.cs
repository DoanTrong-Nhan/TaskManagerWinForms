using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    public class JwtSetting
    {
        public string? Secret { get; set; }
        public int ExpiryHours { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
