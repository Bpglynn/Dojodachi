using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
		    // Convert object to serialized JSON
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static Pet GetObjectFromJson<Pet>(this ISession session, string key)
        {
		    // Convert serialized JSON into object
            string value = session.GetString(key);
            return value == null ? default(Pet) : JsonConvert.DeserializeObject<Pet>(value);
        }
    }
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            // Attempt to retrieve the Pet from session
            
            if (HttpContext.Session.GetString("Pet") == null) {
                // No pet found, create a new one
                Pet FreshDojodachi = new Pet();
                HttpContext.Session.SetObjectAsJson("Pet", FreshDojodachi);
                return View("Index", FreshDojodachi);
            } else {
                // Pet found, capture it from JSON string back to object
                Pet Dojodachi = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
                if (Dojodachi.isDead) {
                    return View("Died", Dojodachi);
                } else if (Dojodachi.isWinner) {
                    return View("Winner", Dojodachi);
                } else {
                    return View("Index", Dojodachi);
                }
            }
        }
        [Route("1")]
        [HttpGet]
        public IActionResult Feed()
        {
            if (HttpContext.Session.GetString("Pet") == null) {
                return Redirect("/");
            } else {
                Pet Dojodachi = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
                Dojodachi.Feed();
                HttpContext.Session.SetObjectAsJson("Pet", Dojodachi);
                return Redirect("/");
            }
        }
        [Route("2")]
        [HttpGet]
        public IActionResult Play()
        {
            if (HttpContext.Session.GetString("Pet") == null) {
                return Redirect("/");
            } else {
                Pet Dojodachi = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
                Dojodachi.Play();
                HttpContext.Session.SetObjectAsJson("Pet", Dojodachi);
                return Redirect("/");
            }
        }
        [Route("3")]
        [HttpGet]
        public IActionResult Work()
        {
            if (HttpContext.Session.GetString("Pet") == null) {
                return Redirect("/");
            } else {
                Pet Dojodachi = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
                Dojodachi.Work();
                HttpContext.Session.SetObjectAsJson("Pet", Dojodachi);
                return Redirect("/");
            }
        }
        [Route("4")]
        [HttpGet]
        public IActionResult Sleep()
        {
            if (HttpContext.Session.GetString("Pet") == null) {
                return Redirect("/");
            } else {
                Pet Dojodachi = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
                Dojodachi.Sleep();
                HttpContext.Session.SetObjectAsJson("Pet", Dojodachi);
                return Redirect("/");
            }
        }
        [Route("5")]
        [HttpGet]
        public IActionResult Reset()
        {
            if (HttpContext.Session.GetString("Pet") == null) {
                return Redirect("/");
            } else {
                HttpContext.Session.Clear();
                return Redirect("/");
            }
        }
    }
    
}
