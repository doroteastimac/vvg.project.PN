using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Model.PN.model
{
    [Table("vozilo")]
    public class Vozilo:BaseEntity

    {
        [JsonPropertyName("marka")]
        [Column("marka")]
        public string? Marka { get; set; }



        [JsonPropertyName("registracija")]
        [Column("registracija")]
        public string? Registracija { get; set; }

    }
}
