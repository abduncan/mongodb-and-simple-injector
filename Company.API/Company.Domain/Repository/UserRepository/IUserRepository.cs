using Company.Domain.Models;
using MongoDB.Bson;

namespace Company.Domain.Repository.UserRepository
{
    public interface IUserRepository
    {
        User FindUserByEmail(string email);
    }
}
