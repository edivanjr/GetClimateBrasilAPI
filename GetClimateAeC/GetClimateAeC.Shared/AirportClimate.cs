using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetClimateAeC.Shared
{
    public class AirportClimate
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("umidade")]
        public int Moisture { get; set; }
        [JsonPropertyName("visibilidade")]
        public string Visibility { get; set; }
        [JsonPropertyName("codigo_icao")]
        public string Code_Icao { get; set; }
        [JsonPropertyName("pressao_atmosferica")]
        public int Atmospheric_Pressure { get; set; }
        [JsonPropertyName("vento")]
        public int Wind { get; set; }
        [JsonPropertyName("direcao_vento")]
        public int Wind_Direction { get; set; }
        [JsonPropertyName("condicao")]
        public string Condition { get; set; }
        [JsonPropertyName("condicao_desc")]
        public string Condition_Description { get; set; }
        [JsonPropertyName("temp")]
        public int Temperature { get; set; }
        [JsonPropertyName("atualizado_em")]
        public DateTime Updated_At { get; set; }
    }
}
