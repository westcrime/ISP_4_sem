using System.Text.Json;
using System.Text.Json.Nodes;
using Lab4.Models;

namespace Lab4.Services;

public class RateService: IRateService
{
    private HttpClient httpClient;
    
    public async Task<IEnumerable<Rate>> GetRates(DateTime dateTime)
    {
        var responseString =
            $"https://www.nbrb.by/api/exrates/rates?ondate={dateTime.ToString("yyyy-MM-dd")}&periodicity=0";
        var response = await httpClient.GetAsync(responseString);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error in http request");
        }

        var message = JsonSerializer.Deserialize<ICollection<Rate>>(await response.Content.ReadAsStringAsync());
        return message;
    }

    public RateService()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates");
    }
}