using System;
using API.Models;
using MongoDB.Driver;

namespace API.Data
{
	public class CountryRepository :MongoRepository<Country>
	{
		public CountryRepository(IMongoDatabase database)
            : base(database, "Country")
		{
		}
	}
}

