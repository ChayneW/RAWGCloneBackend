using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GamingAPI.Models
{
    public class GameDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("background_image")]
    public string? Background_Image { get; set; }

    [JsonPropertyName("background_image_additional")]
    public string? BackgroundImageAdditional { get; set; }

    [JsonPropertyName("metacritic")]
    public int? Metacritic { get; set; }

    [JsonPropertyName("released")]
    public string? Released { get; set; }

    [JsonPropertyName("reviews_count")]
    public int? Reviews_Count { get; set; }

    [JsonPropertyName("genres")]
    public List<Genre>? Genres { get; set; }

    // Any other fields specific to the detailed response

    [JsonPropertyName("parent_platforms")]
        public List<ParentPlatform>? ParentPlatforms { get; set; } // Adding ParentPlatforms
}
}