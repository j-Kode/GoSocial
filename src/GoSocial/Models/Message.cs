using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string MessageText { get; set; }
        public string MessageSubject { get; set; }
        public DateTime CreateDate { get; set; }
        public int StatusId { get; set; }
        
        public virtual MessageStatus Status { get; set; }

    }
}
