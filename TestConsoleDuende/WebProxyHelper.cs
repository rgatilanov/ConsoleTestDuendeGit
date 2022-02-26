using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleDuende
{
    public static class WebProxyHelper
    {
        public static Boolean GetAuthenticateResponse()
        {
            var client = new HttpClient();
            var token = TokenHelper.GetAccessToken();
            client.DefaultRequestHeaders.Authorization= new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token.AccessToken);
            return true;
        }
    }
}
