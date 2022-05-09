﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace Model.PN.model
{
    [Table("putni_troskovi")]
    public class PutniTroskovi:BaseEntity
    {
        [JsonPropertyName("iznos_troska")]
        [Column("iznos_troska")]
        public double? IznosTroska { get; set; }

        [JsonPropertyName("vrsta_troska")]
        [Column("vrsta_troska_id")]
        public int VrstaTroska { get; set; }
    }
}
