using System;
using System.Collections.Generic;

namespace GoSocial.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string State1 { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual Country Country { get; set; }
    }
}
