using System;
using System.Collections.Generic;
using HairSalonApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HairSalonApp.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
    }
    [TestMethod]
    public void Salon_AcceptInput_True()
    {
      //Arrange
      Stylist newStylist = new Stylist("Andrew", "5-1-2018", 2);
      //Act
      bool nameStatus = newStylist.GetClName();
      //Assert
      Assert.AreEqual("Andrew", nameStatus);

    }
  }
}
