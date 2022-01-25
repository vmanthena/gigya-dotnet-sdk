using System.Collections.Generic;
using System;
using Gigya.Socialize.SDK;
using System.Linq;
using static SDK_Tester.AuthRequestTester;

namespace SDK_Tester
{
    public class SetUserPreferences
    {
        private const string ApiKey = ".....";
        private const string UserKey = ".....";
        const string secretKey = "....";
        const string UserId = "....";
        public static void Run()
        {
            const string GetAccountMethod = "accounts.getAccountInfo";
            const string SetAccountMethod = "accounts.setAccountInfo";
            const string AltriaFlagName = "Test-LOY-TOB1-Nitin";


            GSObject dictionaryParams = new GSObject();

            dictionaryParams.Put("uid", UserId);
            var gsGetAccountDetailsRequest = new GSRequest(ApiKey, secretKey,
                             GetAccountMethod, dictionaryParams, true, UserKey);
            GSResponse accountDatailsResponse = gsGetAccountDetailsRequest.Send();
            var userInfo = accountDatailsResponse.GetData<UserInfoResponse>();

            var profile = accountDatailsResponse.GetData<Profile>("profile", null);

            var schData = accountDatailsResponse.GetObject("data", null);

            if (schData != null && schData.ContainsKey("flags"))
            {
                var existingFlags = schData.GetString("flags")
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .GroupBy(f => f)
                                    .Select(f => f.First());
                var flags = new HashSet<String>(existingFlags);
                if (flags.Add(AltriaFlagName))
                {
                    schData.Put("flags", String.Join(",", flags));
                    dictionaryParams.Put("data", schData);
                    var gsSetAccountDetailsRequest = new GSRequest(ApiKey, secretKey,
                               SetAccountMethod, dictionaryParams, true, UserKey);
                    GSResponse setResponse = gsSetAccountDetailsRequest.Send();
                    var errorCode = setResponse.GetInt("errorCode", 0);
                }

            }
        }

    }
}