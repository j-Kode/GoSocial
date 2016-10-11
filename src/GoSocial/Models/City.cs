using System;
using System.Collections.Generic;

namespace GoSocial.Models
{
    public partial class City
    {
        public City()
        {
            Posting = new HashSet<Posting>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<Posting> Posting { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
