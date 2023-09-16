using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ir.anka.LifeTraders.SandBox
{
    public class RemoteServer
    {
        private string SERVER_URI = @"";

        public RemoteServer(string serverURL)
        {
            SERVER_URI = serverURL;
        }

        public async Task<object> GetAsync(string URL, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    ConfigHttpClient(httpClient);
                    var response = await httpClient.PostAsync(URL, content);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }

        public async Task<object> PostAsync(string URL, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    ConfigHttpClient(httpClient);
                    var response = await httpClient.PostAsync(SERVER_URI + URL, content);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }

        public async Task<object> DeleteAsync(string URL)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    ConfigHttpClient(httpClient);
                    var response = await httpClient.DeleteAsync(URL);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }

        public async Task<(T? result, HttpStatusCode StatusCode, string? ErrorMessage)> SendAsync<T>(string url, HttpMethod method, object? param = null) //, [FromServices] ClaimsPrincipal claimsPrincipal
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var request = new HttpRequestMessage();
                    

                    request.Headers.Accept.Clear();
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Method = method;
                    

                    request.Content = new StringContent(
                        System.Text.Json.JsonSerializer.Serialize(param, typeof(object), new System.Text.Json.JsonSerializerOptions()),
                        Encoding.UTF8, "application/json");

                    request.RequestUri = new Uri(@$"{SERVER_URI}{url}");

                    var response = await httpClient.SendAsync(request);
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                        case HttpStatusCode.BadRequest:
                            return (default(T), response.StatusCode, await response.Content.ReadAsStringAsync());

                        case HttpStatusCode.OK:
                            response.EnsureSuccessStatusCode();
                            return (JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()), response.StatusCode, string.Empty);

                        default:
                            return (default(T), response.StatusCode, await response.Content.ReadAsStringAsync());
                    }
                }
                catch (HttpRequestException httpRequestException)
                {
                    throw httpRequestException;
                }
                catch
                {
                    throw ;
                }
            }
        }

        private void ConfigHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(SERVER_URI);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}