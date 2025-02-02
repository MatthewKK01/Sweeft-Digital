 using System.Net;
 using System.Text.Json;

 class Program{

     public static async Task Main()
     {
         GenerateCountryDataFiles();
     }

     public static void GenerateCountryDataFiles()
     {
         var url = "https://restcountries.com/v3.1/all"; 
         using HttpClient client = new HttpClient();
         client.DefaultRequestHeaders.Add("Accept", "application/json");
         
         try
         {
             Task<HttpResponseMessage> response = client.GetAsync(url);
             HttpResponseMessage httpResponseMessage =  response.Result;
             var statusCode = (int)httpResponseMessage.StatusCode;

             if (statusCode == 200)
             {
                 var messageContent = httpResponseMessage.Content;
                 Task<string> responseData =  messageContent.ReadAsStringAsync();
                 var data = responseData.Result;
                 var countries = JsonSerializer.Deserialize<Country[]>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });             
                 
                 if (countries is not null)
                 {
                     foreach (var country in countries)
                     {
                         string countryName = country.Name.Common.Replace(" ", "_"); 
                         string fileName = $"{countryName}.txt";

                         string content = $"Region: {country.Region}\n" +
                                          $"Subregion: {country.Subregion}\n" +
                                          $"Latitude/Longitude: {string.Join(", ", country.LatLng)}\n" +
                                          $"Area: {country.Area} sq km\n" +
                                          $"Population: {country.Population}\n";

                         File.WriteAllTextAsync(fileName, content);
                         Console.WriteLine($"Saved: {fileName}");
                         
                         // ფაილები ინახება bin>debug>net9.0 ში
                     }
                 }
             }
             else
             {
                 Console.WriteLine(httpResponseMessage.StatusCode);
             }

             client.Dispose();
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw;
         }
     }
     public class Country
     {
         public NameInfo Name { get; set; }
         public string Region { get; set; }
         public string Subregion { get; set; }
         public double[] LatLng { get; set; }
         public double Area { get; set; }
         public long Population { get; set; }
     }

     public class NameInfo
     {
         public string Common { get; set; } 
     }
}