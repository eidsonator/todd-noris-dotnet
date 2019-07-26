using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ToddNorris.Models
{
    public class ToddNorris
    {
        private static readonly HttpClient Client = new HttpClient();

        public string Get()
        {
            Task<string> requestTask = RequestTask();
            requestTask.Wait();
            var jokeObject = JsonConvert.DeserializeObject<JokeObject>(requestTask.Result);
            
            return jokeObject.Value.Replace("Chuck", "Todd").Replace("chuck", "Todd").Replace("Norris'", "Eidson's").Replace("Norris", "Eidson");
        }

        private async Task<string> RequestTask()
        {
            
             return await Client.GetStringAsync("https://api.chucknorris.io/jokes/random");
        }
        
    }
}