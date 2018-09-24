using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Generate_Azure_AD_Bearer_Token
{
    class Program
    {
        static void Main(string[] args)
        {
            string _tenantID = "{Your Tenant ID}"; //Active Directory ID
            string _applicationID = "{Application ID}"; // Your AD Application ID a.k.s Client ID
            string _applicationSecret = "{Application Secret}"; // Your AD Application Secret a.k.s. Client Secret

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
