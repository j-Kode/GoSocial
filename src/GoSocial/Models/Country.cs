using System;
using System.Collections.Generic;

namespace GoSocial.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Country1 { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
