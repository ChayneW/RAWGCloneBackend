// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// using GamingAPI.Models;
// // using Microsoft.AspNetCore.Mvc;
// using System.Net.Http;
// using System.Text.Json;
// using System.Threading.Tasks;

// namespace GamingAPI.Controllers

// // {
// //     [Route("[controller]")]
// //     public class GameAPI : Controller
// //     {
// //         private readonly ILogger<GameAPI> _logger;

// //         public GameAPI(ILogger<GameAPI> logger)
// //         {
// //             _logger = logger;
// //         }

// //         public IActionResult Index()
// //         {
// //             return View();
// //         }

// //         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
// //         public IActionResult Error()
// //         {
// //             return View("Error!");
// //         }
// //     }
// // }

// {
//     [ApiController]
//     [Route("[controller]")]
//     public class GamesController : ControllerBase
//     {
//         private readonly HttpClient _httpClient;

//         public GamesController(HttpClient httpClient)
//         {
//             _httpClient = httpClient;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetGames()
//         {
//             string apiKey = Environment.GetEnvironmentVariable("RAWG_API_KEY");  // Replace with your RAWG API key
//             System.Console.WriteLine("TESTING API ENV:");
//             System.Console.WriteLine(apiKey);
//             string apiUrl = $"https://api.rawg.io/api/games?key={apiKey}&page=1&page_size=10";

//             HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

//             if (!response.IsSuccessStatusCode)
//             {
//                 return StatusCode((int)response.StatusCode, "Error fetching data from RAWG API");
//             }

//             string jsonData = await response.Content.ReadAsStringAsync();

//             // Deserialize JSON to ApiResponse
//             var options = new JsonSerializerOptions
//             {
//                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//             };
//             ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonData, options);

//             return Ok(apiResponse.Results);
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GamingAPI.Models;
using System.Net.Http;
using System.Text.Json;

namespace GamingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public GamesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            string? apiKey = Environment.GetEnvironmentVariable("RAWG_API_KEY");  // Nullable
            System.Console.WriteLine("TESTING API ENV:");
            System.Console.WriteLine(apiKey);
            
            if (string.IsNullOrEmpty(apiKey))
            {
                return StatusCode(500, "API key is missing in environment variables");
            }

            string apiUrl = $"https://api.rawg.io/api/games?key={apiKey}&page=1&page_size=20";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from RAWG API");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            // Deserialize JSON to ApiResponse
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            ApiResponse? apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonData, options);

            if (apiResponse?.Results == null)
            {
                return NotFound("No results found");
            }

            return Ok(apiResponse.Results);
        }


        // New route for getting a single game by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            Console.WriteLine($"\nReceived request for game ID: {id}\n");
            
            string? apiKey = Environment.GetEnvironmentVariable("RAWG_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                return StatusCode(500, "API key is missing in environment variables");
            }

            // Call the API using the game ID
            string apiUrl = $"https://api.rawg.io/api/games/{id}?key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from RAWG API");
            }

            string jsonData = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a C# object
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            GameDetail? gameDetail = JsonSerializer.Deserialize<GameDetail>(jsonData, options);

            if (gameDetail == null)
            {
                return NotFound("Game not found");
            }

            return Ok(gameDetail);
        }
    }
}