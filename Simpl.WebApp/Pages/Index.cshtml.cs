using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simpl.WebApp.Network.API.Firebase;
using Simpl.WebApp.Network.API.Firebase.ResponseModels;

namespace Simpl.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public bool ButtonPressed;
        public void OnGet()
        {

        }

        public async void OnPostLoginAsync()
        {
            FirebaseManager firebaseManager = new FirebaseManager();
            VerifyLoginResponseModel responseModel = firebaseManager.VerifyLogin(Email, Password);
            if (responseModel.Success)
            {
                // login successful
            } else
            {
                Debug.WriteLine("Login Failed");// login not successful
            }
           
        }

    }
}
