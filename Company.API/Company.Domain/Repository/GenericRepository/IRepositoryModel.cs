using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Repository.GenericRepository
{
    interface IRepositoryModel
    {
        DbSet<City> Cities { get; set; }
        DbSet<State> States { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Visit> Visits { get; set; }
    }
}
