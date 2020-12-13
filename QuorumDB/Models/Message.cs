using System;
using System.Collections.Generic;
using System.Text;

namespace QuorumDB.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;
    }
}
