﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API.Models
{
	public class AbstractModel
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}

