using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simpl.WebApp.Network.API.Firebase.RequestModels
{
    public class VerifyLoginRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken = true;

        public VerifyLoginRequestModel(string email, string password, bool returnSecureToken = true)
        {
            this.email = email;
            this.password = password;
            this.returnSecureToken = returnSecureToken;
        }

    }
}
