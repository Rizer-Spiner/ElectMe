using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ElectMe_WebClient.ECIES;


namespace ElectMe_WebClient.HTTP
{
    public class HttpRequester
    {
        public HttpClient Client { get; set; }

        public Task<string> RetrieveMessage(string url)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ClientVariables.ElectMeBaseURL);
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));
            return Client.GetStringAsync(url);

        }

        public Task<HttpResponseMessage> PostMessage(string message, string url)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ClientVariables.ElectMeBaseURL);
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            StringContent content = new StringContent(message, Encoding.ASCII, "text/plain");
            return Client.PostAsync(url, content);
        }
    }
}