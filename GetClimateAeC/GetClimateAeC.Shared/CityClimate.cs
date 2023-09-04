using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GetClimateAeC.Shared
{
    public class CityClimate
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("cidade")]
        public string City_Name { get; set; }
        [JsonPropertyName("estado")]
        public string State { get; set; }
        [JsonPropertyName("atualizado_em")]
        public DateTime Updated_At { get; set; }
        [JsonIgnore]
        public Guid Climate_Id { get; set; }
        [JsonPropertyName("clima")]
        public List<CityClimateArray> ClimateArray { get; set; }
    }

    public class CityClimateArray
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("data")]
        public DateTime Date { get; set; }
        [JsonPropertyName("condicao")]
        public string Condition { get; set; }
        [JsonPropertyName("condicao_desc")]
        public string Condition_Description { get; set; }
        [JsonPropertyName("min")]
        public int Min { get; set; }
        [JsonPropertyName("max")]
        public int Max { get; set; }
        [JsonPropertyName("indice_uv")]
        public int Uv_Index { get; set; }
    }
}