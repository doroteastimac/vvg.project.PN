using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Model.PN.model
{
    [Table("mjesto_putovanja")]
    public class MjestoPutovanja:BaseEntity
    {
        [JsonPropertyName("naziv_mjesta")]
        [Column("naziv_mjesta")]
        public string? NazivMjesta { get; set; }
    }
}
