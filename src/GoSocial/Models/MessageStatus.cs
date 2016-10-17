using System.ComponentModel.DataAnnotations;

namespace GoSocial.Models
{
    public class MessageStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}