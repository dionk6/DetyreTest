using System;
using System.Collections.Generic;

#nullable disable

namespace DetyreTest.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool IsCapital { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public double Budget { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Country Country { get; set; }
    }
}
