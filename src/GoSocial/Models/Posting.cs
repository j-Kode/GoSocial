using System;
using System.Collections.Generic;

namespace GoSocial.Models
{
    public partial class Posting
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int PlatformId { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal Price { get; set; }
        public int? PromotionType { get; set; }
        public int? Type { get; set; }
        public long FollowersRequired { get; set; }
        public int IndustryId { get; set; }

        public virtual City City { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
