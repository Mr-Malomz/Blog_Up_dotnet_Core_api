using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogUp.Models
{
    public class BlogModel
    {
        public string id { get; set; }
        public string author { get; set; }
        public Byte[] avatar { get; set; }
        public string title { get; set; }
        public string uri { get; set; }
        public string createdAt { get; set; }
    }
}
