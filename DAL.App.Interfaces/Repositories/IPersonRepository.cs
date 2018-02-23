using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        bool Exists(int id);
    }
}
