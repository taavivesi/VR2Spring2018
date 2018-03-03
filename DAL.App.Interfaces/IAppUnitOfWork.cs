using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;

namespace DAL.App.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IPersonRepository People { get; }
        IContactRepository Contacts { get; }
        IContactTypeRepository ContactTypes { get; }
    }
}
