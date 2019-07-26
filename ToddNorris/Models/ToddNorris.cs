using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ToddNorris.Models
{
    public class ToddNorris
    {
        private static readonly HttpClient Client = new HttpClient();
        private string firstName = null;
        private string lastName = null;
        
        public ToddNorris(string fName, string lName)
        {
            if (fName == null)
            {
                firstName = "Todd";
                lastName = "Eidson";
            }
            else
            {
                firstName = fName;
                lastName = lName;
            }
        }
        
        public string Get()
        {
            Task<string> requestTask = RequestTask();
            requestTask.Wait();
            var jokeObject = JsonConvert.DeserializeObject<JokeObject>(requestTask.Result);
            
            return jokeObject.Value.Replace("Chuck", firstName).Replace("chuck", firstName).Replace("Norris'", lastName + "'s").Replace("Norris", lastName);
        }

        private async Task<string> RequestTask()
        {
            
             return await Client.GetStringAsync("https://api.chucknorris.io/jokes/random");
        }
        
    }
}