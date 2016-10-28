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
        private readonly IMongoDatabase _db;

        public UserRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public User FindUserByEmail(string email)
        {
            var userCollection = _db.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("email", email);
            return userCollection.Find(filter).FirstOrDefault();
        }
    }
}
