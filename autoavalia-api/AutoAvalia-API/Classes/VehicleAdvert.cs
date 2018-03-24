﻿using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
	[BsonIgnoreExtraElements]
	public class VehicleAdvert : Entity
    {
        public Seller Seller { get; set; }
		public Prices Prices { get; set; }
        public string LongComment { get; set; }
        public Media Media { get; set; }
    }

	[BsonIgnoreExtraElements]
	public class Seller : IEntity<long>
	{
	    [BsonRepresentation(BsonType.Int64)]
		public long Id { get; set; }
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
        [BsonRepresentation(BsonType.Int64)]
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}