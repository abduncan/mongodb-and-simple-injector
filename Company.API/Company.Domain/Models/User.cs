using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Models
{
    public class User
    {
        public User(string email, string name)
        {
            this.email = email;
            this.name = name;
        }

        public ObjectId id { get; set; }

        public string email { get; set; }

        public string name { get; set; }
    }
}
