using System.Collections.Generic;
using AppStudio.DataProviders.OAuth;

namespace HromadskeTV.OAuth
{
    public static class OAuthTokensRepository
    {
        private static Dictionary<long, OAuthTokens> Tokens { get; set; }

        static OAuthTokensRepository()
        {
            Tokens = new Dictionary<long, OAuthTokens>();


            Tokens.Add(26667, new OAuthTokens
                            {
                                { "AppId", "814151235320992" },
                                { "AppSecret", "ef73bbd43bc7e750d6f49b13bc08a1fd" }
                            });

            Tokens.Add(1429, new OAuthTokens
                            {
                                { "ConsumerKey", "DSCoreZj7Ynqljp3QaYGctA3i" },
                                { "ConsumerSecret", "3LckxvmawMeOCf6XtMU7evb94whX2aZHELshrpTpgvPOSbXPyy" },
                                { "AccessToken", "2169550185-3ffhPHC8G554NZJKl2vsyFSplzex34GvzZVNYSc" },
                                { "AccessTokenSecret", "VRcT8g3xEE6SS8KBj6Qmj1PsCgNOaJDBfO4A4h3fTw9r5" }
                            });

            Tokens.Add(26666, new OAuthTokens
                            {
                                { "ApiKey", "AIzaSyA7Mjy9uhy-Z_n_LoETuONNPZm8dClfGj0" }
                            });

        }

        public static OAuthTokens GetTokens(long key)
        {
            if (Tokens.ContainsKey(key))
            {
                return Tokens[key];
            }
            return null;
        }
    }
}
