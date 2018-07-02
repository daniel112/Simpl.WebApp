using Newtonsoft.Json;
using Simpl.WebApp.Network.API.Firebase.RequestModels;
using Simpl.WebApp.Network.API.Firebase.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simpl.WebApp.Network.API.Firebase
{
    // config
    //apiKey: "AIzaSyCoszZVMT0_ONqNqSQTVa-1MyWGq0aaoas",
    //authDomain: "simpl-mobile-group.firebaseapp.com",
    //databaseURL: "https://simpl-mobile-group.firebaseio.com",
    //projectId: "simpl-mobile-group",
    //storageBucket: "simpl-mobile-group.appspot.com",
    //messagingSenderId: "233038051131"
    public class FirebaseManager
    {
        #region Variables
        private const string APIKey = "AIzaSyCoszZVMT0_ONqNqSQTVa-1MyWGq0aaoas";
        private const string BaseURLForAuth = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/";
        #endregion

        #region Private API

        #endregion

        #region Public API

        // TODO: Replace webrequest with httpclient ****
        public VerifyLoginResponseModel VerifyLogin(string email, string password)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"{BaseURLForAuth}verifyPassword?key={APIKey}");
            request.Method = "POST";
            request.ContentType = "application/json";

            // get post body data
            VerifyLoginRequestModel requestModel = new VerifyLoginRequestModel(email, password);
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(requestModel);

            var buffer = Encoding.UTF8.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);

            // get response
            // TODO: do error handling
            VerifyLoginResponseModel responseModel = null;
            try
            {
                var response = request.GetResponse();

                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    string responseString = reader.ReadToEnd();
                    if (!String.IsNullOrEmpty(responseString))
                        responseModel = JsonConvert.DeserializeObject<VerifyLoginResponseModel>(responseString);
                }
                responseModel.Success = true;
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                responseModel = new VerifyLoginResponseModel();
                responseModel.Success = false;
                responseModel.Message = message;
            }
            

            return responseModel;
            

        }
        #endregion
    }
}
