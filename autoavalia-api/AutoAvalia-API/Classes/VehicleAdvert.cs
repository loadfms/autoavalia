using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmotors.Shared.Database;

namespace AutoAvalia_API.Classes
{
    public class VehicleAdvert : IEntity<int>
    {
		public int Id { get; set; }
		public Seller Selle { get; set; }
        public Prices Prices { get; set; }
        public string LongComment { get; set; }
        public Media Media { get; set; }
	}

    public class Seller
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class Prices
    {
        public decimal Price { get; set; }
        public decimal SearchPrice { get; set; }
    }

    public class Media
    {
        public List<Photo> Photos { get; set; }
    }

    public class Photo
    {
        public string PhotoPath { get; set; }
        public int Order { get; set; }
    }

    public class Specification
    {
        public string Title { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public Version Version { get; set; }
        public int YearFabrication { get; set; }
        public int YearModel { get; set; }
        public int Odometer { get; set; }
        public int NumberPorts { get; set; }
        public Color Color { get; set; }
        public string Transmition { get; set; }
        public string Fuel { get; set; }
        public string Plate { get; set; }
        public ReplacementParts ReplacementParts { get; set; }
    }

    public class Make
    {
        public string Value { get; set; }
    }

    public class Model
    {
        public string Value { get; set; }
    }

    public class Version
    {
        public string Value { get; set; }
    }

    public class Color
    {
        public string Primary { get; set; }
    }

    public class ReplacementParts
    {
        public string Token { get; set; }
        public List<Part> Parts { get; set; }
    }

    public class Part
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}