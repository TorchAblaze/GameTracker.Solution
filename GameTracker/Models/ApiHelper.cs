// using System.Threading.Tasks;
// using RestSharp;

// namespace GameTracker.Models
// {
//   class ApiHelper
//   {
//     public static async Task<string> ApiCall(string searchTerm)
//     {
//       RestClient client = new RestClient($"https://www.cheapshark.com/api/1.0/games?title={searchTerm}");
//       RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
//       var response = await client.ExecuteTaskAsync(request);
//       return response.Content;
//     }
//   }
// }