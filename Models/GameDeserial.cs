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

    // Class for ParentPlatforms which includes Platform details
    public class ParentPlatform
    {
        [JsonPropertyName("platform")]
        public Platform? Platform { get; set; }
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
        
        [JsonPropertyName("reviews_count")]
        public int? Reviews_Count { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre>? Genres { get; set; }  // Add this property for genres
    
        [JsonPropertyName("short_screenshots")]
        public List<ShortScreenshot>? ShortScreenshots { get; set; } // Add this property for screenshots

        // New property for Parent Platforms
        [JsonPropertyName("parent_platforms")]
        public List<ParentPlatform>? ParentPlatforms { get; set; } // Adding ParentPlatforms
    }

    public class ApiResponse
    {
        [JsonPropertyName("results")]
        public List<GameDeserial>? Results { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }
}