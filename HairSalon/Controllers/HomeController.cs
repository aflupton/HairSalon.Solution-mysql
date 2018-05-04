using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(); //return index view
    }
  }
}
