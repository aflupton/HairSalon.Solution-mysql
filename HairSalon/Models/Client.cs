using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HairSalonApp.Models
{
  public class Client
  {
    private string _stylistName;
    private int _clId;
    private string _clName;
    private int _clPrice;
    private string _clStyle;
    private string _clNextAppointmentDate;


    private static List<Client> cl = new List<Client> {};

    public Client(string stylistName, int clId, string clName, int clPrice, string clStyle, string clNextAppointmentDate)
    {
      _stylistName = stylistName;
      _clId = clId;
      _clName = clName;
      _clPrice = clPrice;
      _clStyle = clStyle;
      _clNextAppointmentDate = clNextAppointmentDate;
    }

    public string GetClientName()
    {
      return _stylistName;
    }

    public int GetClId()
    {
      return _clId;
    }

    public string GetClName()
    {
      return _clName;
    }

    public int GetPrice()
    {
      return _stylistPrice;
    }

    public string GetClStyle()
    {
      return _clStyle;
    }

    public string GetAppointmentDate()
    {
      return _clNextAppointmentDate;
    }

    // public void Save()
    // {
    //   //code here
    // }
    //
    // public static List<Client> GetAll()
    // {
    //   //code here
    // }
  }
}
