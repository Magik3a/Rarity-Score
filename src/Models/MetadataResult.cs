using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RarityScore.Models
{
    public class MetadataProperty
    {
        public string PropertyType { get; set; }
        public string Name { get; set; }
        public decimal Rarity { get; set; } = 0;
        public decimal Count { get; set; } = 0;
        public decimal TotalCount { get; set; } = 0;
        public decimal FloorPrice { get; set; } = 0;

    }
    public class MetadataResult
    {
        public List<MetadataProperty> Metadata { get; set; } = new();

        public static MetadataResult MapMetadata(List<Dictionary<string, string>> jsonMetadata)
        {
            var metadataList = new MetadataResult();

            foreach (var data in jsonMetadata)
            {

                metadataList.Metadata.Add(new MetadataProperty
                {
                    PropertyType = data.First().Value,
                    Name = data.Last().Value
                });
            }

            return metadataList;
        }

        public static MetadataResult MapRarity(MetadataResult metadata, List<AttributesResult> attributes)
        {
            var metadataList = new MetadataResult();
            metadataList.Metadata = metadata.Metadata;
            foreach (var data in metadata.Metadata)
            {
                var propertyTypes = attributes.FirstOrDefault(a => a.Name == data.PropertyType);

                data.Rarity = propertyTypes?.MetadataAttributes.First(s => s.TraitName == data.Name).Rarity??0;
                data.Count = propertyTypes?.MetadataAttributes.First(s => s.TraitName == data.Name).Count ?? 0;

                data.TotalCount = propertyTypes?.MetadataAttributes.Select(s => s.Count).Sum()??0;
            }

            return metadataList;
        }
    }
}
