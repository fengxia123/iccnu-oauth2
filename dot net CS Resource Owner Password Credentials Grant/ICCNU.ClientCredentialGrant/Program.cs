using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using ClouDeveloper.Mime;
using DotNetOpenAuth.OAuth2;
using System.Net.Http;
using Newtonsoft.Json;

namespace ICCNU.ClientCredentialGrant
{
    class Program
    {
        private static WebServerClient _webServerClient;
        private static string _accessToken;
        private static Uri authorizationServerUri;

        private static string RootId;

        static void Main(string[] args)
        {
#if DEBUG
            authorizationServerUri = new Uri("http://localhost.:3000/");
#else
            authorizationServerUri = new Uri("http://www.iccnu.net/");
#endif

            InitializeWebServerClient();

            Console.WriteLine("Starting...");

            TokenApi();
        }

        static public void TokenApi()
        {
            //For OAuth2 User
            Console.WriteLine("Requesting Token...");
            RequestToken();
            Console.WriteLine(_accessToken);
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Get Me...");
            GetMe();
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Get Root Directories...");
            GetRootDirectories();
            Console.ReadLine();
        }

        private static void GetRootDirectories()
        {
            var client = new HttpClient(_webServerClient.CreateAuthorizingHandler(_accessToken));
            var body = client.GetStringAsync(new Uri(authorizationServerUri, "/api/disk/" + RootId)).Result;
            Console.WriteLine(body);
        }

        private static void InitializeWebServerClient()
        {

            var authorizationServer = new AuthorizationServerDescription
            {
                AuthorizationEndpoint = new Uri(authorizationServerUri, "/oauth2/authorize"),
                TokenEndpoint = new Uri(authorizationServerUri, "/api/oauth2/token"),
            };

            _webServerClient = new WebServerClient(authorizationServer, "resource_owner_test", "resource_owner_test");
        }

        private static void RequestToken()
        {
            var state = _webServerClient.ExchangeUserCredentialForToken("testuser", "testuser");
            _accessToken = state.AccessToken;
        }

        private static void GetMe()
        {
            var client = new HttpClient(_webServerClient.CreateAuthorizingHandler(_accessToken));

            var body = client.GetStringAsync(new Uri(authorizationServerUri, "/api/oauth2/me")).Result;

            RootId = JsonConvert.DeserializeObject<RootDirectory>(body).rootDirectory;

            Console.WriteLine(body);
        }
    }

    public class RootDirectory
    {
        // ReSharper disable once InconsistentNaming
        public string rootDirectory { get; set; }
    }
}
