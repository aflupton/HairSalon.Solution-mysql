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
      return View(); //return home page
    }

    [HttpPost("/AddStylist")]
    public ActionResult AddStylist()
    {
      return View("Index"); //add a stylist to salon object, return as a list to the home page
    }

    [HttpPost("/AddClient")]
    public ActionResult AddClient()
    {
      return View("Index"); //add a client to a specific stylist, return as a list item to the stylist list on the home page
    }

    [HttpGet("/ClientDetails")]
    public ActionResult Details()
    {
      return View("Client"); //return details about a specific client on a unique page accessed by linking from the client list on the home page.
    }
  }
}
