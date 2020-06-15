using System;
using System.Collections.Generic;
using System.Text;

namespace Four1Property.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityModel> Cities { get; set; }
        public override string ToString() => Name;
    }
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
