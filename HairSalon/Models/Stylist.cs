using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HairStylistApp.Models
{
  public class Stylist
  {
    private string _stylistName;
    private int _stylistId;
    private string _hireDate;
    private int _numberOfClients;


    public Stylist(string stylistName, int stylistId, string hireDate, int numberOfClients)
    {
      _stylistName = stylistName;
      _stylistId = stylistId;
      _hireDate = hireDate;
      _numberOfClients = numberOfClients;
    }

    public string GetStylistName()
    {
      return _stylistName;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public string GetHireDate()
    {
      return _hireDate;
    }

    public int GetNumberOfClients()
    {
      return _numberOfClients;
    }

    public void AddStylistToList()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO 'stylists' ('stylistName', 'stylistId', 'hireDate', 'numberOfClients') VALUES (@ItemName, @ItemId, @ItemHireDate, @ItemNumberOfClients)";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this._stylistName;
      cmd.Parameters.Add(this);

      MySqlParameter id = new MySqlParameter();
      id.ParameterName = "@ItemId";
      id.Value = this._stylistId;
      cmd.Parameters.Add(this);

      MySqlParameter hireDate = new MySqlParameter();
      hireDate.ParameterName = "@ItemHireDate";
      hireDate.Value = this._hireDate;
      cmd.Parameters.Add(this);

      MySqlParameter numberOfClients = new MySqlParameter();
      numberOfClients.ParameterName = "@ItemNumberOfClients";
      numberOfClients.Value = this._numberOfClients;
      cmd.Parameters.Add(this);

      cmd.ExecuteQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispsoe();
      }
    }

    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string stylistName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        string hireDate = rdr.GetString(3);
        int numberOfClients = rdr.GetInt32(4);
        Stylist newStylist = new Stylist(stylistName, stylistId, hireDate, numberOfClients);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }
  }
}
