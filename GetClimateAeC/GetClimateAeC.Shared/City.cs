using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetClimateAeC.Shared
{
    public class City
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonPropertyName("id")]
        [Column("id_city")]
        public int Id_City { get; set; }

        [JsonPropertyName("nome")]
        [Column("city_name")]
        public string City_Name { get; set; }

        [JsonPropertyName("estado")]
        [Column("state")]
        public string State { get; set; }
    }
}
