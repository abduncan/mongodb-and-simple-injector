using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Company.Domain.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        // Private backing variable to hold the reference
        // to the injected mongoDb.
        private readonly IMongoDatabase _db;

        // Create a new instance of the UserRepository.
        public UserRepository(IMongoDatabase db)
        {
            // Store the reference to the inject IMongoDatabase
            // instance.
            _db = db;
        }

        public User FindUserByEmail(string email)
        {
            // Get a reference to the users collection in the database.
            var userCollection = _db.GetCollection<User>("users");

            // Create a filter used to filter the collection.
            var filter = Builders<User>.Filter.Eq("email", email);

            // Execute the query.
            return userCollection.Find(filter).FirstOrDefault();
        }
    }
}
