using System.Diagnostics;

using Gigya.Socialize.SDK;

namespace SDK_Tester
{
    public class AuthRequestTester
    {
        /*
        _____   _        __        ____    _   _   _       __     __
       |_   _| | |      /_ |      / __ \  | \ | | | |      \ \   / /
         | |   | |       | |     | |  | | |  \| | | |       \ \_/ / 
         | |   | |       | |     | |  | | | . ` | | |        \   /  
        _| |_  | |____   | |     | |__| | | |\  | | |____     | |   
       |_____| |______|  |_|      \____/  |_| \_| |______|    |_|   

      */
        string apiDomain = "il1.gigya.com";
        private const string ApiDomain = "....";
        private const string ApiKey = "....";
        private const string UserKey = "....";
        private const string PrivateKey = "....";
        const string secretKey = "....";

        public void Run()
        {
            const string method = "accounts.getAccountInfo";
            var req = new GSAuthRequest(
                UserKey,  
                PrivateKey, 
                ApiKey,
                method,
                new
                {
                    uid = "", enabledProviders = "*,testnetwork,testnetwork2"
                })
            {
                APIDomain = ApiDomain
            };

            var res = req.Send();

            var response = res.GetData<UserInfoResponse>();
            
            Debug.Assert(new GSArray(response.emails?.unverified).GetString(0) == "a@a.com");
        }

        public class UserInfoResponse
        {
            public Emails emails;
        }

        public class Emails
        {
            public string unverified;
        }
    }
}