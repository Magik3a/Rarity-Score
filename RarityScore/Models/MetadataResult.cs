using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RarityScore.Models
{
    public class MetadataResult
    {
        [JsonPropertyName("Background")]
        public string Background { get; set; }

        [JsonPropertyName("Suit")]
        public string Suit { get; set; }

        [JsonPropertyName("Suit Accents")]
        public string SuitAccents { get; set; }

        [JsonPropertyName("Suit Accessories")]
        public string SuitAccessories { get; set; }

        [JsonPropertyName("Hand Accessories")]
        public string HandAccessories { get; set; }

        [JsonPropertyName("Face")]
        public string Face { get; set; }

        [JsonPropertyName("Face Extras")]
        public string FaceExtras { get; set; }

        [JsonPropertyName("Eyes")]
        public string Eyes { get; set; }

        [JsonPropertyName("Glasses")]
        public string Glasses { get; set; }

        [JsonPropertyName("Hair")]
        public string Hair { get; set; }

        public static MetadataResult MapMetadata(List<Dictionary<string, string>> jsonMetadata)
        {
            var metadata = new MetadataResult();

            foreach (var data in jsonMetadata)
            {
                if (data.First().Value == "Background")
                    metadata.Background = data.Last().Value;

                if (data.First().Value == "Suit")
                    metadata.Suit = data.Last().Value;

                if (data.First().Value == "SuitAccents")
                    metadata.SuitAccents = data.Last().Value;

                if (data.First().Value == "SuitAccessories")
                    metadata.SuitAccessories = data.Last().Value;

                if (data.First().Value == "HandAccessories")
                    metadata.HandAccessories = data.Last().Value;

                if (data.First().Value == "Face")
                    metadata.Face = data.Last().Value;

                if (data.First().Value == "FaceExtras")
                    metadata.FaceExtras = data.Last().Value;

                if (data.First().Value == "Eyes")
                    metadata.Eyes = data.Last().Value;

                if (data.First().Value == "Glasses")
                    metadata.Glasses = data.Last().Value;

                if (data.First().Value == "Hair")
                    metadata.Hair = data.Last().Value;
            }

            return metadata;
        }
    }
}
