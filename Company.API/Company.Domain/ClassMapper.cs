using Company.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain
{
    public class ClassMapper
    {
        public static void MapDomainModels()
        {
            BsonClassMap.RegisterClassMap<User>();
        }
    }
}
