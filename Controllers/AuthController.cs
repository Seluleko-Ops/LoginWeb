using ASTechWeb.Models;
using ASTechWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using System.Web.mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTechWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService authService;

        public AuthController()
        {
            authService = new AuthService();
        }

        //GET Auth
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind(Prefix = "LoginMForm")] LoginM model, string returnURL)
        {
            if (ModelState.IsValid)
            {
                var result = await authService.Authenticate(model);

                if(result!=null)
                {
                    if(result.IsSuccessful)
                    {
                        var LoggedInUser = JsonConvert.DeserializeObject<UserM>(JsonConvert.SerializeObject(result.Data));
                        TempData["IdNumber"] = LoggedInUser.IdNumber;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = result.Message;
                    }
                }
            }
            return View();
        }

        public IActionResult LogOut()
        {
            _ = TempData["IdNumber"] != null;
            return RedirectToAction("Index", "Home");
            
        }
    }
}
