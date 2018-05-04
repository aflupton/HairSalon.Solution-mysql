using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonApp.Controllers
{
  public class StylistController : Controllers
  {

    [HttpGet("/Stylists")]
    public ActionResult CreateForm()
    {
      return View("Form"); //create a form and return as a view
    }

    [HttpPost("/Stylists/AddStylist")]
    public ActionResult AddStylist()
    {
      string stylistName = Request.Form["name"];
      string hireDate = Request.Form["hireDate"];
      int numberOfClients = int.Parse(Request.Form["numberOfClients"]);
      Stylist newStylist = new Stylist(stylistName, stylistId, hireDate, numberOfClients);
      newStylist.AddStylistToList();
      List<Stylist> listOfStylists = Stylist.GetAllStylists();
      return View("/Index", listOfStylists); //add a new stylist object to the database, and return as a list item to the Index view
    }

    [HttpGet("/Stylists/SeeStylists")]
    public ActionResult SeeStylists()
    {
      return View("/Index", listOfStylists);
    }

    [HttpGet("/Stylists/DeleteStylist")]
    public ActionResult DeleteStylist()
    {
      Stylist.DeleteAllStylists();
      return View("/Index");
    }
  }
}
