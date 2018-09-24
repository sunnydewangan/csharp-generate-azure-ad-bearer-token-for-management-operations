using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Generate_Azure_AD_Bearer_Token
{
    class Program
    {
        static void Main(string[] args)
        {
            string _tenantID = "72f988bf-86f1-41af-91ab-2d7cd011db47"; //Active Directory ID
            string _applicationID = "55e5570e-71ad-4765-b8ff-413764920f80"; // Your AD Application ID a.k.s Client ID
            string _applicationSecret = "1LFzpJIoRbhwxEgOEBLA4VmsCDNggR/Sbbofu9RUyGw="; // Your AD Application Secret a.k.s. Client Secret

            string BearerToken = CreateAccessToken(_tenantID, _applicationID, _applicationSecret);
            Console.WriteLine("Bearer " + BearerToken);
            Console.ReadLine();
        }
        public static string CreateAccessToken(string TenantID, string ApplicationID, string ApplicationSecret)
        {
            try
            {
                var context = new AuthenticationContext("https://login.windows.net/" + TenantID);
                ClientCredential clientCredential = new ClientCredential(ApplicationID, ApplicationSecret);
                var tokenResponse = context.AcquireTokenAsync("https://management.azure.com/", clientCredential).Result;
                var accessToken = tokenResponse.AccessToken;
                return accessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
