using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace api_курсовая.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
         const string KEY = "Key1212121212121212154654987987813215613489789413_987135468791469874___usydygvaueyvbYFFYiugIUTRLTUfluyYFCYvuYFvTDFYTcytdOFcltydFulyf89745324986785641";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {

            return (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)));
        }
    }
}
