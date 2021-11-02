using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RarityScore.Models
{
    public class Traits
    {
        [JsonPropertyName("Eyes")]
        public string Eyes { get; set; }

        [JsonPropertyName("Face")]
        public string Face { get; set; }

        [JsonPropertyName("Hair")]
        public string Hair { get; set; }

        [JsonPropertyName("Suit")]
        public string Suit { get; set; }

        [JsonPropertyName("Glasses")]
        public string Glasses { get; set; }

        [JsonPropertyName("Background")]
        public string Background { get; set; }

        [JsonPropertyName("Face Extras")]
        public string FaceExtras { get; set; }

        [JsonPropertyName("Suit Accents")]
        public string SuitAccents { get; set; }

        [JsonPropertyName("Hand Accessories")]
        public string HandAccessories { get; set; }

        [JsonPropertyName("Suit Accessories")]
        public string SuitAccessories { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; }

        [JsonPropertyName("collection_addr")]
        public string CollectionAddr { get; set; }

        [JsonPropertyName("user_addr")]
        public string UserAddr { get; set; }

        [JsonPropertyName("in_settlement")]
        public bool InSettlement { get; set; }

        [JsonPropertyName("src")]
        public string Src { get; set; }

        [JsonPropertyName("image_data")]
        public object ImageData { get; set; }

        [JsonPropertyName("external_url")]
        public object ExternalUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("traits")]
        public Traits Traits { get; set; }

        [JsonPropertyName("background_color")]
        public object BackgroundColor { get; set; }

        [JsonPropertyName("animation_url")]
        public object AnimationUrl { get; set; }

        [JsonPropertyName("youtube_url")]
        public object YoutubeUrl { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("last_trade_price")]
        public double? LastTradePrice { get; set; }

        [JsonPropertyName("likes_count")]
        public object LikesCount { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("bid")]
        public double? Bid { get; set; }

        [JsonPropertyName("accepting_counters")]
        public bool AcceptingCounters { get; set; }

        [JsonPropertyName("listing_time")]
        public int ListingTime { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("rarity")]
        public double Rarity { get; set; }
    }

    public class RandomearthModels
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }
    }
}
