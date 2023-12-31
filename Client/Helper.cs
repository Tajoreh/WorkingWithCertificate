using Refit;
using SharedData;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Client;

public static class Helper
{
    public static async Task SendDataToWebApp(string data, byte[] signature)
    {
        var webAppApi = RestService.For<IWebAppApi>(SharedData.SharedData.BaseAddressOfServerApi, new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
            UrlParameterFormatter = new DefaultUrlParameterFormatter()
        });
        try
        {
            var dataToSend = new DataDto()
            {
                Value = data,
                Signature = signature
            };
            var response = await webAppApi.SendData(dataToSend);

            Console.WriteLine(response);
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"API Error: {ex.StatusCode} - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
   
}
public interface IWebAppApi
{
    [Post("/verify")]
    Task<string> SendData([AliasAs("data")] DataDto data);
}