using System;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class VisitCounter
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}