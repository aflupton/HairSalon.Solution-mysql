using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonApp.Controllers
{
  public class ClientController : Controllers
  {
    [HttpGet("/Clients")]
    public ActionResult CreateForm()
    {
      return View(); //return a form to create a new client object
    }

    [HttpPost("/Clients/AddClient")]
    public ActionResult AddClient()
    {
      string stylistName = Request.Form["name"];
      int clId = int.Parse(Request.Form["clientId"]);
      string clName = Request.Form["clName"];
      int clPrice = int.Parse(Request.Form["clPrice"]);
      string clStyle = Request.Form["clStyle"];
      string clNextAppointmentDate = Request.Form["nextDate"];
      Client newClient = new Client(stylistName, clId, clName, clPrice, clStyle, clNextAppointmentDate);
      newClient.AddClientToList();
      List<Client> listOfClients = Client.GetAllClients();
      return View("/Index", listOfClients); //add a new client object to the database, and return as a list item to the Stylist view
    }

    [HttpGet("/Clients/Details")]
    public ActionResult Details()
    {
      return View("Client", listOfClients); //return details about a specific client by making client iterations accessible through a client view
    }

    [HttpGet("/Clients/SeeClients")]
    public ActionResult SeeClientss()
    {
      List<Client> listOfClients = Client.GetAllClients();
      return View("/Index", listOfClients); //return a list of clients, indexed by name, to the index view
    }

    [HttpGet("/Stylists/DeleteClient")]
    public ActionResult DeleteClient()
    {
      Stylist.DeleteAllClients();
      return View("/Index"); //delete a client
    }
  }
}
