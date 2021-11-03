using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RarityScore.Configuration;

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
        public string ImageUrl { get; set; }

        public decimal AverageTraitsPercent { get; set; } = 0;
        public decimal RarestTraitPercent { get; set; } = 0;
        public decimal RarestTraitCount { get; set; } = 0;
        public decimal RarestTraitTotalCount { get; set; } = 0;
        public string RarestTraitName { get; set; }
        public decimal TotalRarityScore { get; set; }
        public decimal Rank { get; set; }
        public decimal MaximumRank { get; set; }
        public List<MetadataProperty> Metadata { get; set; } = new();
        
        private static MetadataResult MapMetadata(List<Dictionary<string, string>> jsonMetadata)
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
        
        public static MetadataResult MapTerraResult(TerraContractResult terraContractResult)
        {
            var metadataList = new MetadataResult();

            if (terraContractResult.result != null)
            {

                var paramsDeserialized = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(terraContractResult.result.metadata);
                metadataList = MapMetadata(paramsDeserialized);
            }

            metadataList.ImageUrl = "https://cloudflare-ipfs.com/ipfs/" + terraContractResult.result.image.Split('/').Last();
            return metadataList;
        }

        public static MetadataResult MapRarity(int terranautId, MetadataResult metadata, List<AttributesResult> attributes, List<TerranautRank> ranks)
        {

            decimal totalTraitsScore = 0;
            foreach (var data in metadata.Metadata)
            {
                var propertyTypes = attributes.FirstOrDefault(a => a.Name == data.PropertyType);

                data.Rarity = propertyTypes?.MetadataAttributes.FirstOrDefault(s => s.TraitName == data.Name)?.Rarity??0;

                data.Count = propertyTypes?.MetadataAttributes.FirstOrDefault(s => s.TraitName == data.Name)?.Count ?? 0;

                data.TotalCount = (propertyTypes?.MetadataAttributes.Select(s => s.Count).Sum()??0) - data.Count;

                if(data.TotalCount > 0 && data.Count > 0)
                    totalTraitsScore += 1 / (data.Count / data.TotalCount);
            }

            if (metadata.Metadata.Any(av => av.Rarity > 0))
            {
                var minimumRarityIndex = metadata.Metadata.Where(av => av.Rarity > 0).Min(av => av.Rarity);
                var rarestTrait = metadata.Metadata.FirstOrDefault(av => av.Rarity == minimumRarityIndex);
                if (rarestTrait != null)
                {
                    metadata.RarestTraitCount = rarestTrait.Count;
                    metadata.RarestTraitTotalCount = rarestTrait.TotalCount;
                    metadata.RarestTraitPercent = rarestTrait.Rarity;
                    metadata.RarestTraitName = rarestTrait.Name;
                }
            }

            metadata.AverageTraitsPercent = metadata.Metadata.Select(av => av.Rarity).Average();
            metadata.TotalRarityScore = totalTraitsScore;

            if (ranks != null && ranks.Any())
            {
                metadata.Rank = ranks.FirstOrDefault(r => r.id == terranautId + "")?.rank ?? 0;
                metadata.MaximumRank = ranks.Select(r => r.rank).Max();
            }

            return metadata;
        }
    }
}
