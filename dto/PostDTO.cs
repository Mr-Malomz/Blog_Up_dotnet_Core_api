using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogUp.dto
{
    public class PostDTO
    {
        public string id { get; set; }

        public string author { get; set; }
        public Byte[] avatar { get; set; }
        public string title { get; set; }
        public string uri { get; set; }
        public string createdAt { get; set; }
    }
}
