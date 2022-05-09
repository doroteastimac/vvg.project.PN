using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Model.PN.model
{
    [Table("radno_mjesto")]
    public class RadnoMjesto:BaseEntity
    {
        [JsonPropertyName("naziv")]
        [Column("naziv")]
        public string? Naziv { get; set; }

    }
}
