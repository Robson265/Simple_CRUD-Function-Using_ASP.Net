using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos
{
    public class UpdateCountry
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Continent { get; set; } = string.Empty;
    }
}
