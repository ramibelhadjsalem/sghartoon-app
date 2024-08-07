using System;
using API.Models;
using MongoDB.Driver;

namespace API.Data
{
	public class SpecialiteRepository : MongoRepository<Specialite>
    {
		public SpecialiteRepository(IMongoDatabase database)
            : base(database, "Specialite")
        {
		}
	}
}

