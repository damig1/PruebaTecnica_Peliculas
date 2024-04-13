using Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace Peliculas.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            Models.Account.Login model = new Models.Account.Login();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Account.Login model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = string.Join("<br>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    Common.Common.ShowErrorMessage(errors);
                    return View(model);
                }

                return AccessLogin(model.UserName, model.Password);
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error al intentar loguearse");
                return View(model);
            }
        }

        public ActionResult AccessLogin(string userName, string password)
        {
            DTO.User user = Business.User.Login(userName, password);
            if (user != null && user.Enabled == true && user.Password == password)
            {
                var redirectResult = Business.Login.RedirUserLogin(user.UserRoleId);
                if (redirectResult.IsValid)
                {
                    return RedirectToAction(redirectResult.Action, redirectResult.Controller, new { Area = redirectResult.Area });
                }
                else
                {
                    Common.Common.ShowErrorMessage("Usuario o contraseña incorrecta");
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                Common.Common.ShowErrorMessage("Usuario o contraseña incorrecta");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Register()
        {
            Models.Account.Register model = new Models.Account.Register();
            model.UserRoleList = new SelectList(Business.UserRole.GetUserRoleList(), "UserRoleId", "Name", model.UserRoleList);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Models.Account.Register model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = string.Join("<br>", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    Common.Common.ShowErrorMessage(errors);
                    return View(model);
                }

                if (Business.User.CheckIfExist(model.UserName))
                {
                    Common.Common.ShowErrorMessage("El usuario ingresado se encuentra en uso");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    Business.User.Register(model.UserName, model.Lastname, model.Document, model.Email, model.UserName, model.Password, model.UserRoleId);
                    Common.Common.ShowSuccessMessage("Usuario registrado correctamente");
                }
            }
            catch (Exception ex)
            {
                Common.Common.LogAndShowError(ex, "Error al intentar loguearse");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}