using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Repositories;

namespace DAL.App.EF
{
    public class AppEFUnitOfWork : IAppUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AppEFUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public IPersonRepository _people;
        public IPersonRepository People => _people = _people ?? new EFPersonRepository(_applicationDbContext);
        public IContactRepository _contacts;
        public IContactRepository Contacts => _contacts = _contacts ?? new EFContactRepository(_applicationDbContext);
        public IContactTypeRepository _contactTypes;

        public IContactTypeRepository ContactTypes =>
            _contactTypes = _contactTypes ?? new EFContactTypeRepository(_applicationDbContext);
    }
}
