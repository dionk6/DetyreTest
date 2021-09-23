using System;
using System.Collections.Generic;

#nullable disable

namespace DetyreTest.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int DiallingCode { get; set; }
        public string Currency { get; set; }
        public string OfficialLanguage { get; set; }
        public string Continent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
