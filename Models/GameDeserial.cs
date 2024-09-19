using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace GamingAPI.Models

{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

    }

    public class ShortScreenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }


    public class Platform
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }
    }

    public class ParentPlatform
    {
        [JsonPropertyName("platform")]
        public Platform? Platform { get; set; }
    }

    public class AddedByStatus
    {
        [JsonPropertyName("yet")]
        public int? Yet { get; set; }

        [JsonPropertyName("owned")]
        public int? Owned { get; set; }

        [JsonPropertyName("beaten")]
        public int? Beaten { get; set; }

        [JsonPropertyName("toplay")]
        public int? ToPlay { get; set; }

        [JsonPropertyName("dropped")]
        public int? Dropped { get; set; }

        [JsonPropertyName("playing")]
        public int? Playing { get; set; }
    }


    public class GameDeserial
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("released")]
        public string? Released { get; set; }

        [JsonPropertyName("background_image")]
        public string? Background_Image { get; set; }

        [JsonPropertyName("metacritic")]
        public int? Metacritic { get; set; }

        [JsonPropertyName("rating")]
        public float? Rating { get; set; }
        
        [JsonPropertyName("reviews_count")]
        public int? Reviews_Count { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre>? Genres { get; set; }  // Add this property for genres
    
        [JsonPropertyName("short_screenshots")]
        public List<ShortScreenshot>? ShortScreenshots { get; set; } // Add this property for screenshots

        // New property for Parent Platforms
        [JsonPropertyName("parent_platforms")]
        public List<ParentPlatform>? ParentPlatforms { get; set; } // Adding ParentPlatforms

        // New property for added_by_status
        [JsonPropertyName("added_by_status")]
        public AddedByStatus? AddedByStatus { get; set; }
    }

    public class ApiResponse
    {
        [JsonPropertyName("results")]
        public List<GameDeserial>? Results { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }
}