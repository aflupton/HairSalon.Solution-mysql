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

    public void AddClientToList()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO 'clients' ('stylistName', 'clId', 'clName', 'stylistPrice', 'clStyle', 'clNextAppointmentDate') VALUES (@ItemStylistName, @ItemClId, @ItemClName, @ItemStylistPrice, @ItemClStyle, @ItemClNextAppointmentDate)";

      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@ItemStylistName";
      stylistName.Value = this._stylistName;
      cmd.Parameters.Add(this);

      MySqlParameter clId = new MySqlParameter();
      clId.ParameterName = "@ItemClId";
      clId.Value = this._ClId;
      cmd.Parameters.Add(this);

      MySqlParameter clName = new MySqlParameter();
      clName.ParameterName = "@ItemClName";
      clName.Value = this._clName;
      cmd.Parameters.Add(this);

      MySqlParameter stylistPrice = new MySqlParameter();
      stylistPrice.ParameterName = "@ItemStylistPrice";
      stylistPrice.Value = this._stylistPrice;
      cmd.Parameters.Add(this);

      MySqlParameter clStyle = new MySqlParameter();
      clStyle.ParameterName = "@ItemClStyle";
      clStyle.Value = this._clStyle;
      cmd.Parameters.Add(this);

      MySqlParameter clNextAppointmentDate = new MySqlParameter();
      clNextAppointmentDate.ParameterName = "@ItemClNextAppointmentDate";
      clNextAppointmentDate.Value = this._clNextAppointmentDate;
      cmd.Parameters.Add(this);

      cmd.ExecuteQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAllClients()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string stylistName = rdr.GetString(1);
        int clId = rdr.GetInt32(2);
        string clName = rdr.GetString(3);
        int clPrice = rdr.GetInt32(4);
        string clStyle = rdr.GetString(5);
        string clNextAppointmentDate = rdr.GetString(6);
        Client newClient = new Client(stylistName, clId, clName, clPrice, clStyle, clNextAppointmentDate);
        allClients.Add(newClient);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static void DeleteAllClients()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE * FROM clients";
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
  }
}
