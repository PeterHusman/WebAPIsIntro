using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIsIntro.Models
{
    public class Msg
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return $"{Sender}: {Message}";
        }
    }
}
