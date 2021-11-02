using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RarityScore.Models
{
    public class AttributesResult
    {
        public string Name { get; set; }
        public List<MetadataAttribute> MetadataAttributes { get; set; } = new();


        public static List<AttributesResult> MapAttributes(Dictionary<string, Dictionary<string, Dictionary<string, decimal>>> jsonAttributes)
        {
            var attributes = new List<AttributesResult>();
            foreach (var jsonAttribute in jsonAttributes.GroupBy(m => m.Key))
            {
                foreach (var attribute in jsonAttribute.Where(j => j.Key == jsonAttribute.Key))
                {
                    var traitResult = new AttributesResult();
                    traitResult.Name = jsonAttribute.Key;

                    foreach (var trait in attribute.Value)
                    {
                        var metadata = new MetadataAttribute();
                        metadata.TraitName = trait.Key;

                        foreach (var property in trait.Value)
                        {
                            if (property.Key == "count")
                                metadata.Count = property.Value;

                            if (property.Key == "percentage")
                                metadata.Rarity = property.Value;
                        }

                        traitResult.MetadataAttributes.Add(metadata);
                    }
                    attributes.Add(traitResult);
                }

            }
            return attributes;
        }
    }

    public class MetadataAttribute
    {

        public string TraitName { get; set; }
        public decimal Count { get; set; }
        public decimal Rarity { get; set; }
    }

}
