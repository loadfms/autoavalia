﻿using Webmotors.Shared.Database;

namespace Webmotors.Api.Classes
{
    public class Answer : Entity
    {
        public int UserId { get; set; }
		public int AdvertiseId { get; set; }
		public int PartId { get; set; }
        public string Photo { get; set; }
    }
}