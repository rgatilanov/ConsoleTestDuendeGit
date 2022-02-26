using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleDuende
{
    public static class TokenHelper
    {
        const string _clientId = "mtwdm2022";
        const string _clientSecret = "superpassword";
        const string BaseAddress = "https://localhost:7030";

        internal static AuthToken GetAccessToken()
        {
            var fields = new Dictionary<string, string>
            {
                {"scope","ApiWebDuende" },
                {"grant_type","client_credentials" },
            };
            string creds = String.Format("{0}:{1}", _clientId, _clientSecret);
            byte[] bytes = Encoding.ASCII.GetBytes(creds);
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = header;
            client.BaseAddress = new Uri(BaseAddress + "/connect/token");

            var response = client.PostAsync(String.Empty, new FormUrlEncodedContent(fields)).Result;
            string raw = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(raw);
            JToken token;
            if (json.TryGetValue("access_token", out token))
                return JsonConvert.DeserializeObject<AuthToken>(json.ToString());
            
            return null;
        }
    }
}
